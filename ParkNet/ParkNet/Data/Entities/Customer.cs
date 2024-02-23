using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ParkNet.Data.Entities;

public class Customer
{
    public int Id { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public DateOnly BirthDate { get; set; }
    [Required]
    public int VatNumber { get; set; }
    [Required]
    public string DriversLicenseNumber { get; set; }
    [Required]
    public DateOnly DriversLicenseExpDate { get; set; }
    [Required]
    public string City { get; set; }
    [Required]
    public string Country { get; set; }
    [Required]
    public string CountryCode { get; set; }
    [Required]
    public int PhoneNumber { get; set; }
    [Required]
    public PaymentMethod PaymentMethod { get; set; }
    [Required]
    public string PaymentData { get; set; }
    public string UserId { get; set; }
    public IdentityUser User { get; set; }
    public decimal Balance { get; set; }

    public Customer()
    {
        Transaction transaction = new Transaction();
        Balance = transaction.Balance;
    }
}

public enum PaymentMethod
{
    CreditCard,
    DebitCard,
    PayPal
}
