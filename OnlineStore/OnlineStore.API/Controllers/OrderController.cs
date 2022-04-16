using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.ViewModels;
using OnlineStore.Business.Mediator.Requests.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.API.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public OrderController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        //[HttpPost]
        //[Route("~/cart/add-to-cart")]
        //public async Task<ActionResult> AddToCart(int userId, CartProductVM cartProductVm)
        //{
        //    throw new NotImplementedException();
        //}

        //[HttpGet]
        //[Route("~/cart/view-items")]
        //public async Task<ActionResult<IEnumerable<CartProductVM>>> ViewCartItems(int userId)
        //{
        //    throw new NotImplementedException();
        //}

        [HttpPost]
        public async Task<ActionResult> OrderProducts(string userId)
        {
            await mediator.Send(new OrderCommand(userId));
            return Ok();
        }
    }
}