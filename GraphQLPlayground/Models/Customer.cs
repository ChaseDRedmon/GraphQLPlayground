namespace GraphQLPlayground.Models;

public partial class Customer
{
    public int CustomerKey { get; set; }

    public string? Prefix { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? BirthDate { get; set; }

    public string? MaritalStatus { get; set; }

    public string? Gender { get; set; }

    public string? EmailAddress { get; set; }

    public string? AnnualIncome { get; set; }

    public int? TotalChildren { get; set; }

    public string? EducationLevel { get; set; }

    public string? Occupation { get; set; }

    public string? HomeOwner { get; set; }
}
