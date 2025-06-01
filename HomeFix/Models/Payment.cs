using System;

public class Payment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int? SmallJobId { get; set; }
    public int? LargeProjectId { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; } // Wallet, Card, Cash, etc.
    public string Status { get; set; } // Pending, Completed, Failed
    public DateTime PaidAt { get; set; }

    public User User { get; set; }
}