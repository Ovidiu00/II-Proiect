using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.ViewModels;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.Requests.Commands;
using OnlineStore.Business.Mediator.Requests.Queries;

namespace OnlineStore.API.Controllers
{
    [ApiController]
    [Route("[order]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpPost]
        [Route("~/cart/add-to-cart")]
        public async Task<ActionResult> AddToCart(string userId, CartProductVM cartProductVm)
        {
            try
            {
                var cartProductDto = mapper.Map<CartProductDTO>(cartProductVm);
                await mediator.Send(new AddProductToCartCommand(cartProductDto, userId));
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("~/cart/view-items")]
        public async Task<ActionResult<IEnumerable<CartProductVM>>> ViewCartItems(string userId)
        {
            try
            {
                var cartProductDtos = await mediator.Send(new GetCartProductsByUserIdQuery(userId));
                var cartProductVms = mapper.Map<IEnumerable<CartProductVM>>(cartProductDtos);
                return Ok(cartProductVms);
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("history")]
        public async Task<ActionResult<IEnumerable<OrderVM>>> ViewOrderHistory(int userId)
        {
            throw new NotImplementedException();
        }
    }
}