using BuberDinner.Domain.Bill;
using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Guest;
using BuberDinner.Domain.Host;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.MenuReview;
using BuberDinner.Domain.User;
using BuberDinner.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;


namespace BuberDinner.Infrastructure.Persistence
{
    public class BuberDinnerDbContext : DbContext
    {
        private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
        public BuberDinnerDbContext(DbContextOptions options, PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
        {
            _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Bill> Bills { get; set; }
        public DbSet<Dinner> Dinners { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<Host> Hosts { get; set; }
        public DbSet<MenuReview> MenuReviews { get; set; }
        public DbSet<Guest> Guests { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
