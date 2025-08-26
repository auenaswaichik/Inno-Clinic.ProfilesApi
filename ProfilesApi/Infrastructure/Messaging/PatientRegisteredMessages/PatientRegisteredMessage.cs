namespace Infrastructure.Messages.PatientRegisteredMessages;

public class PatientRegisteredMessage
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
}