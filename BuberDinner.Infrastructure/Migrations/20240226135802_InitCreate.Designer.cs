﻿// <auto-generated />
using System;
using BuberDinner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BuberDinner.Infrastructure.Migrations
{
    [DbContext(typeof(BuberDinnerDbContext))]
    [Migration("20240226135802_InitCreate")]
    partial class InitCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BuberDinner.Domain.Bill.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GuestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Bills", (string)null);
                });

            modelBuilder.Entity("BuberDinner.Domain.Guest.Guest", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Guests", (string)null);
                });

            modelBuilder.Entity("BuberDinner.Domain.Host.Host", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Hosts", (string)null);
                });

            modelBuilder.Entity("BuberDinner.Domain.Menu.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Menus", (string)null);
                });

            modelBuilder.Entity("BuberDinner.Domain.MenuReview.MenuReview", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("DinnerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GuestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MenuReviews", (string)null);
                });

            modelBuilder.Entity("BuberDinner.Domain.Bill.Bill", b =>
                {
                    b.OwnsOne("BuberDinner.Domain.Common.ValueObjects.Price", "Price", b1 =>
                        {
                            b1.Property<Guid>("BillId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("BillId");

                            b1.ToTable("Bills");

                            b1.WithOwner()
                                .HasForeignKey("BillId");
                        });

                    b.Navigation("Price")
                        .IsRequired();
                });

            modelBuilder.Entity("BuberDinner.Domain.Guest.Guest", b =>
                {
                    b.OwnsMany("BuberDinner.Domain.Bill.ValueObjects.BillId", "BillIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("BillId");

                            b1.HasKey("Id");

                            b1.HasIndex("GuestId");

                            b1.ToTable("GuestBillIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("GuestId");
                        });

                    b.OwnsMany("BuberDinner.Domain.Guest.Entities.GuestRating", "Ratings", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("CreatedDateTime")
                                .HasColumnType("datetime2");

                            b1.Property<Guid>("DinnerId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("UpdatedDateTime")
                                .HasColumnType("datetime2");

                            b1.HasKey("Id", "GuestId");

                            b1.HasIndex("GuestId");

                            b1.ToTable("GuestRatings", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("GuestId");

                            b1.OwnsOne("BuberDinner.Domain.Common.ValueObjects.Rating", "Rating", b2 =>
                                {
                                    b2.Property<Guid>("GuestRatingId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("GuestRatingGuestId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.HasKey("GuestRatingId", "GuestRatingGuestId");

                                    b2.ToTable("GuestRatings");

                                    b2.WithOwner()
                                        .HasForeignKey("GuestRatingId", "GuestRatingGuestId");
                                });

                            b1.Navigation("Rating")
                                .IsRequired();
                        });

                    b.OwnsOne("BuberDinner.Domain.Common.ValueObjects.AverageRating", "AverageRating", b1 =>
                        {
                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("NumRatings")
                                .HasColumnType("int");

                            b1.Property<double>("Value")
                                .HasColumnType("float");

                            b1.HasKey("GuestId");

                            b1.ToTable("Guests");

                            b1.WithOwner()
                                .HasForeignKey("GuestId");
                        });

                    b.OwnsMany("BuberDinner.Domain.MenuReview.ValueObjects.MenuReviewId", "MenuReviewIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("MenuReviewId");

                            b1.HasKey("Id");

                            b1.HasIndex("GuestId");

                            b1.ToTable("GuestMenuReviewIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("GuestId");
                        });

                    b.OwnsMany("BuberDinner.Domain.Dinner.ValueObjects.DinnerId", "PastDinnerIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("PastDinnerId");

                            b1.HasKey("Id");

                            b1.HasIndex("GuestId");

                            b1.ToTable("GuestPastDinnerIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("GuestId");
                        });

                    b.OwnsMany("BuberDinner.Domain.Dinner.ValueObjects.DinnerId", "PendingDinnerIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("PendingDinnerId");

                            b1.HasKey("Id");

                            b1.HasIndex("GuestId");

                            b1.ToTable("GuestPendingDinnerIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("GuestId");
                        });

                    b.OwnsOne("BuberDinner.Domain.Common.ValueObjects.ProfileImage", "ProfileImage", b1 =>
                        {
                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("ImageURL")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("GuestId");

                            b1.ToTable("Guests");

                            b1.WithOwner()
                                .HasForeignKey("GuestId");
                        });

                    b.OwnsMany("BuberDinner.Domain.Dinner.ValueObjects.DinnerId", "UpcomingDinnerIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<Guid>("GuestId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("UpcomingDinnerId");

                            b1.HasKey("Id");

                            b1.HasIndex("GuestId");

                            b1.ToTable("GuestUpcomingDinnerIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("GuestId");
                        });

                    b.Navigation("AverageRating")
                        .IsRequired();

                    b.Navigation("BillIds");

                    b.Navigation("MenuReviewIds");

                    b.Navigation("PastDinnerIds");

                    b.Navigation("PendingDinnerIds");

                    b.Navigation("ProfileImage")
                        .IsRequired();

                    b.Navigation("Ratings");

                    b.Navigation("UpcomingDinnerIds");
                });

            modelBuilder.Entity("BuberDinner.Domain.Host.Host", b =>
                {
                    b.OwnsOne("BuberDinner.Domain.Common.ValueObjects.AverageRating", "AverageRating", b1 =>
                        {
                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("NumRatings")
                                .HasColumnType("int");

                            b1.Property<double>("Value")
                                .HasColumnType("float");

                            b1.HasKey("HostId");

                            b1.ToTable("Hosts");

                            b1.WithOwner()
                                .HasForeignKey("HostId");
                        });

                    b.OwnsMany("BuberDinner.Domain.Dinner.ValueObjects.DinnerId", "DinnerIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("DinnerId");

                            b1.HasKey("Id");

                            b1.HasIndex("HostId");

                            b1.ToTable("HostDinnerIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("HostId");
                        });

                    b.OwnsOne("BuberDinner.Domain.Common.ValueObjects.ProfileImage", "ProfileImage", b1 =>
                        {
                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("ImageURL")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("HostId");

                            b1.ToTable("Hosts");

                            b1.WithOwner()
                                .HasForeignKey("HostId");
                        });

                    b.OwnsMany("BuberDinner.Domain.Menu.ValueObjects.MenuId", "MenuIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("MenuId");

                            b1.HasKey("Id");

                            b1.HasIndex("HostId");

                            b1.ToTable("HostMenuIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("HostId");
                        });

                    b.Navigation("AverageRating")
                        .IsRequired();

                    b.Navigation("DinnerIds");

                    b.Navigation("MenuIds");

                    b.Navigation("ProfileImage")
                        .IsRequired();
                });

            modelBuilder.Entity("BuberDinner.Domain.Menu.Menu", b =>
                {
                    b.OwnsMany("BuberDinner.Domain.Menu.Entities.MenuSection", "Sections", b1 =>
                        {
                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("MenuSectionId");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("MenuId", "Id");

                            b1.ToTable("MenuSections", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");

                            b1.OwnsMany("BuberDinner.Domain.Menu.Entities.MenuItem", "Items", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uniqueidentifier")
                                        .HasColumnName("MenuItemId");

                                    b2.Property<Guid>("MenuSectionId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("MenuId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.HasKey("Id", "MenuSectionId", "MenuId");

                                    b2.HasIndex("MenuId", "MenuSectionId");

                                    b2.ToTable("MenuItems", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("MenuId", "MenuSectionId");
                                });

                            b1.Navigation("Items");
                        });

                    b.OwnsOne("BuberDinner.Domain.Common.ValueObjects.AverageRating", "AverageRating", b1 =>
                        {
                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("NumRatings")
                                .HasColumnType("int");

                            b1.Property<double>("Value")
                                .HasColumnType("float");

                            b1.HasKey("MenuId");

                            b1.ToTable("Menus");

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.OwnsMany("BuberDinner.Domain.Dinner.ValueObjects.DinnerId", "DinnerIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("DinnerId");

                            b1.HasKey("Id");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuDinnerIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.OwnsMany("BuberDinner.Domain.MenuReview.ValueObjects.MenuReviewId", "MenuReviewIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("Id"), 1L, 1);

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("ReviewId");

                            b1.HasKey("Id");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuReviewIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.Navigation("AverageRating")
                        .IsRequired();

                    b.Navigation("DinnerIds");

                    b.Navigation("MenuReviewIds");

                    b.Navigation("Sections");
                });

            modelBuilder.Entity("BuberDinner.Domain.MenuReview.MenuReview", b =>
                {
                    b.OwnsOne("BuberDinner.Domain.Common.ValueObjects.Rating", "Rating", b1 =>
                        {
                            b1.Property<Guid>("MenuReviewId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("MenuReviewId");

                            b1.ToTable("MenuReviews");

                            b1.WithOwner()
                                .HasForeignKey("MenuReviewId");
                        });

                    b.OwnsOne("BuberDinner.Domain.MenuReview.ValueObjects.Comment", "Comment", b1 =>
                        {
                            b1.Property<Guid>("MenuReviewId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("MenuReviewId");

                            b1.ToTable("MenuReviews");

                            b1.WithOwner()
                                .HasForeignKey("MenuReviewId");
                        });

                    b.Navigation("Comment")
                        .IsRequired();

                    b.Navigation("Rating")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
