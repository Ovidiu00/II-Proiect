using MediatR;
using OnlineStore.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Business.Mediator.Requests.Queries
{
    public record GetProductByIdQuery(int id) : IRequest<ProductDTO>;

}
