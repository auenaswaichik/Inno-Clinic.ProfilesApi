using AutoMapper;
using Domain.Entities;
using Shared.DTOs.DoctorDTOs;

namespace Application.MappingProfiles;

public class DoctorProfile : Profile
{
    public DoctorProfile()
    {
        CreateMap<Doctor, DoctorDTO>();
        CreateMap<DoctorDTO, Doctor>();
        CreateMap<UpdateDoctorDTO, Doctor>();
        CreateMap<CreateDoctorDTO, Doctor>();
    }
}