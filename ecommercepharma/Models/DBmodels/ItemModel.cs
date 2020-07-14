using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommercepharma.Models.DBmodels
{
    public class ItemModel
    {
        public long Id { get; set; }
        public long IdCategory { get; set; }
        public long IdSeller { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
