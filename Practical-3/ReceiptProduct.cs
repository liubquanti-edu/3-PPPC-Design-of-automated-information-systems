using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Store
{
    internal class ReceiptProduct
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ReceiptId { get; set; }
        public Receipt Receipt { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
    }
}
