

using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configs
{
    internal class GuestConfigs : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            ConfigureGuestsTable(builder);
            ConfigureGuestRatingsTable(builder);
            ConfigureGuestUpcomingDinnerIdsTable(builder);
            ConfigureGuestPastDinnerIdsTable(builder);
            ConfigureGuestPendingDinnerIdsTable(builder);
            ConfigureGuestMenuReviewIdsTable(builder);
            ConfigureGuestBillIdsTable(builder);
        }

        private void ConfigureGuestBillIdsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(g => g.BillIds, billIdsBuilder =>
            {
                billIdsBuilder.ToTable("GuestBillIds");

                billIdsBuilder.WithOwner().HasForeignKey("GuestId");

                billIdsBuilder.HasKey("Id");

                billIdsBuilder.Property(b => b.Value)
                                .HasColumnName("BillId")
                                .ValueGeneratedNever();

            });

            builder.Navigation(g => g.BillIds).UsePropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureGuestMenuReviewIdsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(g => g.MenuReviewIds, menuReviewIdsTable =>
            {
                menuReviewIdsTable.ToTable("GuestMenuReviewIds");

                menuReviewIdsTable.WithOwner().HasForeignKey("GuestId");

                menuReviewIdsTable.HasKey("Id");

                menuReviewIdsTable.Property(mR => mR.Value)
                                .HasColumnName("MenuReviewId")
                                .ValueGeneratedNever();

            });

            builder.Navigation(g => g.MenuReviewIds).UsePropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureGuestPendingDinnerIdsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(g => g.PendingDinnerIds, pendingDinnerIdsBuilder =>
            {
                pendingDinnerIdsBuilder.ToTable("GuestPendingDinnerIds");

                pendingDinnerIdsBuilder.WithOwner().HasForeignKey("GuestId");

                pendingDinnerIdsBuilder.HasKey("Id");

                pendingDinnerIdsBuilder.Property(pD => pD.Value)
                                        .HasColumnName("PendingDinnerId")
                                        .ValueGeneratedNever();

            });

            builder.Navigation(g => g.PendingDinnerIds).UsePropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureGuestPastDinnerIdsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(g => g.PastDinnerIds, pastDinnerIdsBuilder =>
            {
                pastDinnerIdsBuilder.ToTable("GuestPastDinnerIds");

                pastDinnerIdsBuilder.WithOwner().HasForeignKey("GuestId");

                pastDinnerIdsBuilder.HasKey("Id");

                pastDinnerIdsBuilder.Property(pD => pD.Value)
                                        .HasColumnName("PastDinnerId")
                                        .ValueGeneratedNever();

            });

            builder.Navigation(g => g.PastDinnerIds).UsePropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureGuestUpcomingDinnerIdsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(g => g.UpcomingDinnerIds, upcomingDinnerIdsBuilder =>
            {
                upcomingDinnerIdsBuilder.ToTable("GuestUpcomingDinnerIds");

                upcomingDinnerIdsBuilder.WithOwner().HasForeignKey("GuestId");

                upcomingDinnerIdsBuilder.HasKey("Id");

                upcomingDinnerIdsBuilder.Property(uD => uD.Value)
                                        .HasColumnName("UpcomingDinnerId")
                                        .ValueGeneratedNever();

            });

            builder.Navigation(g => g.UpcomingDinnerIds).UsePropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureGuestRatingsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.OwnsMany(g => g.Ratings, guestRatingsBuilder =>
            {
                guestRatingsBuilder.ToTable("GuestRatings");

                guestRatingsBuilder.WithOwner().HasForeignKey("GuestId");

                //Composite key
                guestRatingsBuilder.HasKey("Id", "GuestId");

                guestRatingsBuilder.Property(gR => gR.Id)
                                .ValueGeneratedNever()
                                .HasConversion(id => id.Value,
                                                value => GuestRatingId.Create(value));



                guestRatingsBuilder.Property(gR => gR.HostId)
                                .HasConversion(id => id.Value,
                                                value => HostId.Create(value));

                guestRatingsBuilder.Property(gR => gR.DinnerId)
                                .HasConversion(id => id.Value,
                                                value => DinnerId.Create(value));

                guestRatingsBuilder.OwnsOne(gR => gR.Rating);



            });

            builder.Navigation(g => g.Ratings).UsePropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureGuestsTable(EntityTypeBuilder<Guest> builder)
        {
            builder.ToTable("Guests");

            //PK
            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .HasConversion(id => id.Value,
                                value => GuestId.Create(value));

            builder.Property(g => g.FirstName)
                .HasMaxLength(100);

            builder.Property(g => g.LastName)
                .HasMaxLength(100);

            builder.OwnsOne(g => g.ProfileImage);

            builder.OwnsOne(g => g.AverageRating);

            builder.Property(g => g.UserId)
                .HasConversion(id => id.Value,
                                value => UserId.Create(value));


        }
    }
}
