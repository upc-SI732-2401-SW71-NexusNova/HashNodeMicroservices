namespace HashNode.API.AccessIdentityManagement.Domain.Commands;

public record UpdateUserCommand
{
     
    public UpdateUserCommand(string FirstName, string LastName, string Email, string PhoneNumber, string UserName, string Password, string Role)
    {
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.Email = Email;
        this.PhoneNumber = PhoneNumber;
        this.UserName = UserName;
        this.Password = Password;
        this.Role = Role;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}