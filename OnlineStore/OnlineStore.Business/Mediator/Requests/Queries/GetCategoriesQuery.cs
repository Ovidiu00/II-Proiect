using MediatR;
using OnlineStore.Business.DTOs;
using System.Collections.Generic;

namespace OnlineStore.Business.Mediator.Requests.Queries
{
    public class GetCategoriesQuery : IRequest<IEnumerable<CategoryDTO>>
    {
       
    }
}
