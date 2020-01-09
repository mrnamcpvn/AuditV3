using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Audit_API._Repositories.Interface;
using Audit_API._Services.Interface;
using Audit_API.DTOs;
using Audit_API.Helpers;
using Audit_API.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Audit_API._Services.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repo;
        private readonly MapperConfiguration _configMapper;
        public CategoryService(ICategoryRepository repo, IMapper mapper, MapperConfiguration config)
        {
            _configMapper = config;
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<bool> Add(CategoryDto model)
        {
            var category = _mapper.Map<Category>(model);
            _repo.Add(category);
            return await _repo.SaveAll();
        }

        public async Task<bool> ChangeStatus(object id)
        {
            var category = _repo.FindById(id);
            category.active = !category.active;
            var categoryFromRepo = _mapper.Map<Category>(category);
            _repo.Update(categoryFromRepo);
            return await _repo.SaveAll();
        }

        public async Task<bool> CheckKindNameExists(string name)
        {
            return await _repo.CheckCategoryNameExists(name);
        }

        public async Task<bool> Delete(object id)
        {
            _repo.Remove(id);
            return await _repo.SaveAll();
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            return await _repo.FindAll().ProjectTo<CategoryDto>(_configMapper).ToListAsync();
        }

        public CategoryDto GetById(object id)
        {
            return _mapper.Map<Category, CategoryDto>(_repo.FindById(id));
        }

        public async Task<PagedList<CategoryDto>> GetWithPaginations(PaginationParams param)
        {
            var lists = _repo.FindAll().ProjectTo<CategoryDto>(_configMapper).OrderByDescending(x => x.id);
            return await PagedList<CategoryDto>.CreateAsync(lists, param.PageNumber, param.PageSize);
        }

        public async Task<bool> Update(CategoryDto model)
        {
            var category = _mapper.Map<Category>(model);
            _repo.Update(category);
            return await _repo.SaveAll();
        }
    }
}