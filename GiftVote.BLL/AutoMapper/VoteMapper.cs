using AutoMapper;
using GiftVote.BLL.Models.Request;
using GiftVote.Data.Models;

namespace GiftVote.BLL.AutoMapper
{
    public class VoteMapper : Profile
    {
        public VoteMapper()
        {
            CreateMap<Vote, CreateVoteRequest>();
            CreateMap<CreateVoteRequest, Vote>();
        }
    }
}
