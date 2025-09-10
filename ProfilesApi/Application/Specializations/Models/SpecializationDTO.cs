namespace Application.Specializations.Models;

public record SpecializationDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public List<string> Doctors { get; init; }

    public SpecializationDTO(Guid id, string name, string description, List<string>? doctors)
    {
        Id = id;
        Name = name;
        Description = description;
        Doctors = doctors;
    }
};