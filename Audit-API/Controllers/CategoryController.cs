using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Audit_API._Services.Interface;
using Audit_API.Data;
using Audit_API.DTOs;
using Audit_API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Audit_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService, DataContext context, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet(Name = "GetCategories")]
        public async Task<IActionResult> GetCategories([FromQuery]PaginationParams Param)
        {
            var categories = await _categoryService.GetWithPaginations(Param);
            Response.AddPagination(categories.CurrentPage, categories.PageSize, categories.TotalCount, categories.TotalPages);
            return Ok(categories);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var category = _categoryService.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryDto categoryDto)
        {
            if (await _categoryService.CheckKindNameExists(categoryDto.name))
                return BadRequest("Kind name already exists!");
            var username = User.FindFirst(ClaimTypes.Name).Value;
            categoryDto.updated_by = username;
            if (await _categoryService.Add(categoryDto))
            {
                return CreatedAtRoute("GetKinds", new { });
            }

            throw new Exception("Creating the category failed on save");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(CategoryDto categoryDto)
        {
            if (await _categoryService.Update(categoryDto))
                return NoContent();
            return BadRequest($"Updating kind {categoryDto.name} failed on save");
        }

        [HttpPost("{id}/changeStatus")]
        public async Task<IActionResult> ChangeStatus(int id)
        {
            if (await _categoryService.ChangeStatus(id))
                return Ok();
            return BadRequest("Failed to change active");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (await _categoryService.Delete(id))
                return NoContent();
            throw new Exception("Error deleting the category");
        }

    }
}