using BuberDinner.Domain.Host;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configs
{
    internal class HostConfigs : IEntityTypeConfiguration<Host>
    {
        public void Configure(EntityTypeBuilder<Host> builder)
        {
            ConfigureHostsTable(builder);
            ConfigureHostMenuIdsTable(builder);
            ConfigureHostDinneridsTable(builder);
        }

        private void ConfigureHostDinneridsTable(EntityTypeBuilder<Host> builder)
        {
            builder.OwnsMany(h => h.DinnerIds, dinnerIdsBuilder =>
            {
                dinnerIdsBuilder.ToTable("HostDinnerIds");

                dinnerIdsBuilder.WithOwner().HasForeignKey("HostId");

                dinnerIdsBuilder.HasKey("Id");

                dinnerIdsBuilder.Property(id => id.Value)
                                .HasColumnName("DinnerId")
                                .ValueGeneratedNever();
            });

            builder.Navigation(h => h.DinnerIds).UsePropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureHostMenuIdsTable(EntityTypeBuilder<Host> builder)
        {
            builder.OwnsMany(h => h.MenuIds, menuIdsBuilder =>
            {
                menuIdsBuilder.ToTable("HostMenuIds");

                menuIdsBuilder.WithOwner().HasForeignKey("HostId");

                menuIdsBuilder.HasKey("Id");

                menuIdsBuilder.Property(id => id.Value)
                                .HasColumnName("MenuId")
                                .ValueGeneratedNever();

            });

            builder.Navigation(h => h.MenuIds).UsePropertyAccessMode(PropertyAccessMode.Field);
        }





        private void ConfigureHostsTable(EntityTypeBuilder<Host> builder)
        {
            builder.ToTable("Hosts");

            //PK
            builder.HasKey(h => h.Id);

            builder.Property(h => h.Id)
                .ValueGeneratedNever()
                .HasConversion(id => id.Value, value => HostId.Create(value));

            builder.Property(h => h.FirstName)
                .HasMaxLength(100);

            builder.Property(h => h.LastName)
                .HasMaxLength(100);

            builder.OwnsOne(h => h.ProfileImage);

            builder.OwnsOne(h => h.AverageRating);

            builder.Property(h => h.UserId)
                .HasConversion(id => id.Value,
                               value => UserId.Create(value));

        }
    }
}
