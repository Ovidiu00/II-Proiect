using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.HelperCommands;
using OnlineStore.Business.Mediator.Requests.Commands;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;

namespace OnlineStore.Business.Mediator.Handlers.CommandHandlers
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, CategoryDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public AddCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<CategoryDTO> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var requestAddCategoryDto = request.AddCategoryDto;
            var filePath = await mediator.Send(new SavePhotoCommand(requestAddCategoryDto.Photo));
            var category = mapper.Map<Category>(request.AddCategoryDto);
            category.FilePath = filePath;
            unitOfWork.CategoryRepository.Add(category);
            await unitOfWork.Commit();
            return mapper.Map<CategoryDTO>(category);
        }
    }
}