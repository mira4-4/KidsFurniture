using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFurniture.Infrastructure.Data.Entities
{
    [PrimaryKey(nameof(ProductId), nameof(UserId))]
    public class Favorites
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; } = null!;
    }
}
