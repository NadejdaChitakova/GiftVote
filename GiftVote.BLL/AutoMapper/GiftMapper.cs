using AutoMapper;
using GiftVote.BLL.Models.Response;
using GiftVote.Data.Models;

namespace GiftVote.BLL.AutoMapper
{
    public class GiftMapper : Profile
    {
        public GiftMapper() {
            CreateMap<Gifts, GiftsResponse>();
        }
    }
}
