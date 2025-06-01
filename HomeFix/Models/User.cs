
public class User
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Phone { get; set; }
    public int Role { get; set; } // 0=Customer, 1=Technician, 2=Contractor, 3=Admin
    public bool IsVerified { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ICollection<SmallJob> SmallJobsRequested { get; set; }
    public ICollection<SmallJob> SmallJobsTaken { get; set; }
    public ICollection<LargeProject> LargeProjectsRequested { get; set; }
    public ICollection<LargeProject> LargeProjectsHandled { get; set; }
    public ICollection<Payment> Payments { get; set; }
    public ICollection<Review> ReviewsGiven { get; set; }
    public ICollection<Review> ReviewsReceived { get; set; }
    public ICollection<Notification> Notifications { get; set; }
}