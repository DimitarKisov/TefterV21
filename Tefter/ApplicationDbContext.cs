namespace Tefter
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System.IO;
    using Tefter.DbEntities;

    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ConfigurationBuilder(optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<CarData> CarDatas { get; set; }

        public virtual DbSet<CarExtras> CarExtras { get; set; }

        public virtual DbSet<OilAndFilter> OilAndFilters { get; set; }

        public virtual DbSet<OtherService> OtherServices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(c => c.CarData)
                .WithOne(cd => cd.Car)
                .HasForeignKey<CarData>(c => c.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CarData>()
                .HasOne(cd => cd.CarExtras)
                .WithOne(ce => ce.CarData)
                .HasForeignKey<CarExtras>(cd => cd.CarDataId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OilAndFilter>()
                .HasOne(of => of.Car)
                .WithMany(c => c.OilAndFilters)
                .HasForeignKey(of => of.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OtherService>()
                .HasOne(os => os.Car)
                .WithMany(c => c.OtherServices)
                .HasForeignKey(os => os.CarId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private static void ConfigurationBuilder(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetSection("ConnectionString")["DefaultConnection"]);
        }
    }
}
