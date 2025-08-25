namespace Infrastructure.Messages.PatientRegisteredMessages;

public class PatientRegisteredMessage
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public DateTime DateBirth { get; set; }
}