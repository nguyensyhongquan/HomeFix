using System;

public class Review
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int TargetUserId { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }

    public User User { get; set; }
    public User TargetUser { get; set; }
}