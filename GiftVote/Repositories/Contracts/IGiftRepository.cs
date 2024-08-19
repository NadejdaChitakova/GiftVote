using GiftVote.Data.Models;

namespace GiftVote.Data.Repositories.Contracts;

public interface IGiftRepository
{
    IQueryable<Gifts> GetAll();
}