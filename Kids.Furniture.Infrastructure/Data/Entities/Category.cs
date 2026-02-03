using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFurniture.Infrastructure.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }
        public virtual IEnumerable<Product> Products { get; set; } = new List<Product>();
    }
}
