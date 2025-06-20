using AutoMapper;
using Domain.Entities;
using Shared.DTOs.PatientDTOs;

namespace Application.MappingProfiles;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<Patient, PatientDTO>();
        CreateMap<PatientDTO, Patient>();
        CreateMap<UpdatePatientDTO, Patient>();
        CreateMap<CreatePatientDTO, Patient>();
    }
}