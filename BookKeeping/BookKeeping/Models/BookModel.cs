using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeping.Models
{
    public class BookModel
    {
        [Key]
        public int isbn { get; set; }
        
        public string title { get; set; }
        [ForeignKey("CategoryModel")]
        public int categoryId { get; set; }
        public string Author { get; set; }
    }
}
