namespace DialogAPI.Models.Entities
{
    public class User
    {
        public int Id { get; set; }  // PK auto-incrément
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
