
using BuberDinner.Domain.User;
using BuberDinner.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configs
{
    internal class UserConfigs : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            ConfigureUsersTable(builder);
        }

        private void ConfigureUsersTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            //PK
            builder.Property(u => u.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value,
                                value => UserId.Create(value));

            builder.Property(u => u.FirstName)
                .HasMaxLength(100);

            builder.Property(u => u.LastName)
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .HasMaxLength(200);

            builder.OwnsOne(u => u.Password);

        }
    }
}
