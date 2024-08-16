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
                .ForMember(x=> x.HasActualBallot, opt => opt.MapFrom(src => src.CreatedBallots.Any(y=> y.GiftReceiverId == src.Id && y.StartTime.Year == DateTime.Now.Year)));
        }
    }
}
