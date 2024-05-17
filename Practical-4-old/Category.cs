using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store
{
    class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
