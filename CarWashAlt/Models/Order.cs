using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarWashAlt.Models
{
    public class Order
    {
        [Key]
        [DataType("int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CustomerName
        {
            get; set;
        }
        public DateTime Date_Time { get; set; } = DateTime.Now;
        public float TotalCost { get; set; }
        public string Status { get; set; } = "Not Delievered";
        public DateTime IsScheduledLater { get; set; } = DateTime.Now;
        public string Instructions { get; set; }
        public string PaymentStatus { get; set; } = "Not Paid";
        public int? PaymentId { get; set; }
        public double PhoneNumber { get; set; }


        public int CustId { get; set; }
        public int WasherId { get; set; }
        public int AddressId { get; set; }
        [ForeignKey("AddressId")]
        public Address Address { get; set; }


        public int PackageId { get; set; }

        public int CarId { get; set; }
        [ForeignKey("CarId")]
        public Car Car { get; set; }
    }
}
