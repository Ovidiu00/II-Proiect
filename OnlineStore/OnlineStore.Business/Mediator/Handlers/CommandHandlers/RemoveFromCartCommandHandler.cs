using MediatR;
using OnlineStore.Business.Mediator.Requests.Commands;
using OnlineStore.DataAccess.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Business.Mediator.Handlers.CommandHandlers
{
    public class RemoveFromCartCommandHandler : IRequestHandler<RemoveFromCartCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public RemoveFromCartCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
        {
            var cartItems = await unitOfWork.OrderRepository.GetProductsInCart(request.currentUserId);
            var cartItemToBeRemoved = cartItems.FirstOrDefault(x => x.ProductId == request.id);

            unitOfWork.OrderRepository.RemoveItemFromCart(cartItemToBeRemoved);

            return true;
        }
    }
}
