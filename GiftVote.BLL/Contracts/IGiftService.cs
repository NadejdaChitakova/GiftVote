using GiftVote.BLL.Models.Abstractions;
using GiftVote.BLL.Models.Response;

namespace GiftVote.BLL.Contracts;

public interface IGiftService
{
    Task<Result<List<GiftsResponse>>> GetAll(CancellationToken cancellationToken);
}