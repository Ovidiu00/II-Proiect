using AutoMapper;
using MediatR;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.HelperCommands;
using OnlineStore.Business.Mediator.Requests.Commands;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Business.Mediator.Handlers.CommandHandlers
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ProductDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        public AddProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<ProductDTO> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            Category category = await unitOfWork.CategoryRepository.FindSingle(x => x.Id == command.categroryId);
            if (category == null)
            {
                throw new Exception("There is no product at this category");
            }
            var product = mapper.Map<Product>(command.addProductDTO);
            product.FilePath = await mediator.Send(new SavePhotoCommand(command.addProductDTO.Photo));
            product.InsertedDate = DateTime.Now;

            product.Categories.Add(category);
            unitOfWork.ProductRepository.Add(product);

            await unitOfWork.Commit(); 
            return  mapper.Map<ProductDTO>(product);
        }

    }
}
