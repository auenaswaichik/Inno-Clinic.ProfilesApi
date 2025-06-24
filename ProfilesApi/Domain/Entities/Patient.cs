namespace Domain.Entities;

public class Patient : User
{

    public string? PatientFirstName { get; set; }
    public string? PatientMiddleName { get; set; }
    public string? PatientLastName { get; set; }
    public DateTime PatientDateBirth { get; set; }
    public Guid Profile_ID { get; set; }

}