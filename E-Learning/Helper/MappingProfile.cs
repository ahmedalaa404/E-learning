using AutoMapper;
using E_Learning.Core.DataTransferObjects;
using E_Learning.Core.Models;
using E_Learning.Core.Models.Basket;
using Microsoft.AspNetCore.Identity;

namespace E_Learning.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, UserDto>();
            CreateMap<AppUser, UserDTOIdentity>().ReverseMap();

            CreateMap<StudentDto, AppUser>().ReverseMap();

            CreateMap<IdentityRole, RoleDto>().ReverseMap();

            CreateMap<InstructorDto, AppUser>().ReverseMap();

            CreateMap<CourseDto, Course>().ReverseMap();

            CreateMap<ContactDto, Contact>().ReverseMap();

            CreateMap<Topic, TopicDto>().ReverseMap();

            CreateMap<CustomerBasket, BasketDto>().ReverseMap();

            CreateMap<BasketItem, BasketItemDto>().ReverseMap();

            CreateMap<Assignment, AssignmentDto>().ReverseMap();
        }
    }
}
