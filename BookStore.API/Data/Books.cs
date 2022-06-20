using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Models
{
    public class Books
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Add Title properly")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
