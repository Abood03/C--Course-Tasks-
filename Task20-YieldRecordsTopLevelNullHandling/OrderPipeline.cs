namespace Task20_YieldRecordsTopLevelNullHandling;

public static class OrderPipeline
{
    // Read the CSV lazily
    public static IEnumerable<string> LoadLines(string path)
    {
        using StreamReader reader = new StreamReader(path);

        string? line;

        while ((line = reader.ReadLine()) != null)
        {
            yield return line;
        }
    }


    // Remove header, empty lines and invalid structure
    public static IEnumerable<string> CleanLines(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split(',');

            if (parts[0] == "OrderId")
                continue;

            if (parts.Length < 5)
                continue;

            yield return line;
        }
    }


    // Convert CSV lines into Order records
    public static IEnumerable<Order> ParseOrders(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            string[] parts = line.Split(',');

            string? orderId = parts[0]?.Trim();

            if (string.IsNullOrWhiteSpace(orderId))
                continue;


            string? customer = parts[1]?.Trim();

            if (string.IsNullOrWhiteSpace(customer))
            {
                customer = null;
            }

            customer ??= "Guest";


            if (!decimal.TryParse(parts[2], out decimal amount))
                continue;


            if (!DateTime.TryParse(parts[3], out DateTime orderDate))
                continue;


            decimal? discount = null;

            if (decimal.TryParse(parts[4], out decimal discountValue))
            {
                discount = discountValue;
            }


            yield return new Order(
                orderId,
                customer,
                amount,
                orderDate,
                discount
            );
        }
    }


    // Convert Order into OrderReport
    public static IEnumerable<OrderReport> CreateReports(
        IEnumerable<Order> orders)
    {
        foreach (var order in orders)
        {
            yield return OrderReport.Create(order);
        }
    }
}