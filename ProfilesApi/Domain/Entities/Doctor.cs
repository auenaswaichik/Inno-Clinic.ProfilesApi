namespace Domain.Entities;

public class Doctor : User
{
    public string? DoctorFirstName { get; set; }
    public string? DoctorMiddleName { get; set; }
    public string? DoctorLastName { get; set; }
    public DateTime DoctorDateBirth { get; set; }
    public DateOnly DoctorCareerStartYear { get; set; }
    public Guid Profile_ID { get; set; }
    public Guid Specialization_ID { get; set; }
    public Guid Office_ID { get; set; }
}