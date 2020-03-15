using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Salon.Account.Domain.Interface;
using System.Threading.Tasks;
using Salon.Account.Domain.Entity;

namespace SalonApi.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService AccountService;

        public AccountController(IAccountService accountservice)
        {
            AccountService = accountservice;

        }
        [HttpGet]
        public async Task<IActionResult> GetAllAccountAsync()
        {
            var res = await AccountService.GetAccountsAsync();
            return Ok(res);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var res = await AccountService.GetByIdAsync(id);
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Account model)
        {
            var res = await AccountService.CreateAsync(model);
            return Ok(res);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id,Account model)
        {
            model.Id = id;
            var res = await AccountService.UpdateAsync(model);
            return Ok(res);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var res = await AccountService.DeleteAsync(id);
            return Ok(res);
        }
        [HttpPost("login")]
        [SwaggerResponse(500, null, Description = "Server error")]
        public IActionResult Login()
        {

            return Ok();
        }


    }
}