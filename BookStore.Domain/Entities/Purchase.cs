
namespace BookStore.Domain.Entities;
public class Purchase
{
    public int Id { get; set;}
    public DateTime PurchaseDate { get; set; }
    public List<PurchaseItem> Items {get; set; }
    
    public float  totalPrice { get; set; }

}

