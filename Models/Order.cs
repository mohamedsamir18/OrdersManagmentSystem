namespace Orders_Managment_System.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderCreationDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "pending";
        public decimal Total_Amount { get; set; }
        public Delivery delivery { get; set; }
    }
}
