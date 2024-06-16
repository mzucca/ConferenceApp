using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ReHub.DbDataModel.Configuration;
using ReHub.DbDataModel.Extensions;
using ReHub.Domain;
using ReHub.Domain.Enums;
using ReHub.Utilities.Encryption;

namespace ReHub.DbDataModel;

public class DataContext : DbContext
{
    protected readonly IConfiguration _configuration;
    protected readonly ILogger<DataContext> _logger;
    private readonly IEncryptionProvider _provider;
    private readonly DbConfiguration _dbConfiguration;


    public DataContext(IConfiguration configuration, DbContextOptions options, ILogger<DataContext> logger) : base(options)
    {
        _configuration = configuration;
        _dbConfiguration = configuration.GetDbConfiguration();
        if (_dbConfiguration == null) throw new InvalidOperationException("Cannot find suitable DB configuration, please check your configuration environment");
        // We need to use a fixed salt to have the same results over time
        _provider = new GenerateEncryptionProvider(_dbConfiguration.EncryptionKey, _dbConfiguration.Salt, EncryptionAlgorithm.Aes);
        _logger = logger;
    }

    public virtual DbSet<Appointment> Appointments { get; set; }
    public virtual DbSet<Activity> Activities { get; set; }
    public DbSet<ActivityAttendee> ActivityAttendees { get; set; }
    public DbSet<Photo> Photos { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<UserFollowing> UserFollowings { get; set; }



    public virtual DbSet<AppointmentClient> AppointmentClients { get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<ClientDetails> ClientDetails { get; set; }
    public virtual DbSet<Conference> Conferences { get; set; }
    public virtual DbSet<ConferenceHistory> ConferenceHistories { get; set; }
    public virtual DbSet<CouponUser> CouponUsers { get; set; }
    public virtual DbSet<DiscountCoupon> DiscountCoupons { get; set; }
    public virtual DbSet<Doctor> Doctors { get; set; }
    public virtual DbSet<LessonPackage> LessonPackages { get; set; }
    public virtual DbSet<Notification> Notifications { get; set; }
    public virtual DbSet<NotificationRecipient> NotificationRecipients { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<ReferrerDoctor> ReferrerDoctors { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Admin> Admins { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _dbConfiguration.ConnectionString;
        //_logger.LogInformation($"Creating a PostgreSQL connection using:'{connectionString}'");
        optionsBuilder.UseNpgsql(connectionString,
            b => b.MigrationsAssembly("ReHub.DbDataModel"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseEncryption(this._provider);

        // Activities

        modelBuilder.Entity<ActivityAttendee>(x => x.HasKey(aa => new { aa.UserId, aa.ActivityId }));

        modelBuilder.Entity<ActivityAttendee>()
            .HasOne(u => u.AppUser)
            .WithMany(u => u.Activities)
            .HasForeignKey(aa => aa.Id);

        modelBuilder.Entity<ActivityAttendee>()
            .HasOne(u => u.Activity)
            .WithMany(u => u.Attendees)
            .HasForeignKey(aa => aa.ActivityId);

        modelBuilder.Entity<Comment>()
            .HasOne(a => a.Activity)
            .WithMany(c => c.Comments)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserFollowing>(b =>
        {
            b.HasKey(k => new { k.ObserverId, k.TargetId });

            b.HasOne(o => o.Observer)
                .WithMany(f => f.Followings)
                .HasForeignKey(o => o.ObserverId)
                .OnDelete(DeleteBehavior.Cascade);
            b.HasOne(t => t.Target)
                .WithMany(f => f.Followers)
                .HasForeignKey(t => t.TargetId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<User>()
            .HasMany(e => e.NotificationsForUser)
            .WithOne(e => e.Sender)
            .HasForeignKey(e => e.SenderId);

        modelBuilder.Entity<Doctor>()
            .HasMany(e => e.Appointments)
            .WithOne(e => e.Speaker)
            .HasForeignKey(e => e.SpeakerId);

        modelBuilder.Entity<Admin>()
            .HasData(
                new Admin
                {
                    Id = 1,
                    Name = "Mario",
                    Surname = "Z.",
                    DisplayName = "MarioZ",
                    Gender = GenderType.Male,
                    Password = "123456789",
                    Email = "admin@gmail.com",
                    IsVerified = true,
                    Image = "test"
                }
            );
    }

}
