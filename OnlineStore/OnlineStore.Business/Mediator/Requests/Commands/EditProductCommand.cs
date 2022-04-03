using MediatR;
using OnlineStore.Business.DTOs;

namespace OnlineStore.Business.Mediator.Requests.Commands
{
    public record EditProductCommand(EditProductDTO editProductDTO, int id) : IRequest<ProductDTO>;

}
