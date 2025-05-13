using BookStore.Application.MappingExtensions.PurchaseItemExtension;
using BookStore.Domain.Entities;
using BookStore.Domain.Interfaces;
using MediatR;

namespace BookStore.Application.Commands.Purchases;
public class CreatePurchaseCommandHandler : IRequestHandler<CreatePurchaseCommand, int>
{
    private readonly IGenericRepository<Purchase> _purchaseRepo;
    private readonly IGenericRepository<Book> _bookRepo;

    public CreatePurchaseCommandHandler(IGenericRepository<Purchase> purchaseRepo,
    IGenericRepository<Book> bookRepo)
    {
        _purchaseRepo= purchaseRepo;
        _bookRepo= bookRepo;
    }

    public async Task<int> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
    {
        // var purchase = new Purchase
        //     {
        //         PurchaseDate = DateTime.UtcNow,
        //         Items = new List<PurchaseItem>()
        //     };

        //     decimal totalPrice = 0;

        //     foreach (var itemDto in request.purchaseItemDTO)
        //     {
        //         var book = await _bookRepo.GetByIdAsync(itemDto.bookId);
               

        //         var itemPrice = book.Price * itemDto.Quantity;

        //         var purchaseItem = new PurchaseItem
        //         {
        //             BookId = book.Id,
        //             Quantity = itemDto.Quantity,
        //             Price = (decimal)itemPrice
        //         };

        //         purchase.Items.Add(purchaseItem);
        //         totalPrice += itemPrice;
        //     }

        //     purchase.totalPrice = totalPrice;
        //     await _purchaseRepo.AddAsync(purchase);
            
            return 5;

    }

    // public async Task<int> Handle(CreatePurchaseCommand request, CancellationToken cancellationToken)
    // {
    //     var purchase= request.purchaseItemDTO.ToPurchase();
    //      var purchaseItems = new List<PurchaseItem>();

    //     foreach( var p in purchase.Items)
    //     {

    //     }

    //   var purchase= await _purchaseRepo.GetByIdWithIncludesAsync()
    //   float totalPrice=0;
    //   foreach( var items in purchase.Items )
    //   {
    //     totalPrice+=items.Price;
    //   }
    //     purchase.totalPrice=totalPrice;


    //     await _purchaseRepo.AddAsync(purchase);
    //     return purchase.Id;
    //}
}

