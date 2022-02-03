using GraphqlAPI;
using GraphqlAPI.Data;
using GraphqlAPI.GraphQL;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Voyager;
using GraphqlAPI.GraphQL.Authors;
using GraphqlAPI.GraphQL.Books;

var builder = WebApplication.CreateBuilder(args);

//register sql server - AddPooledDbContextFactory scoped
builder.Services.AddPooledDbContextFactory<SqlContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Local")));

//register GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddType<AuthorType>()
    .AddType<BookType>()
    .AddProjections()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

//ensure db is created according to migrations
using (var serviceScope = ((IApplicationBuilder) app).ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    serviceScope.ServiceProvider.GetService<SqlContext>()?.Database.Migrate();
}

//map graphql queries
app.MapGraphQL();

//graphiql ui
app.UseGraphQLGraphiQL("/graphiql");

//voyager ui
app.UseGraphQLVoyager(new VoyagerOptions()
{
    GraphQLEndPoint = "/graphql"
}, "/voyager");



app.MapGet("/", () => "Hello from Graph go to /graphql!");

app.Run();