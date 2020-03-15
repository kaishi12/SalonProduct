using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Salon.Account.Repository.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Salon.Account.Domain.Entity.Account>
    {
        public void Configure(EntityTypeBuilder<Salon.Account.Domain.Entity.Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey("Id");
        }
    }
}
