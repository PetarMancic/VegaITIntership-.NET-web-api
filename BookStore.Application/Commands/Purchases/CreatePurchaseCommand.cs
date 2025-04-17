
using BookStore.Application.DTO;
using MediatR;

namespace BookStore.Application.Commands.Purchases;
public sealed record  CreatePurchaseCommand(List<PurchaseItemDTO> purchaseItemDTO):IRequest<int>;


