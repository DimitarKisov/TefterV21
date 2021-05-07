namespace Tefter
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using System.IO;
    using Tefter.DbEntities;

    public class ApplicationDbContext : DbContext
    {
        //public IConfiguration configuration;

        public ApplicationDbContext()
        {
            //Configuration = ConfigurationBuilder();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var configuration = ConfigurationBuilder(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-D6H1HDU\SQLEXPRESS;Database=TefterV21;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);

            //this.configuration = configuration;

            //kompa = DESKTOP-D6H1HDU\SQLEXPRESS
            //laptopa = SNEAKYSOB\SQLEXPRESS
        }

        //public IConfiguration Configuration { get; set; }

        public virtual DbSet<Car> Cars { get; set; }

        public virtual DbSet<CarExtras> CarExtras { get; set; }

        public virtual DbSet<OilAndFilter> OilAndFilters { get; set; }

        public virtual DbSet<OtherService> OtherServices { get; set; }

        public virtual DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(c => c.CarExtras)
                .WithOne(cd => cd.Car)
                .HasForeignKey<CarExtras>(c => c.CarId)
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

        //private static IConfiguration ConfigurationBuilder(DbContextOptionsBuilder optionsBuilder = null)
        //{
        //    var builder = new ConfigurationBuilder()
        //                         .SetBasePath(Directory.GetCurrentDirectory())
        //                         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        //    var configuration = builder.Build();
        //    return configuration;
        //}
    }
}
