using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview;
using BuberDinner.Domain.MenuReview.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configs
{
    internal class MenuReviewConfigs : IEntityTypeConfiguration<MenuReview>
    {
        public void Configure(EntityTypeBuilder<MenuReview> builder)
        {
            ConfigureMenuReviewIdsTable(builder);
        }

        private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<MenuReview> builder)
        {
            builder.ToTable("MenuReviews");

            //PK
            builder.HasKey(mR => mR.Id);

            builder.Property(mR => mR.Id)
                .HasConversion(id => id.Value,
                                value => MenuReviewId.Create(value));

            builder.OwnsOne(mR => mR.Rating);

            builder.OwnsOne(mR => mR.Comment);

            builder.Property(mR => mR.HostId)
                .HasConversion(id => id.Value,
                                value => HostId.Create(value));

            builder.Property(mR => mR.MenuId)
                .HasConversion(id => id.Value,
                                value => MenuId.Create(value));

            builder.Property(mR => mR.GuestId)
                .HasConversion(id => id.Value,
                                value => GuestId.Create(value));

            builder.Property(mR => mR.DinnerId)
                .HasConversion(id => id.Value,
                                value => DinnerId.Create(value));


        }
    }
}
