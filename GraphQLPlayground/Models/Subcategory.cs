namespace GraphQLPlayground.Models;

public partial class Subcategory
{
    public int ProductSubcategoryKey { get; set; }

    public string? SubcategoryName { get; set; }

    public int ProductCategoryKey { get; set; }
}
