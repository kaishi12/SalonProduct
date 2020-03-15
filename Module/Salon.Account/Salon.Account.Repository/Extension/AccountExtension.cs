using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Salon.Account.Repository.DbContext;
using Microsoft.EntityFrameworkCore;
namespace Salon.Account.Repository.Extension
{
    public static class AccountExtension
    {
        public static void AddAccountDataExtension(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<AccountDataContext>((service, option) =>
            {
                var configuration = service.GetService<IConfiguration>();
                option.UseSqlServer(configuration.GetConnectionString("Salon_dev"));
                option.EnableSensitiveDataLogging(true);
            });

        }
    }
}
