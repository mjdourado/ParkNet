using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ParkNet.Data.Entities;

public class Transaction
{
    [Key]
    public int Id { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
    public float Balance { get; set; }
    public float InitBalance { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public TransactionType Type { get; set; }
    [Required]
    public float FinalBalance { get; set; }
}

public enum TransactionType
{
    Deposit,
    Withdrawal
}