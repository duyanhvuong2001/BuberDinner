using BuberDinner.Domain.Bill;
using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configs
{
    internal class BillConfigs : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            ConfigureBillsTable(builder);
        }

        private void ConfigureBillsTable(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("Bills");

            //PK
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .HasConversion(id => id.Value,
                                value => BillId.Create(value));

            builder.Property(b => b.DinnerId)
                .HasConversion(id => id.Value,
                                value => DinnerId.Create(value));

            builder.Property(b => b.GuestId)
                .HasConversion(id => id.Value,
                                value => GuestId.Create(value));

            builder.Property(b => b.HostId)
                .HasConversion(id => id.Value,
                                value => HostId.Create(value));

            builder.OwnsOne(b => b.Price);
        }
    }
}
