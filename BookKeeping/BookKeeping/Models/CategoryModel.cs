using System.ComponentModel.DataAnnotations;

namespace BookKeeping.Models
{
    public class CategoryModel
    {
        [Key]
        public int typeId { get; set; }
        public string nameToken { get; set; }
        public string description { get; set; }

    }
}
