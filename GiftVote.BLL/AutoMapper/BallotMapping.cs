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

            CreateMap<Ballot, GetAllBallots>()
                .ForMember(x => x.GiftReceiverName, opt => opt.MapFrom(src => src.GiftReceiver.FullName))
                .ForMember(dest => dest.IsCurrentUserCanStopBallot, opt => opt.MapFrom(src => src.CreatorId == loggedUserId))
                .ForMember(dest => dest.IsUserVote, opt => opt.MapFrom(x=> x.Votes.Any(x=> x.VoterId == loggedUserId)));
        }
        }
}


