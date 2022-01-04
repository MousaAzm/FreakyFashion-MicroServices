using System.ComponentModel.DataAnnotations;

namespace FreakyFashionServices.OrderProcessor.Models.DbModel
{
    public class Order
    {
        public Order(string identifier, string customer, string date)
        {        
            Identifier = identifier;
            Customer = customer;
            Date = date;
        }

        public int Id { get; set; }

        public string Identifier { get; set; }

        public string Customer { get; set; }

        public string Date { get; set; }
    }
}
