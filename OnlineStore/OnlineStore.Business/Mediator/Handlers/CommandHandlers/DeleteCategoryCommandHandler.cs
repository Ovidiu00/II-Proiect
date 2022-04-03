using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
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
         
            var category = await unitOfWork.CategoryRepository.GetCategory(request.Id);
            if (category == null)
            {
                throw new Exception("The category does not exist!");
            }
            unitOfWork.CategoryRepository.DeleteRange(category.SubCategories);
            unitOfWork.CategoryRepository.Delete(category);
            try
            {
                await unitOfWork.Commit();

            }
            catch (Exception ex)
            {

                throw;
            }
            return true;
        }
    }
}