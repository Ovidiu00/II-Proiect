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

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductVM>> GetProductById(int id)
        {
            if (id <= 0)
                return BadRequest();

            var result = mapper.Map<ProductVM>(await mediator.Send(new GetProductByIdQuery(id)));

            if (result == null)
                return NotFound();

            return Ok(result);

        }

        [HttpGet]
        [Route("categories/{categoryId}/products")]
        public async Task<ActionResult<IEnumerable<ProductVM>>> GetProductsByCategory(int categoryId)
        {
            if (categoryId <= 0)
                return BadRequest();

            var result = mapper.Map<IEnumerable<ProductVM>>(await mediator.Send(new GetProductsByCategoryQuery(categoryId)));

            if (result == null)
                return NotFound();

            return Ok(result);

        }
    }
}
