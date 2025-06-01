
public class Quote
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public int ContractorId { get; set; }
    public decimal QuotePrice { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    public LargeProject Project { get; set; }
    public User Contractor { get; set; }
}