using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeFix.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SmallJob> SmallJobs { get; set; }
        public DbSet<LargeProject> LargeProjects { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Commission> Commissions { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Thay YOUR_SERVER bằng tên server thực tế của bạn
                optionsBuilder.UseSqlServer("Server=ADMIN-PC\\MAY1;Database=HomeFixDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // LargeProject - Customer (User)
            modelBuilder.Entity<LargeProject>()
                .HasOne(lp => lp.Customer)
                .WithMany(u => u.LargeProjectsRequested)
                .HasForeignKey(lp => lp.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // LargeProject - Contractor (User)
            modelBuilder.Entity<LargeProject>()
                .HasOne(lp => lp.Contractor)
                .WithMany(u => u.LargeProjectsHandled)
                .HasForeignKey(lp => lp.ContractorId)
                .OnDelete(DeleteBehavior.Restrict);

            // SmallJob - Customer (User)
            modelBuilder.Entity<SmallJob>()
                .HasOne(sj => sj.Customer)
                .WithMany(u => u.SmallJobsRequested)
                .HasForeignKey(sj => sj.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // SmallJob - Technician (User)
            modelBuilder.Entity<SmallJob>()
                .HasOne(sj => sj.Technician)
                .WithMany(u => u.SmallJobsTaken)
                .HasForeignKey(sj => sj.TechnicianId)
                .OnDelete(DeleteBehavior.Restrict);

            // Quote - LargeProject
            modelBuilder.Entity<Quote>()
                .HasOne(q => q.Project)
                .WithMany(lp => lp.Quotes)
                .HasForeignKey(q => q.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Quote - Contractor (User)
            modelBuilder.Entity<Quote>()
                .HasOne(q => q.Contractor)
                .WithMany()
                .HasForeignKey(q => q.ContractorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Payment - User
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.User)
                .WithMany(u => u.Payments)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Commission - LargeProject
            modelBuilder.Entity<Commission>()
                .HasOne(c => c.Project)
                .WithOne(lp => lp.Commission)
                .HasForeignKey<Commission>(c => c.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            // Commission - Contractor (User)
            modelBuilder.Entity<Commission>()
                .HasOne(c => c.Contractor)
                .WithMany()
                .HasForeignKey(c => c.ContractorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Review - User (người đánh giá)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.ReviewsGiven)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Review - TargetUser (người được đánh giá)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.TargetUser)
                .WithMany(u => u.ReviewsReceived)
                .HasForeignKey(r => r.TargetUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // Notification - User
            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
