using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ReHub.DbDataModel;
using ReHub.DbDataModel.Models;
using ReHub.Utilities.Encryption;

namespace ReHub.Db.PostgreSQL
{
    public class PostgresDbContext : DataContext
    {
        private readonly IEncryptionProvider _provider;
        public PostgresDbContext(IConfiguration configuration/*, ILogger logger*/) : base(configuration/*, logger*/) 
        {
            // TODO extract encrypt key in a safe environment
            _provider = new GenerateEncryptionProvider("rehub_encrypt_key", EncryptionAlgorithm.Aes);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration[":DbConfiguration:ConnectionString"]; ;
            //_logger.LogInformation($"Creating a PostgreSQL connection using:'{connectionString}'");
            optionsBuilder.UseNpgsql(connectionString,
                b => b.MigrationsAssembly("ReHub.Db.PostgreSQL"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseEncryption(this._provider);
            modelBuilder.Entity<User>()
                .HasMany(e => e.NotificationsForUser)
                .WithOne(e => e.Sender)
                .HasForeignKey(e=>e.SenderId);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Appointments)
                .WithOne(e => e.Speaker)
                .HasForeignKey(e => e.SpeakerId);

            modelBuilder.Entity<Admin>()
                .HasData(
                    new Admin
                    {
                        Id=1,
                        Name = "Mario",
                        Surname = "Z.",
                        Gender = GenderType.Male,
                        Password = "123456789",
                        Email = "mazioz63@mail.com",
                        Type = UserType.Doctor,
                        IsVerified = true,
                        AvatarUrl= "test"
                    }
                );
            modelBuilder.Entity<Doctor>()
                .HasData(
                    new Doctor
                    {
                        Id = 2,
                        Name = "Rick",
                        Surname = "Sanchez",
                        Gender = GenderType.Male,
                        Password = "123456789",
                        Email = "doctor1@example.com",
                        SubType = UserSubType.Physio,
                        About = "Text about doctor #3",
                        AvatarUrl = "https://static.wikia.nocookie.net/rickandmorty/images/3/3f/Young_Adult_Rick.png",
                        IsVerified = true,
                    },
                    new Doctor
                    {
                        Id = 3,
                        Name = "Adam",
                        Surname = "Warlock",
                        Email = "doctor2@example.com",
                        Gender = GenderType.Male,
                        Password = "123456789",
                        SubType = UserSubType.Physio,
                        About = "Text about doctor #4",
                        AvatarUrl = "https://static.wikia.nocookie.net/marveldatabase/images/0/02/Adam_Warlock_%28Earth-829%29_from_Hercules_Vol_2_3_0001.jpg"
                    }
            );
            modelBuilder.Entity<Client>()
                .HasData(
                    new Client
                    {
                        Id=4,
                        Name = "Test01",
                        Surname = "Test01",
                        Email = "test1@example.com",
                        Password="123456789"
                    },
                    new Client
                    {
                        Id=5,
                        Name = "Test02",
                        Surname = "Test02",
                        Email = "test2@example.com",
                        Password = "123456789"
                    }
                    );
            modelBuilder.Entity<LessonPackage>()
                .HasData(
                    new LessonPackage
                    {
                        Id=1,
                        Name = "PACKAGE NAME N.001",
                        LessonsNum = 1,
                        Cost = 9.9
                    },
                    new LessonPackage
                    {
                        Id=2,
                        Name = "PACKAGE NAME N.002",
                        LessonsNum = 5,
                        Cost = 44.9
                    },
                    new LessonPackage
                    {
                        Id=3,
                        Name = "PACKAGE NAME N.003",
                        LessonsNum = 10,
                        Cost = 79.9
                    });
modelBuilder.Entity<DiscountCoupon>()
                .HasData(
                    new DiscountCoupon
                    {
                        Id=1,
                        Name = "SALE",
                        CouponType = CouponType.Unlimited,
                        DiscountType = CouponDiscountType.Percentage,
                        Discount = 5,
                        ValidityUntil = DateTime.UtcNow.AddDays(30),
                    },
                    new DiscountCoupon
                    {
                        Id=2,
                        Name = "FIX",
                        CouponType = CouponType.One_time,
                        DiscountType = CouponDiscountType.Fixed_amount,
                        Discount = 1,
                        ValidityUntil = DateTime.UtcNow.AddDays(30),
                    }
            );
        }
    }
}
