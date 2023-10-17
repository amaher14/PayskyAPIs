using AutoMapper;
using Core.Entities;
using Core.Models.MobileModels.Application;
using Core.Models.MobileModels.Login;
using Core.Models.MobileModels.Regester;
using Core.Models.MobileModels.Vacancies;

namespace Application.Common.AutoMapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {


            CreateMap<Users, UserDTO>()
                                            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id))
                                            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName))
                                            .ForMember(dest => dest.userType, opt => opt.MapFrom(src => src.UserType.ToString()))
                                            .ReverseMap();
            CreateMap<Users, ApplicantRegesterDTO>()
                                            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                                            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                                            .ReverseMap();
            CreateMap<Users, EmployerRegesterDTO>()
                                           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                                           .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                                           .ReverseMap();
            CreateMap<Vacancy, GetVacancyDTO>()
                                         .ForMember(dest => dest.VacancyId, opt => opt.MapFrom(src => src.Id))
                                         .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
                                         .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                                         .ForMember(dest => dest.ExpireDate, opt => opt.MapFrom(src => src.ExpireDate))
                                         .ReverseMap();
            CreateMap<Core.Entities.Application, ApplyApplicationModel>()
                                      .ForMember(dest => dest.VacancyId, opt => opt.MapFrom(src => src.Vacancy))
                                      .ForMember(dest => dest.ApplicationStatus, opt => opt.MapFrom(src => src.ApplicationStatus))
                                      .ForMember(dest => dest.ApplicationDate, opt => opt.MapFrom(src => src.CreatedAt))
                                      .ForMember(dest => dest.ApplicantId, opt => opt.MapFrom(src => src.CreatedBy))
                                      .ReverseMap();
            CreateMap<Core.Entities.Application, ApplicationDTO>()
                                     .ForMember(dest => dest.VacancyId, opt => opt.MapFrom(src => src.VacancyId))
                                     .ForMember(dest => dest.ApplicationStatus, opt => opt.MapFrom(src => src.ApplicationStatus))
                                     .ForMember(dest => dest.ApplicationDate, opt => opt.MapFrom(src => src.CreatedAt))
                                     .ForMember(dest => dest.ApplicantId, opt => opt.MapFrom(src => src.CreatedBy))
                                     .ForMember(dest => dest.ApplicantName, opt => opt.MapFrom(src => src.Applicant.Users.FullName))
                                     .ForMember(dest => dest.ApplicantPhoneNumber, opt => opt.MapFrom(src => src.Applicant.Users.PhoneNumber))
                                     .ForMember(dest => dest.ApplicantEmail, opt => opt.MapFrom(src => src.Applicant.Email))
                                     .ReverseMap();

        }



    }
}
