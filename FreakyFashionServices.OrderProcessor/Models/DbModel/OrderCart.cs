using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreakyFashionServices.OrderProcessor.Models.DbModel
{
    public class OrderCart
    {
        public int Id { get; set; }

        public string? Identifier { get; set; }

        public List<OrderLine> Lines { get; set; } = new List<OrderLine>();
    }
}
