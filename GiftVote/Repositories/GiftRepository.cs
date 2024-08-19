using GiftVote.Data.Context;
using GiftVote.Data.Models;
using GiftVote.Data.Repositories.Contracts;

namespace GiftVote.Data.Repositories
{
    internal class GiftRepository(IdentityDbContext context) : IGiftRepository
    {
        public IQueryable<Gifts> GetAll()
        {
            return context.Set<Gifts>();
        }
    }
}
