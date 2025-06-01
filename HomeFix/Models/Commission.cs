using System;

public class Commission
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public int ContractorId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaidDate { get; set; }

    public LargeProject Project { get; set; }
    public User Contractor { get; set; }
}