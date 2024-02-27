
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BuberDinner.Infrastructure.Persistence.Configs
{
    internal class MenuConfigs : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            ConfigureMenusTable(builder);
            ConfigureMenuSectionsTable(builder);
            ConfigureMenuDinnerIdsTable(builder);
            ConfigureMenuReviewIdsTable(builder);
        }


        private void ConfigureMenuReviewIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.MenuReviewIds, menuReviewIdsBuilder =>
            {
                menuReviewIdsBuilder.ToTable("MenuReviewIds");

                menuReviewIdsBuilder.WithOwner().HasForeignKey("MenuId");

                menuReviewIdsBuilder.HasKey("Id");

                menuReviewIdsBuilder.Property(d => d.Value)
                    .HasColumnName("ReviewId")
                    .ValueGeneratedNever();


            });

            builder.Metadata.FindNavigation(nameof(Menu.MenuReviewIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuDinnerIdsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.DinnerIds, dinnerIdsBuilder =>
            {
                dinnerIdsBuilder.ToTable("MenuDinnerIds");

                dinnerIdsBuilder.WithOwner().HasForeignKey("MenuId");

                dinnerIdsBuilder.HasKey("Id");

                dinnerIdsBuilder.Property(d => d.Value)
                    .HasColumnName("DinnerId")
                    .ValueGeneratedNever();


            });

            builder.Metadata.FindNavigation(nameof(Menu.DinnerIds))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenuSectionsTable(EntityTypeBuilder<Menu> builder)
        {
            builder.OwnsMany(m => m.Sections, sectionBuilder =>
            {
                sectionBuilder.ToTable("MenuSections");

                sectionBuilder.WithOwner().HasForeignKey("MenuId");

                //Configure composite key
                sectionBuilder.HasKey("MenuId", "Id");

                sectionBuilder.Property(s => s.Id)
                    .HasColumnName("MenuSectionId")
                    .ValueGeneratedNever()
                    .HasConversion(
                        id => id.Value,
                        value => MenuSectionId.Create(value)
                    );

                sectionBuilder.Property(s => s.Name)
                    .HasMaxLength(100);

                sectionBuilder.Property(s => s.Description)
                    .HasMaxLength(100);


                //Items table configs
                sectionBuilder.OwnsMany(s => s.Items, itemBuilder =>
                {
                    itemBuilder.ToTable("MenuItems");

                    itemBuilder.WithOwner().HasForeignKey("MenuId", "MenuSectionId");

                    //configure composite key
                    itemBuilder.HasKey("Id", "MenuSectionId", "MenuId");

                    itemBuilder.Property(i => i.Id)
                        .HasColumnName("MenuItemId")
                        .ValueGeneratedNever()
                        .HasConversion(
                            id => id.Value,
                            value => MenuItemId.Create(value)
                        );


                    itemBuilder.Property(i => i.Name)
                        .HasMaxLength(100);

                    itemBuilder.Property(i => i.Description)
                        .HasMaxLength(100);
                });

                //Tell EFCore to populate the private field, not the IReadOnly Property
                sectionBuilder.Navigation(s => s.Items).Metadata.SetField("_items");
                sectionBuilder.Navigation(s => s.Items).UsePropertyAccessMode(PropertyAccessMode.Field);


            });

            //Tell EFCore to populate the private field, not the IReadOnly Property
            builder.Metadata.FindNavigation(nameof(Menu.Sections))!
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }

        private void ConfigureMenusTable(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menus");


            //Primary key
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                .ValueGeneratedNever() //No auto-generated values
                .HasConversion(
                    id => id.Value,
                    value => MenuId.Create(value));

            builder.Property(m => m.Name)
                .HasMaxLength(100);

            builder.Property(m => m.Description)
                .HasMaxLength(100);

            builder.OwnsOne(m => m.AverageRating);

            builder.Property(m => m.HostId)
                .HasConversion(
                    id => id.Value,
                    value => HostId.Create(value)
                );

        }
    }
}
