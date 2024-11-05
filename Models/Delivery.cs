namespace Orders_Managment_System.Models
{
    public class Delivery
    {
        public int id { get; set; }
        public int OrderId { get; set; }
        public DateTime shipingdate { get; set; }
        public DateTime deliverydate { get; set; }
        public string status { get; set; } = "pending";
        public Order order { get; set; }
    }
}
