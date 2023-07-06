namespace CarWashAlt.DTOs
{
    public class UserDTO
    {
        public int WasherId { get; set; }
        public string WasherName { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Status { get; set; }
        public int RatingsOfWasher { get; set; }
    }
}
