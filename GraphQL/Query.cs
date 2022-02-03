using GraphqlAPI.Data;
using GraphqlAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphqlAPI.GraphQL
{
    [GraphQLDescription("General description to Query")]
    public class Query
    {
        [GraphQLDescription("Description to GetBooks")]
        [UseDbContext(typeof(SqlContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks([ScopedService] SqlContext context)
        {
            var result = context.Books;
            return result;
        }

        [GraphQLDescription("Description to GetAuthors")]
        [UseDbContext(typeof(SqlContext))]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Author> GetAuthors([ScopedService] SqlContext context)
        {
            var result = context.Authors;
            return result;
        }
    }
}
