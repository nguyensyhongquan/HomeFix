public class LargeProject
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int? ContractorId { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Status { get; set; } // WaitingForQuote, InProgress, Completed, Cancelled
    public decimal Budget { get; set; }
    public bool ContractSigned { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }

    public User Customer { get; set; }
    public User Contractor { get; set; }
    public ICollection<Quote> Quotes { get; set; }
    public Commission Commission { get; set; }
}