using System.ComponentModel.DataAnnotations;

namespace KidsFurniture.Models.Product
{
    public class ProductDeleteVM
    {
        public int Id { get; set; }

        [Display(Name = "Име на продукта")]
        public string ProductName { get; set; }

        public int BrandId { get; set; }

        [Display(Name = "Производител")]
        public string BrandName { get; set; }

        public int CategoryId { get; set; }

        [Display(Name = "Категория")]
        public string CategoryName { get; set; }

        [Display(Name = "Снимка")]
        public string Picture { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [Display(Name = "Отстъпка")]
        public decimal Discount { get; set; }
    }
}

