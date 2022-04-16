using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.ViewModels;

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
        public async Task<ActionResult> AddToCart(int userId, CartProductVM cartProductVm)
        {
            throw new NotImplementedException();
        }
        
        [HttpGet]
        [Route("~/cart/view-items")]
        public async Task<ActionResult<IEnumerable<CartProductVM>>> ViewCartItems(int userId)
        {
            throw new NotImplementedException();
        }
    }
}