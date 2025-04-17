
namespace BookStore.Domain.Entities;
public class PurchaseItem
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int Quantity { get; set; }
    public decimal  Price { get; set; }
    public int PurchaseId { get; set; }
    public Book Book { get; set; }
    public Purchase Purchase {get; set; }
}

