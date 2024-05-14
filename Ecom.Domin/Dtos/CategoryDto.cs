using System.ComponentModel.DataAnnotations;

namespace Ecom.Core.Dtos
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class ListingCategoryDto : CategoryDto
    {
        public int Id { get; set; }
    }
    public class UpdatingCategoryDto : CategoryDto
    {
        public int Id { get; set; }
    }
}
