namespace GraphQLPlayground.Models;

public partial class Territory
{
    public int SalesTerritoryKey { get; set; }

    public string Region { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string Continent { get; set; } = null!;
}
