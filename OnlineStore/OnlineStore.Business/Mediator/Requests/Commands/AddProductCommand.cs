using MediatR;
using OnlineStore.Business.DTOs;

namespace OnlineStore.Business.Mediator.Requests.Commands
{
    public record AddProductCommand(AddProductDTO addProductDTO, int categoryId) : IRequest<ProductDTO>;
}
