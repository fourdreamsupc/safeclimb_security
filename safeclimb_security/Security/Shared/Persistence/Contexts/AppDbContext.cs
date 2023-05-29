using Microsoft.EntityFrameworkCore;
using safeclimb_security.Security.Extensions;
using safeclimb_security.Security.Subscriptions.Domain.Models;

namespace safeclimb_security.Security.Shared.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Subscription> Subscriptions { get; set; }
        
        protected readonly IConfiguration _configuration;

        public AppDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            //Constraints
            builder.Entity<Subscription>().ToTable("Subscriptions");
            builder.Entity<Subscription>().HasKey(p => p.Id);
            builder.Entity<Subscription>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Subscription>().Property(p => p.Name).IsRequired();
            builder.Entity<Subscription>().Property(p => p.Price).IsRequired();
            builder.Entity<Subscription>().Property(p => p.Description).IsRequired();

            builder.UseSnakeCaseNamingConventions();
        }
        
    }
}