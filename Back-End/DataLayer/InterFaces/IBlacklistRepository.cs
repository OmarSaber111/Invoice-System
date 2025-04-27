using DataAccessLayer.Interfaces;
using Models.Entities;

namespace DataLayer.InterFaces
{
    public interface IBlacklistRepository : IRepository<BlackListedTokens>
    {
        Task AddAsync(BlackListedTokens token);
        Task<bool> IsBlacklistedAsync(string token);
    }
}
