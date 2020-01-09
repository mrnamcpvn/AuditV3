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
    public class KindService : IKindService
    {
        private readonly IMapper _mapper;
        private readonly IKindRepository _repoKind;
        private readonly MapperConfiguration _configMapper;
        private readonly ICategoryRepository _repoCate;
        public KindService(IKindRepository repoKind, ICategoryRepository repoCate, IMapper mapper, MapperConfiguration config)
        {
            _repoCate = repoCate;
            _configMapper = config;
            _repoKind = repoKind;
            _mapper = mapper;
        }

        //Lấy Kind theo ID
        public KindDto GetById(object id)
        {
            return _mapper.Map<Kind, KindDto>(_repoKind.FindById(id));
        }
        public async Task<bool> Add(KindDto model)
        {
            var kind = _mapper.Map<Kind>(model);
            _repoKind.Add(kind);
            return await _repoKind.SaveAll();
        }

        public async Task<bool> Update(KindDto model)
        {
            var kindFromRepo = _mapper.Map<Kind>(model);
            // _mapper.Map(model, kindFromRepo);
            _repoKind.Update(kindFromRepo);
            return await _repoKind.SaveAll();
        }

        //Kiểm tra xem tên của Kind đã tồn tại hay chưa
        public async Task<bool> CheckKindNameExists(string name)
        {
            return await _repoKind.CheckKindNameExists(name);
        }

        //Lấy danh sách Kinds bằng phân trang
        public async Task<PagedList<KindDto>> GetWithPaginations(PaginationParams param)
        {
            var lists = _repoKind.FindAll().ProjectTo<KindDto>(_configMapper).OrderByDescending(x => x.id);
            return await PagedList<KindDto>.CreateAsync(lists, param.PageNumber, param.PageSize);
        }

        //Lấy toàn bộ danh sách Kinds
        public async Task<List<KindDto>> GetAllAsync()
        {
            return await _repoKind.FindAll().ProjectTo<KindDto>(_configMapper).Where(x => x.active == true).OrderByDescending(x => x.id).ToListAsync();
        }

        //Thay đổi status của Kind
        public async Task<bool> ChangeStatus(object id)
        {
            var kind = _repoKind.FindById(id);
            kind.active = !kind.active;
            var kindFromRepo = _mapper.Map<Kind>(kind);
            _repoKind.Update(kindFromRepo);
            return await _repoKind.SaveAll();
        }

        public async Task<bool> Delete(object id)
        {
            var kind = _repoKind.FindById(id);
            var listCategory = _repoCate.GetByKindId(kind.id);
            _repoCate.RemoveMultiple(listCategory);
            _repoKind.Remove(id);
            return await _repoKind.SaveAll();
        }
    }
}