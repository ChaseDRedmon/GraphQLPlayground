using GraphQLPlayground.GraphQL;
using GraphQLPlayground.Models;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Serilog;
using Path = System.IO.Path;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "Config"))
    .AddJsonFile("connections.json", optional: false, reloadOnChange: false)
    .AddJsonFile("loggingConfig.json", optional: false, reloadOnChange: false);

// Add services to the container.
builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("DbConnection");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddPooledDbContextFactory<AdventureWorksContext>(dbContextOptionsBuilder =>
    {
        dbContextOptionsBuilder.UseSqlServer(connectionString,
            optionsBuilder =>
            {
                optionsBuilder.EnableRetryOnFailure(3);
                optionsBuilder.CommandTimeout(30);
            });
    });

// Add Health Checks
/*builder.Services
    .AddHealthChecks()
    .AddCheck("HealthyCheck", () => HealthCheckResult.Healthy())
    .AddSqlServer(connectionString);

builder.Services
    .AddHealthChecksUI(s =>
    {
        s.AddHealthCheckEndpoint("endpoint1", "/health");
    })
    .AddSqlServerStorage(connectionString);*/

// Add GraphQL Services
builder.Services
    .AddMemoryCache()
    .AddMD5DocumentHashProvider()
    .AddGraphQLServer()
    .InitializeOnStartup()
    .RegisterDbContext<AdventureWorksContext>(DbContextKind.Pooled)
    .UseAutomaticPersistedQueryPipeline()
    .AddInMemoryQueryStorage()
    .AddQueryType(q => q.Name("Query"))
    .AddType<GraphQLWeather>()
    .AddType<AdventureWorks>()
    .AddProjections()
    .AddSorting()
    .AddFiltering();

// Add Logging
builder.Host.UseSerilog((context, configuration) => configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    /*endpoints.MapHealthChecks("/health", new HealthCheckOptions
    {
        Predicate = _ => true,
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });

    endpoints.MapHealthChecksUI();*/
    
    endpoints.MapBananaCakePop();
    endpoints.MapGraphQL();
});

try
{
    await app.RunAsync();
}
finally
{
    await Log.CloseAndFlushAsync();
}