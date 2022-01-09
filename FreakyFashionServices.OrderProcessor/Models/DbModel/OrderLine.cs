using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreakyFashionServices.OrderProcessor.Models.DbModel
{
    public class OrderLine
    {   
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public Order Orders { get; set; } = new Order();
    }
}
