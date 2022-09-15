namespace GraphQLPlayground.Models;

public partial class Return
{
    public string ReturnDate { get; set; } = null!;

    public int TerritoryKey { get; set; }

    public int ProductKey { get; set; }

    public int ReturnQuantity { get; set; }
}
