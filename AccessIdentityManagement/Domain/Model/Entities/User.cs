
namespace HashNode.API.UserManagement.Domain.Model.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public User()
        {
        }
        
        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }
        
        public User SaveUser(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
            return this;
        }
    }
}
