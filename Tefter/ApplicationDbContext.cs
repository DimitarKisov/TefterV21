namespace Tefter
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Tefter.DbEntities;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection"));
            base.OnConfiguring(optionsBuilder);
        }

        public IConfiguration Configuration { get; set; }

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
    }
}
