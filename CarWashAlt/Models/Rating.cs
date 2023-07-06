using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarWashAlt.Models
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int WasherId { get; set; }
        public int RatingsOfWasher { get; set; }
        public int OrderId
        {
            get; set;
        }
    }
}
