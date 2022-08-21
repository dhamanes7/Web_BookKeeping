using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookKeeping.Models
{
    public class CategoryType
    {
        [Key]
        public string type { get; set; }

        [ForeignKey("CategoryModel")]
        public  int CategoryId { get; set; }

        public string name { get; set; }
    }
}
