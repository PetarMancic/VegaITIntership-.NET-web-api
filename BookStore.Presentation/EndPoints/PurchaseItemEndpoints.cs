using BookStore.Application.Commands.Purchases;
using BookStore.Application.DTO;
using MediatR;

namespace BookStore.Presentation.EndPoints;
public static  class PurchaseItemEndpoints
{
    public const string Base = "api/pruchaseItem";
    public static void MapPurchaseItemEndPoints( this WebApplication app)
    {
        
        var purchaseItemGroup= app.MapGroup(Base);

        purchaseItemGroup.MapPost("",AddNewPruchaseItem);
    }

    private static async Task<IResult> AddNewPruchaseItem(List<PurchaseItemDTO> dto, IMediator mediator)
    {
        var result= await mediator.Send( new CreatePurchaseCommand(dto));
        return Results.Ok(result);
    }
}
