using EduCollector.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EF
{
    public class EduCollectorContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Webinar> Webinars { get; set; }
        public EduCollectorContext(DbContextOptions<EduCollectorContext> options) : base(options)
        {

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.Now;
                        break;
                    default:
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EduCollectorContext).Assembly);

            foreach (var item in DummyCategories.Get())
            {
                modelBuilder.Entity<Category>().HasData(item);
            }
            foreach (var item in DummyPosts.Get())
            {
                modelBuilder.Entity<Post>(b =>
                {
                    b.HasData(item);
                });
            }
            foreach (var item in DummyWebinars.Get())
            {
                modelBuilder.Entity<Webinar>().HasData(item);
            }
        }


    }
}
