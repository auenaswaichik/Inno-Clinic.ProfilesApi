using Domain.Entities.Parameters;

namespace Domain.RequestFeatures;

public sealed class DoctorParameters : RequestParameters
{
    public Guid SpecializationId { get; set; }
    public Guid OfficeId { get; set; }
    public string? SearchTerm { get; set; }
}
