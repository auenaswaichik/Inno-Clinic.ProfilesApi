namespace Domain.Entities;

public sealed class Specialization
{
    public Guid Id { get; set; }
    public List<Doctor> Doctors { get; set; } = new List<Doctor>();
    public string Name { get; set; }
    public string Description { get; set; }
}