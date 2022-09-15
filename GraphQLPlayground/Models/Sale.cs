namespace GraphQLPlayground.Models;

public partial class Sale
{
    public DateTime? OrderDate { get; set; }

    public DateTime? StockDate { get; set; }

    public string? OrderNumber { get; set; }

    public int? ProductKey { get; set; }

    public int? CustomerKey { get; set; }

    public int? TerritoryKey { get; set; }

    public int? OrderLineItem { get; set; }

    public int? OrderQuantity { get; set; }
}
