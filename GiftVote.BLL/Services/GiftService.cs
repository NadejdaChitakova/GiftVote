using AutoMapper;
using GiftVote.BLL.Contracts;
using GiftVote.BLL.Models.Abstractions;
using GiftVote.BLL.Models.Response;
using GiftVote.Data.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GiftVote.BLL.Services
{
    internal class GiftService(
        IGiftRepository giftRepository,
        IMapper mapper) : IGiftService
    {
        public async Task<Result<List<GiftsResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var query = giftRepository.GetAll();
            var result = mapper.ProjectTo<GiftsResponse>(query);
            return await result.ToListAsync(cancellationToken);
        }
    }
}
