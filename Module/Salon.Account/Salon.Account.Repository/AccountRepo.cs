using Salon.Account.Domain.Interface;
using Salon.Account.Repository.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Salon.Account.Repository
{
    public class AccountRepo : IAccountRepository
    {
        private readonly AccountDataContext _context;
        public AccountRepo(AccountDataContext context)
        {
            _context = context;
        }
        public async Task<List<Domain.Entity.Account>> GetAllAccountAsync()
        {
            try
            {
                return await _context.Accounts.ToListAsync();
            }
            catch
            {
                throw new TimeoutException("Conversion to a DateTime is not supported.");
            }
        }
        public async Task<Domain.Entity.Account> UpdateAsync(Domain.Entity.Account targetmodel)
        {
            try
            {
                var model = await _context.Accounts.FirstOrDefaultAsync(m => m.Id == targetmodel.Id);

                model.Active = targetmodel.Active;
                model.PassWord = targetmodel.PassWord;
                model.UserName = targetmodel.UserName;
                var res = await _context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                throw new KeyNotFoundException("Account with this id is not found");
            }
        }
        public async Task<Domain.Entity.Account> AddAsync(Domain.Entity.Account model)
        {
            try
            {
                await _context.AddAsync(model);
                await _context.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw new TimeoutException("Conversion to a DateTime is not supported.");
            }
        }
        public async Task<Domain.Entity.Account> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Accounts.FirstOrDefaultAsync(m => m.Id == id && m.Active == true);
            }
            catch (Exception)
            {
                throw new KeyNotFoundException("Account with this id is not found");
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var model = await _context.Accounts.FirstOrDefaultAsync(m => m.Id == id && m.Active == true);
                model.Active = false;
                var res = await _context.SaveChangesAsync() > 0;
                return res;
            }
            catch (Exception)
            {
                throw new KeyNotFoundException("Account with this" + id + " is not found");
            }
        }
        
    }
}
