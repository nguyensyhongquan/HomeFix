using System;

public class SmallJob
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int? TechnicianId { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public DateTime RequestedAt { get; set; }
    public string Status { get; set; } // Pending, Assigned, InProgress, Completed, Cancelled
    public decimal Price { get; set; }
    public bool IsPaid { get; set; }
    public DateTime? CompletedAt { get; set; }

    public User Customer { get; set; }
    public User Technician { get; set; }
}