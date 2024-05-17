using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_Store
{
    internal class Receipt
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int Amount { get; set; }
        public List<ReceiptProduct> ReceiptProduct { get; set; }
        public List<Product> Products { get; set; }
    }
}
