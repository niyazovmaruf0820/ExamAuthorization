using AutoMapper;
using Domain.DTOs.ClassSchduleDto;
using Domain.DTOs.MembershipDto;
using Domain.DTOs.PaymentDto;
using Domain.DTOs.TrainerDto;
using Domain.DTOs.UserDto;
using Domain.DTOs.WorkoutDto;
using Domain.Entities;

namespace Infrastructure.AutoMapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<User, CreateUserDto>().ReverseMap();
        CreateMap<User, GetUserDto>().ReverseMap();
        CreateMap<User, UpdateUserDto>().ReverseMap();

        CreateMap<Trainer, CreateTrainerDto>().ReverseMap();
        CreateMap<Trainer, GetTrainerDto>().ReverseMap();
        CreateMap<Trainer, UpdateTrainerDto>().ReverseMap();

        CreateMap<Workout, CreateWorkoutDto>().ReverseMap();
        CreateMap<Workout, GetWorkoutDto>().ReverseMap();
        CreateMap<Workout, UpdateWorkoutDto>().ReverseMap();

        CreateMap<Payment, CreatePaymentDto>().ReverseMap();
        CreateMap<Payment, GetPaymentDto>().ReverseMap();
        CreateMap<Payment, UpdatePaymentDto>().ReverseMap();

        CreateMap<Membership, CreateMembershipDto>().ReverseMap();
        CreateMap<Membership, GetMembershipDto>().ReverseMap();
        CreateMap<Membership, UpdateMembershipDto>().ReverseMap();

        CreateMap<ClassSchedule, CreateClassSchduleDto>().ReverseMap();
        CreateMap<ClassSchedule, GetClassSchduleDto>().ReverseMap();
        CreateMap<ClassSchedule, UpdateClassSchduleDto>().ReverseMap();
    }
}
