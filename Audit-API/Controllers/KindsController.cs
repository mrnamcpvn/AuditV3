using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Audit_API._Services.Interface;
using Audit_API.Data;
using Audit_API.DTOs;
using Audit_API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Audit_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class KindsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IKindService _kindService;

        public KindsController(IKindService kindService, DataContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _kindService = kindService;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("{id}", Name = "GetKind")]
        public IActionResult GetKind(int id)
        {
            var kind = _kindService.GetById(id);
            return Ok(kind);
        }

        [HttpGet(Name = "GetKinds")]
        public async Task<IActionResult> GetKinds([FromQuery]PaginationParams Param)
        {
            var kinds = await _kindService.GetWithPaginations(Param);
            Response.AddPagination(kinds.CurrentPage, kinds.PageSize, kinds.TotalCount, kinds.TotalPages);
            return Ok(kinds);
        }

        [HttpGet("all", Name = "GetAllKinds")]
        public async Task<IActionResult> GetAllKinds()
        {
            var kinds = await _kindService.GetAllAsync();
            return Ok(kinds);
        }

        [HttpPost]
        public async Task<IActionResult> CreateKind(KindDto kindDto)
        {
            if (await _kindService.CheckKindNameExists(kindDto.name))
                return BadRequest("Kind name already exists!");
            var username = User.FindFirst(ClaimTypes.Name).Value;
            kindDto.updated_by = username;
            if (await _kindService.Add(kindDto))
            {
                return CreatedAtRoute("GetKinds", new { });
            }

            throw new Exception("Creating the kind failed on save");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateKind(KindDto kindDto)
        {
            if (await _kindService.Update(kindDto))
                return NoContent();
            return BadRequest($"Updating kind {kindDto.name} failed on save");
        }

        [HttpPost("{id}/changeStatus")]
        public async Task<IActionResult> ChangeStatus(int id)
        {
            if (await _kindService.ChangeStatus(id))
                return Ok();
            return BadRequest("Failed to change active");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKind(int id)
        {
            if (await _kindService.Delete(id))
                return NoContent();
            throw new Exception("Error deleting the kind");
        }
    }
}