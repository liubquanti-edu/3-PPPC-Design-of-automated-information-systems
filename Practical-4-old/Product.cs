using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store
{
    class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<ReceiptProduct> ReceiptProduct { get; set; }
        public List<Receipt> Receipts { get; set; }
    }
}
