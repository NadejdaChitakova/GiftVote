using AutoMapper;
using GiftVote.BLL.Models.Response;
using GiftVote.Data.Models;

namespace GiftVote.BLL.AutoMapper
{
    public class BallotMapper : Profile
    {
        public BallotMapper()
        {
            int? loggedUserId = null;
            int? ballotId = null;

            CreateMap<Ballot, GetAllBallots>()
                .ForMember(x => x.GiftReceiverName, opt => opt.MapFrom(src => src.GiftReceiver.FullName))
                .ForMember(dest => dest.IsCurrentUserCanStopBallot, opt => opt.MapFrom(src => src.CreatorId == loggedUserId))
                .ForMember(dest => dest.IsUserVote, opt => opt.MapFrom(x=> x.Votes.Any(x=> x.VoterId == loggedUserId)));

            CreateMap<Employee, EmployeeVote>()
                .ForMember(dest => dest.EmployeeFullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.EmployeeGiftVote, opt => opt.MapFrom(src => src.Votes.Where(x=> x.BallotId == ballotId).Select(x=> x.Gift.Name).FirstOrDefault()));
        }
        }
}


