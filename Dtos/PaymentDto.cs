namespace Orders_Managment_System.Dtos
{
    public class PaymentDto
    {
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
