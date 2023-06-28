namespace CarDealerApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public string Email { get; set; }
        public byte[] salt { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
