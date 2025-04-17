
namespace BookStore.Domain.Entities;
public class PurchaseItem
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int Quantity { get; set; }

    public float Price { get; set; }

    public int PurchaseId { get; set; }
    public Purchase Purchase {get; set; }
}

