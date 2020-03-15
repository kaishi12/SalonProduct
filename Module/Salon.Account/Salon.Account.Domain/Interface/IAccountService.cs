
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Salon.Account.Domain.Interface
{
    public interface IAccountService
    {
        Task<List<Domain.Entity.Account>> GetAccountsAsync();
        Task<Domain.Entity.Account> UpdateAsync(Domain.Entity.Account model);
        Task<Domain.Entity.Account> CreateAsync(Domain.Entity.Account model);
        Task<bool> DeleteAsync(int id);
        Task<Domain.Entity.Account> GetByIdAsync(int id);
    }
}
