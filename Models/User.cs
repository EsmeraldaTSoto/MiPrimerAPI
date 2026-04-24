namespace MiPrimerAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string First_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty;
        public string Avatar { get; set; } = string.Empty;
    }

    public class UserResponse
    {
        public List<User> Data { get; set; } = new List<User>();
    }
}
