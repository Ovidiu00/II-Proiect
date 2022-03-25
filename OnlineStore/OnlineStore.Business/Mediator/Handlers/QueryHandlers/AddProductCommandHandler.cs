using AutoMapper;
using MediatR;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Requests.Queries;
using OnlineStore.DataAccess.Models.Entities;
using OnlineStore.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineStore.Business.Mediator.Handlers.QueryHandlers
{
//    public class AddProductCommandHandler : IRequestHandler<AddProductCommandQuery, AddProductDTO>
//    {
//        private readonly IUnitOfWork unitOfWork;
//        private readonly IMapper mapper;

//        public AddProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
//        {
//            this.unitOfWork = unitOfWork;
//            this.mapper = mapper;
//        }

//        public async Task<AddProductDTO> Handle(AddProductCommandQuery request, CancellationToken cancellationToken)
//        {
//            Category category = await unitOfWork.CategoryRepository.FindSingle(x => x.Id == request.id);
//            return mapper.Map<AddProductDTO>(category);
//        }
//    }
}
