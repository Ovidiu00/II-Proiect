using MediatR;
using OnlineStore.Business.DTOs;

namespace OnlineStore.Business.Mediator.Requests.Commands
{
    public record AddProductToCartCommand(CartProductDTO CartProductDto, string UserId) : IRequest<bool>;
}