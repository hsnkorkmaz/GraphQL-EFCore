using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace GraphqlAPI.Entities
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(25)]
        public string Surname { get; set; }

        public List<Book> Books { get; set; }
    }
}
