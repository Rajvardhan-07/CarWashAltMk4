using System.ComponentModel.DataAnnotations;

namespace CarWashAlt.DTOs
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        public long PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Status { get; set; } = "Active";

        public string Role { get; set; }
    }
}
