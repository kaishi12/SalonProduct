using System.Collections.Generic;
using System.Threading.Tasks;

namespace Salon.Account.Domain.Interface
{
    public interface IAccountRepository
    {
        Task<List<Domain.Entity.Account>> GetAllAccountAsync();
        Task<Domain.Entity.Account> UpdateAsync(Domain.Entity.Account model);
        Task<Domain.Entity.Account> AddAsync(Domain.Entity.Account model);
        Task<Domain.Entity.Account> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
