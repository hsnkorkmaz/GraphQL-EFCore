using System.Runtime.CompilerServices;
using GraphqlAPI.Data;
using GraphqlAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphqlAPI.GraphQL.Books
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Description("Book type description");
            descriptor.Field(p => p.Id).Ignore();

            descriptor.Field(x => x.Authors)
                .ResolveWith<Resolvers>(x => x.GetAuthors(default!, default!))
                .UseDbContext<SqlContext>()
                .Description("list of authors").UseFiltering();
        }

        private class Resolvers
        {
            public IQueryable<Author> GetAuthors([Parent] Book book, [ScopedService] SqlContext context)
            {
                return context.Authors.Where(x => x.Books.Contains(book));
            }
        }
    }
}
