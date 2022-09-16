using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(a =>
            {
                a.ToTable("Brands").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Models);
            });

            modelBuilder.Entity<Model>(m =>
            {
                m.ToTable("Models").HasKey(k => k.Id);
                m.Property(p => p.Id).HasColumnName("Id");
                m.Property(p => p.BrandId).HasColumnName("BrandId");
                m.Property(p => p.Name).HasColumnName("Name");
                m.Property(p => p.DailyPrice).HasColumnName("DailyPrice");
                m.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
                m.HasOne(p => p.Brand);

            });



            Brand[] brandEntitySeeds = { new(1, "BMW"), new(2, "Mercedes") };
            modelBuilder.Entity<Brand>().HasData(brandEntitySeeds);

            Model[] modelEntitySeedsModels = { new Model(id: 1, name: "Series 4", brandId: 1, dailyPrice: 1500, imageUrl: ""), new Model(id: 2, name: "A 180", brandId: 2, dailyPrice: 1000, imageUrl: ""), new Model(id: 3, name: "Series 3", brandId: 1, dailyPrice: 1200, imageUrl: "") };
            modelBuilder.Entity<Model>().HasData(modelEntitySeedsModels);

        }
    }
}
