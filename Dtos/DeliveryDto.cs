namespace Orders_Managment_System.Dtos
{
    public class DeliveryDto
    {
        public int OrderId { get; set; }
        public DateTime shipingdate { get; set; }
        public DateTime deliverydate { get; set; }
        public string status { get; set; } = "pending";
    }
}
