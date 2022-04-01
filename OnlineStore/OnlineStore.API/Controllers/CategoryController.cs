﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineStore.Business.DTOs;
using OnlineStore.Business.Mediator.HelperCommands;
using OnlineStore.Business.Mediator.Requests.Commands;
using OnlineStore.Business.Mediator.Requests.Queries;

namespace OnlineStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public CategoryController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryVM>>> Categories()
        {
            try
            {
                var result = await mediator.Send(new GetCategoriesQuery());
                var resultAsVM = mapper.Map<IEnumerable<CategoryVM>>(result);
                return Ok(resultAsVM);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryVM>> GetCategoryById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest();
                }

                var categoryDto = await mediator.Send(new GetCategoryByIdQuery(id));
                if (categoryDto is null)
                {
                    return NotFound();
                }
                return Ok(mapper.Map<CategoryVM>(categoryDto));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        public async Task<ActionResult> AddCategory(AddCategoryVM addCategoryVm)
        {
            try
            {
                if (addCategoryVm == null)
                    return BadRequest();

                var addCategoryDto = mapper.Map<AddCategoryDTO>(addCategoryVm);
                var categoryDto = await mediator.Send(new AddCategoryCommand(addCategoryDto));
                var categoryVm = mapper.Map<CategoryVM>(categoryDto);
                return CreatedAtAction(nameof(GetCategoryById), new {Id = categoryVm.Id });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> EditCategory(EditCategoryVM editCategoryVm, int id)
        {
            if (id <= 0 || editCategoryVm == null)
                return BadRequest();
            try
            {
                var editCategoryDto = mapper.Map<EditCategoryDTO>(editCategoryVm);
                var editedCategoryDto = await mediator.Send(new EditCategoryCommand(editCategoryDto, id));
                var categoryVm = mapper.Map<CategoryVM>(editedCategoryDto);
                return CreatedAtAction(nameof(GetCategoryById), categoryVm.Id);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest();

                if (await mediator.Send(new DeleteCategoryCommand(id)))
                    return NoContent();

                return StatusCode(500);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

    }
}
