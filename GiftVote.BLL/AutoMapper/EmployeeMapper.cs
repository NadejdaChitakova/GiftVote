using AutoMapper;
using GiftVote.BLL.Models.Response;
using GiftVote.Data.Models;

namespace GiftVote.BLL.AutoMapper
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<Employee, EmployeesResponse>()
                .ForMember(x=> x.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(x=> x.HasActualBallot, opt => opt.MapFrom(src => src.EmployeeBallots.Any(y=>  y.StartTime.Year == DateTime.Now.Year)))
                .ForMember(x=> x.BirthDay, opt => opt.MapFrom(src => src.BirthdayDate.ToString("dd-MM-yyyy")));
        }
    }
}
