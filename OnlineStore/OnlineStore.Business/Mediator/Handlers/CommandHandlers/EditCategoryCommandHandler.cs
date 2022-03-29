using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Requests.Commands;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;

namespace OnlineStore.Business.Mediator.Handlers.CommandHandlers
{
    public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, CategoryDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        
        public async Task<CategoryDTO> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var editedCategoryDto = request.EditCategoryDto;
                var categoryId = request.id;
                var existingCategory = await unitOfWork.CategoryRepository.FindSingle(x => x.Id.Equals(categoryId));
                if (existingCategory == null)
                {
                    throw new Exception("Category not found");
                }

                var editedCategory = mapper.Map<Category>(editedCategoryDto);
                unitOfWork.CategoryRepository.UpdateIfModified(existingCategory, editedCategory, nameof(categoryId));
                await unitOfWork.Commit();
                return mapper.Map<CategoryDTO>(existingCategory);
        }
    }
}