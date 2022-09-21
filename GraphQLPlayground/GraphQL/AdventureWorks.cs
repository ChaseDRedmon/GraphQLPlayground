using GraphQLPlayground.Models;

namespace GraphQLPlayground.GraphQL;

[ExtendObjectType("Query")]
public class AdventureWorks
{
    // Attributes must be in this order
    [UseProjection, UseSorting, UseFiltering]
    public IQueryable<Customer> GetCustomers(AdventureWorksContext context) => context.Customers;
}