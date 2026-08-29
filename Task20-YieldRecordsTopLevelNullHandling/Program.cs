using Task20_YieldRecordsTopLevelNullHandling;


// Build the pipeline
var lines = OrderPipeline.LoadLines("orders.csv");

var cleanLines = OrderPipeline.CleanLines(lines);

var orders = OrderPipeline.ParseOrders(cleanLines);

var reports = OrderPipeline.CreateReports(orders);


// Pipeline starts executing here
List<OrderReport> orderList = reports.ToList();


Console.WriteLine("=== Orders ===");

foreach (var order in orderList)
{
    Console.WriteLine(
        $"{order.OrderId} | " +
        $"{order.Customer} | " +
        $"Amount: {order.Amount:C} | " +
        $"Discount: {(order.Discount?.ToString("C") ?? "None")} | " +
        $"Final: {order.FinalPrice:C}"
    );
}


Console.WriteLine();
Console.WriteLine("=== Record Equality ===");

if (orderList.Count >= 2)
{
    OrderReport copy = orderList[0] with { };

    Console.WriteLine(orderList[0]);
    Console.WriteLine(copy);

    Console.WriteLine(
        $"Same value: {orderList[0] == copy}"
    );
}


Console.WriteLine();
Console.WriteLine("=== With Expression ===");

if (orderList.Count > 0)
{
    Console.WriteLine($"Before: {orderList[0]}");

    OrderReport updated =
        orderList[0] with
        {
            Amount = orderList[0].Amount + 100
        };

    Console.WriteLine($"After: {updated}");

    Console.WriteLine(
        $"New Final Price: {updated.FinalPrice:C}"
    );
}