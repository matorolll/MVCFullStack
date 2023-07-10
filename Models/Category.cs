using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCFullStack.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(30)]
		[DisplayName("Category Name")]
		public string Name { get; set; } = string.Empty;
        [DisplayName("Display Order")]
        [Range(1,100)]
        public int DisplayOrder { get; set; }
    }
}
