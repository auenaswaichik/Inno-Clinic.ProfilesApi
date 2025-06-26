using Application.Doctors.Models;
using Domain.Entities;
using MediatR;

namespace Application.Doctors.UseCases.GetAllDoctors;

public class GetAllDoctorsQuery : IRequest<List<DoctorDTO>>;