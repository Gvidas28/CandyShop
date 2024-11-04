using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyShop.Model.Entities
{
    public class OrderMinimal
    {
        public int ID { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public DateTime OrderDate { get; set; }
    }
}