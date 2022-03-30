using AutoMapper;
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

        public async Task<ActionResult<CategoryVM>> AddCategory(AddCategoryVM addCategoryVm)
        {
            try
            {
                var addCategoryDto = mapper.Map<AddCategoryDTO>(addCategoryVm);
                var categoryDto = await mediator.Send(new AddCategoryCommand(addCategoryDto));
                return CreatedAtAction(nameof(GetCategoryById), categoryDto.Id);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryVM>> EditCategory(EditCategoryVM editCategoryVm, int id)
        {
            try
            {
                var editCategoryDto = mapper.Map<EditCategoryDTO>(editCategoryVm);
                var editedCategoryDto = await mediator.Send(new EditCategoryCommand(editCategoryDto, id));
                return CreatedAtAction(nameof(GetCategoryById), editedCategoryDto.Id);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCategory(int id)
        {
            try
            {
                return await mediator.Send(new DeleteCategoryCommand(id));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{parentId}/{childId}")]
        public async Task<ActionResult<bool>> AddSubcategoryToCategory(int parentId, int childId)
        {
            try
            {
                return await mediator.Send(new AddSubcategoryToCategoryCommand(parentId, childId));
            }
            catch (Exception e)
            {
                return StatusCode(500);
            }
        }

}
}
