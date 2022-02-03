using GraphqlAPI.Data;
using GraphqlAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphqlAPI.GraphQL.Authors
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Description("Author type description");

            descriptor.Field(x => x.Books)
                .ResolveWith<Resolvers>(x => x.GetBooks(default!, default!))
                .UseDbContext<SqlContext>()
                .Description("list of books").UseFiltering();
        }

        private class Resolvers
        {
            public IQueryable<Book> GetBooks([Parent] Author author, [ScopedService] SqlContext context)
            {
                return context.Books.Where(x => x.Authors.Contains(author));
            }
        }
    }
}