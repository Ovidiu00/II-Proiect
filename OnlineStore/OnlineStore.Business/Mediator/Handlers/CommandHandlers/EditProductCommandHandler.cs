using AutoMapper;
using MediatR;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.HelperCommands;
using OnlineStore.Business.Mediator.Requests.Commands;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Business.Mediator.Handlers.CommandHandlers
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, ProductDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public EditProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper,IMediator mediator)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public async Task<ProductDTO> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var editedproductDTO = request.editProductDTO;
            var productId = request.id;

            var existingProduct = await unitOfWork.ProductRepository.FindSingle(x => x.Id.Equals(productId));
            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }

            var editedProduct = mapper.Map<Product>(editedproductDTO);
            if (editedproductDTO.Photo != null)
            {
                var filePath = await mediator.Send(new SavePhotoCommand(editedproductDTO.Photo));
                editedProduct.FilePath = filePath;
            }
            else
                editedProduct.FilePath = existingProduct.FilePath;

            unitOfWork.ProductRepository.UpdateIfModified(existingProduct, editedProduct,nameof(existingProduct.Id));

            await unitOfWork.Commit();
            return mapper.Map<ProductDTO>(editedProduct);
        }
    }
}
