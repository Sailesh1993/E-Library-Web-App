namespace WebApi.Domain.src.Entities
{
    public class User : BaseEntityWithId
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] Salt { get; set;}
        public Role Role { get; set; }
    }

    public enum Role
    {
        Admin,
        User
    }
}
