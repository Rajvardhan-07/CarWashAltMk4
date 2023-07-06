namespace CarWashAlt.Models
{
    public class OrderData
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string PackageName { get; set; }
        public DateTime Date_Time { get; set; }
        public string WasherName { get; set; }
        public string CarName { get; set; }
        public string CarModel { get; set; }
        public string PaymentStatus { get; set; }
        public string Adress { get; set; }
        public string DeliveryStatus { get; set; }
        public float TotalCost { get; set; }
    }
}
