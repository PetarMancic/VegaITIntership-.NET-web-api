using BookStore.Application.DTO;
using BookStore.Domain.Entities;

namespace BookStore.Application.MappingExtensions.PurchaseItemExtension;

public  static class PurchaseItemExtension
{
    public static Purchase ToPurchase( this List<PurchaseItemDTO> items)
    {
         return new Purchase
        {
            PurchaseDate = DateTime.UtcNow,
            Items = items.Select(i => new PurchaseItem
        {
            BookId = i.bookId,
            Quantity = i.Quantity,
            
            
        }).ToList()
        };
    }
}
