using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreakyFashionServices.OrderProcessor.Models.Dtos
{
    public class ReadOrderDto
    {
        public int Id { get; set; }

        public string Identifier { get; set; } = "";

        public string Customer { get; set; } = "";

        public string Date { get; set; } = "";
    }
}
