using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OnlineStore.Business.Mediator.Requests.Commands;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;

namespace OnlineStore.Business.Mediator.Handlers.CommandHandlers
{
    public class AddSubcategoryToCategoryCommandHandler : IRequestHandler<AddSubcategoryToCategoryCommand, bool>
    {
        private readonly IUnitOfWork unitOfWork;

        public AddSubcategoryToCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddSubcategoryToCategoryCommand request, CancellationToken cancellationToken)
        {
            var (parentId, childId) = request;
            var parentCategory = await unitOfWork.CategoryRepository.GetCategory(parentId);
            if (parentCategory is null)
            {
                throw new Exception("Parent category does not exist!");
            }

            var childCategory = await unitOfWork.CategoryRepository.GetCategory(childId);
            if (childCategory is null)
            {
                throw new Exception("Child category does not exist!");
            }

            if (parentCategory.SubCategories.ToList().Contains(childCategory))
            {
                throw new Exception("This category is already a subcategory for the parent one!");
            }
            parentCategory.SubCategories.ToList().Add(childCategory);
            unitOfWork.CategoryRepository.UpdateIfModified(await unitOfWork.CategoryRepository.GetCategory(parentCategory.Id),parentCategory,nameof(parentCategory.Id));
            await unitOfWork.Commit();
            return true;
        }
    }
}