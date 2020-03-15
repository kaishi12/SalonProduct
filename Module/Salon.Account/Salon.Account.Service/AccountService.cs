using Microsoft.IdentityModel.Tokens;
using Salon.Account.Domain.Interface;
using Salon.Account.Service.Constant;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Salon.Account.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository repo;
        public AccountService(IAccountRepository Repo)
        {
            repo = Repo;
        }
        public async Task<List<Domain.Entity.Account>> GetAccountsAsync()
        {
            try
            {
                return await repo.GetAllAccountAsync();
            }
            catch(Exception)
            {
                throw new Exception("fail");
            }
        }
        public async Task<Domain.Entity.Account> CreateAsync(Domain.Entity.Account model)
        {
            try
            {

                return await repo.AddAsync(model);
            }
            catch (Exception)
            {
                throw new Exception("fail");
            }
        }
        public async Task<Domain.Entity.Account> UpdateAsync(Domain.Entity.Account model)
        {
            try
            {

                return await repo.UpdateAsync(model);
            }
            catch (Exception)
            {
                throw new Exception("fail");
            }
        }
        public async Task<Domain.Entity.Account> GetByIdAsync(int id)
        {
            try
            {

                return await repo.GetByIdAsync(id);
            }
            catch (Exception)
            {
                throw new Exception("fail");
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {

                return await repo.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw new Exception("fail");
            }
        }
        private string GenerateToken(string User)
        {
            var handler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AuthenticateKeys.SERECT_KEY);
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("MemberId", User),
                    new Claim("Identifier", User),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = handler.CreateToken(descriptor);
            var respone = handler.WriteToken(token);
            return respone;

        }
    }
}
