using AutoMapper;
using MediatR;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Requests.Commands;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Business.Mediator.Handlers.CommandHandlers
{
    public class EditProductCommandHandler : IRequestHandler<EditProductCommand, ProductDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EditProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
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
            unitOfWork.ProductRepository.UpdateIfModified<Product>(existingProduct, editedProduct,nameof(productId));

            await unitOfWork.Commit();
            return mapper.Map<ProductDTO>(editedProduct);
        }
    }
}
