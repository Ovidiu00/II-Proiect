using MediatR;
using OnlineStore.Business.Mediator.Requests.Commands;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Business.Mediator.Handlers.CommandHandlers
{
    public class OrderCommandHandler : IRequestHandler<OrderCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;
        public OrderCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(OrderCommand request, CancellationToken cancellationToken)
        {
            IEnumerable<UserProduct> productsInCart = await unitOfWork.OrderRepository.GetProductsInCart(request.UserId);

            Order newOrder = new Order()
            {
                UserId = request.UserId,
                DateOfOrder = DateTime.Now
            };
            var productsToBeOrdered = productsInCart.Select(x => new OrderProduct()
            {
                Order = newOrder,
                ProductId = x.ProductId,
                Quantity = x.Quantity
            });

            unitOfWork.OrderRepository.Add(newOrder);
            newOrder.Products = productsToBeOrdered.ToList();
            unitOfWork.OrderRepository.RemoveItemsFromCart(request.UserId);

            await unitOfWork.Commit();

            return true;
        }
    }
}
