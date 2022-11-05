using NuGet.Protocol.Core.Types;

namespace joespizza.Models
{
    public class PizzaModel
    {
        public int ID { get; set; }
        public string? PizzaName { get; set; }
        public int Price { get; set; }

    }

    public class OrderModel
    {
        public int OrderID { get; set; }
        public string? PizzaName { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }


    }
}
