using MediatR;
using OnlineStore.Business.Mediator.Requests.Commands;
using OnlineStore.DataAccess.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Business.Mediator.Handlers.CommandHandlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await unitOfWork.CategoryRepository.FindSingle(x => x.Id.Equals(request.Id));
            if (category == null)
            {
                throw new Exception("The category does not exist!");
            }
            unitOfWork.CategoryRepository.Delete(category);

            await unitOfWork.Commit();
            return true;
        }
    }
}