using MediatR;
using OnlineStore.Business.DTOs;

namespace OnlineStore.Business.Mediator.Requests.Commands
{
    public record AddProductToCartCommand(CartProductDTO CartProductDto, int UserId) : IRequest<bool>;
}