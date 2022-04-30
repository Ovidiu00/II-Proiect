using MediatR;
using OnlineStore.Business.Mediator.Requests.Commands;
using OnlineStore.DataAccess.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Business.Mediator.Handlers.CommandHandlers
{
    class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var product = await unitOfWork.ProductRepository.FindSingle(x => x.Id.Equals(request.id));
                if (product == null)
                {
                    throw new Exception("Product not found");
                }
                unitOfWork.ProductRepository.Delete(product);
                await unitOfWork.Commit();
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }
    }
}
