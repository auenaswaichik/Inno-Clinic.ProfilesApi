using Domain.Entities.Parameters;

namespace Domain.RequestFeatures;

public sealed class AdminParameters : RequestParameters
{
    public Guid OfficeId { get; set; }
    public string? SearchTerm { get; set; }
}
