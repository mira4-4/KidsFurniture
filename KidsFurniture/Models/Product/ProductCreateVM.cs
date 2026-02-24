using KidsFurniture.Models.Brand;
using KidsFurniture.Models.Category;

using System.ComponentModel.DataAnnotations;

namespace KidsFurniture.Models.Product
{
    public class ProductCreateVM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Display(Name = "Име на продукта")]
        public string ProductName { get; set; } = null!;

        [Required]
        [Display(Name = "Производител")]
        public int BrandId { get; set; }
        public virtual List<BrandPairVM> Brands { get; set; } = new List<BrandPairVM>();

        [Required]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        public virtual List<CategoryPairVM> Categories { get; set; } = new List<CategoryPairVM>();

        [Display(Name = "Снимка")]
        public string Picture { get; set; } = null!;


        [Required]
        [MaxLength(100)]
        [Display(Name = "Описание")]
        public string Description { get; set; } = null!;


        [Range(0, 5000)]
        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Отстъпка")]
        public decimal Discount { get; set; }
    }
}
