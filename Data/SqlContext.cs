using GraphqlAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphqlAPI.Data
{
    public class SqlContext :DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

    }
}
