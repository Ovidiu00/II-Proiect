﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.ViewModels;
using OnlineStore.Business.Mediator.Requests.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public CategoryController(IMediator mediator,IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<CategoryVM>> Categories()
        {
            try
            {
                var categoriesDTO =  await mediator.Send(new GetCategoriesQuery());

                return Ok(mapper.Map<IEnumerable<CategoryVM>>(categoriesDTO));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
