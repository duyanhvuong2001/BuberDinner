using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configs
{
    internal class DinnerConfigs : IEntityTypeConfiguration<Dinner>
    {
        public void Configure(EntityTypeBuilder<Dinner> builder)
        {
            ConfigureDinnersTable(builder);
            ConfigureDinnerReservationsTable(builder);
        }

        private void ConfigureDinnerReservationsTable(EntityTypeBuilder<Dinner> builder)
        {
            builder.OwnsMany(d => d.Reservations, dinnerReservationsBuilder =>
            {
                dinnerReservationsBuilder.ToTable("DinnerReservations");

                dinnerReservationsBuilder.WithOwner().HasForeignKey("DinnerId");

                dinnerReservationsBuilder.HasKey("DinnerId", "Id");

                dinnerReservationsBuilder.Property(r => r.Id)
                    .HasColumnName("ReservationId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => DinnerReservationId.Create(value)
                    );

                dinnerReservationsBuilder.Property(r => r.GuestId)
                    .ValueGeneratedNever()
                    .HasConversion(id => id.Value,
                                    value => GuestId.Create(value));

                dinnerReservationsBuilder.Property(r => r.BillId)
                    .ValueGeneratedNever()
                    .HasConversion(id => id.Value,
                                    value => BillId.Create(value));
            });

            builder.Navigation(d => d.Reservations).UsePropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureDinnersTable(EntityTypeBuilder<Dinner> builder)
        {
            builder.ToTable("Dinners");

            //PK
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .HasConversion(id => id.Value,
                                value => DinnerId.Create(value));

            builder.Property(d => d.Name)
                .HasMaxLength(100);

            builder.Property(d => d.Description)
                .HasMaxLength(100);

            builder.OwnsOne(d => d.Price);

            builder.OwnsOne(d => d.Location);

            builder.Property(d => d.HostId)
                .HasConversion(id => id.Value,
                                value => HostId.Create(value));

            builder.Property(d => d.MenuId)
                .HasConversion(id => id.Value,
                                value => MenuId.Create(value));



        }
    }
}
