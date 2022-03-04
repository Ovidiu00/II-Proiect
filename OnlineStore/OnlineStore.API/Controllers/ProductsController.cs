using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.ViewModels;
using OnlineStore.Business.Mediator.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.API.Controllers
{
    [Route("products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public ProductsController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        
        [HttpGet("popular-products")]
        public async Task<ActionResult<IEnumerable<PopularProductVM>>> PopularProducts(int count)
        {
            try
            {
                var popularProductsDTO = await mediator.Send(new GetPopularProductsQuery(count));
                var popularProductsVM = mapper.Map<IEnumerable<PopularProductVM>>(popularProductsDTO);

                return Ok(popularProductsVM);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        public async Task<ActionResult<IEnumerable<RecentProductVM>>> RecentProducts(int count)
        {
            throw new NotImplementedException();
        }
    }
}
