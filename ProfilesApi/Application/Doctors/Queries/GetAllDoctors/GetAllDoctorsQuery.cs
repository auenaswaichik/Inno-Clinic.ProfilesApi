using Domain.Entities;
using MediatR;

namespace Application.Doctors.Queries.GetAllDoctors;

public class GetAllDoctorsQuery : IRequest<List<Doctor>>;