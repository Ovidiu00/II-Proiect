using System.Collections.Generic;
using MediatR;
using OnlineStore.Business.DTOs;

namespace OnlineStore.Business.Mediator.Requests.Queries
{
    public record GetCartProductsByUserIdQuery(string UserId) : IRequest<IEnumerable<CartProductDTO>>;
}