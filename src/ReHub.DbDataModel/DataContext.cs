using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ReHub.DbDataModel.Models;

namespace ReHub.DbDataModel
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration _configuration;
        protected readonly ILogger _logger;

        public DataContext(IConfiguration configuration, DbContextOptions options) : base(options)
        {
            _configuration = configuration;
           // _logger = logger;
        }

        public virtual DbSet<Appointment> Appointments { get; set; }
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
    }
}
