namespace Domain.Entities;

public class Admin
{
    public Guid Admin_ID { get; set; }
    public string? AdminFirstName { get; set; }
    public string? AdminMiddleName { get; set; }
    public string? AdminLastName { get; set; }
    public DateTime AdminDateBirth { get; set; }
    public Guid Profile_ID { get; set; }
    public Guid Office_ID { get; set; }
}