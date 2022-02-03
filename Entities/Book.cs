using System.ComponentModel.DataAnnotations;

namespace GraphqlAPI.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }
        public List<Author> Authors { get; set; }
    }
}
