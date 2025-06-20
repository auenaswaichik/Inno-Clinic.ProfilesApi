using AutoMapper;
using Domain.Entities;
using Shared.DTOs.AdminDTOs;

namespace Application.MappingProfiles;

public class AdminProfile : Profile
{
    public AdminProfile()
    {
        CreateMap<Admin, AdminDTO>();
        CreateMap<AdminDTO, Admin>();
        CreateMap<UpdateAdminDTO, Admin>();
        CreateMap<CreateAdminDTO, Admin>();
    }
}