namespace GraphQLPlayground.Models;

public partial class Product
{
    public int ProductKey { get; set; }

    public int ProductSubcategoryKey { get; set; }

    public string? ProductSku { get; set; }

    public string? ProductName { get; set; }

    public string? ModelName { get; set; }

    public string? ProductDescription { get; set; }

    public string? ProductColor { get; set; }

    public string? ProductSize { get; set; }

    public string? ProductStyle { get; set; }

    public double? ProductCost { get; set; }

    public double? ProductPrice { get; set; }
}
