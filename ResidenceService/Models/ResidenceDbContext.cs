using Microsoft.EntityFrameworkCore;

namespace ResidenceService.Models
{
    public class ResidenceDbContext : DbContext
    {
        public ResidenceDbContext(DbContextOptions<ResidenceDbContext> options) : base(options)
        {

            DbPath = Path.Join(Environment.CurrentDirectory, "residence.db");

            Database.EnsureCreated();
        }

        public string DbPath { get; }
        public DbSet<Resident>? Residents { get; set; }
        public DbSet<Residence>? Residences { get; set; }
        public DbSet<House>? Houses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        { 
            options.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resident>().HasData(
                new Resident 
                {
                    Id = 1,
                    FirstName = "Андрей",
                    SecondName = "Попов",
                    FatherName = "Сергеевич",
                    PassportCode = "2420-000832",
                    Sex = "м",
                    Age = 22 
                },
                new Resident
                {
                    Id = 2,
                    FirstName = "Даниил",
                    SecondName = "Иванов",
                    FatherName = "Юрьевич",
                    PassportCode = "2420-056732",
                    Sex = "м",
                    Age = 22
                },
                new Resident
                {
                    Id = 3,
                    FirstName = "Ирина",
                    SecondName = "Алексеева",
                    FatherName = "Александровна",
                    PassportCode = "1890-782332",
                    Sex = "ж",
                    Age = 47
                }      
            );            
            
            modelBuilder.Entity<House>().HasData(
                new House { 
                    Id= 1,
                    Province = "Ивановская область",
                    District = "Советский",
                    City = "Иваново",
                    Street = "Шошина",
                    Number = 4,
                    PostCode = "153005",
                    ARCPS = "3700",
                    FTSI = "45 263 552 000"
                },
                new House
                {
                    Id = 2,
                    Province = "Ивановская область",
                    District = "Советский",
                    City = "Иваново",
                    Street = "Шошина",
                    Number = 5,
                    PostCode = "153005",
                    ARCPS = "3700",
                    FTSI = "45 263 552 000"
                },                          
                new House
                {
                    Id = 3,
                    Province = "Ивановская область",
                    District = "Советский",
                    City = "Иваново",
                    Street = "Рыбинская",
                    Number = 6,
                    PostCode = "153005",
                    ARCPS = "3700",
                    FTSI = "45 263 552 000"
                }             
            );            
            
            modelBuilder.Entity<Residence>().HasData(
                new Residence
                { 
                    Id = 1,
                    Flat = 6,
                    HouseId = 1,
                    ResidentId = 1,
                },        
                new Residence
                { 
                    Id = 2,
                    Flat = 6,
                    HouseId = 1,
                    ResidentId = 2,
                },        
                new Residence
                { 
                    Id = 3,
                    Flat = 6,
                    HouseId = 1,
                    ResidentId = 3,
                }             
            );
        }
    }
}
