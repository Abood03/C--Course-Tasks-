namespace Task20_YieldRecordsTopLevelNullHandling;

public record Order(
    string OrderId,
    string Customer,
    decimal Amount,
    DateTime OrderDate,
    decimal? Discount
);

public record OrderReport(
    string OrderId,
    string Customer,
    decimal Amount,
    decimal? Discount,
    DateTime OrderDate
)
{
    public decimal FinalPrice => Amount - (Discount ?? 0);

    public bool HasDiscount => Discount != null;

    public static OrderReport Create(Order order)
    {
        var (id, customer, amount, date, discount) = order;

        return new OrderReport(
            id,
            customer,
            amount,
            discount,
            date
        );
    }
}