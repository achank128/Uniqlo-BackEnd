using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Size;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.SizeService
{
    public class SizeService : ISizeService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Size> _sizeRepository;

        public SizeService(IRepositoryBase<Size> sizeRepository, IMapper mapper)
        {
            _sizeRepository = sizeRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<SizeResponse>> Create(CreateSizeRequest request)
        {
            var size = _mapper.Map<Size>(request);
            _sizeRepository.Add(size);

            if (await _sizeRepository.SaveAsync())
            {
                return ApiResponse<SizeResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<SizeResponse>> Delete(int id)
        {
            var size = await _sizeRepository.GetByIdAsync(id);
            if (size == null) throw new NotFoundException(Common.NotFound);

            _sizeRepository.DeleteBy(id);
            if (await _sizeRepository.SaveAsync())
            {
                return ApiResponse<SizeResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<SizeResponse>> Filter(FilterBaseRequest request)
        {
            var sizes = _sizeRepository.GetQueryable();
            var paged = await PagedResponse<Size>.CreateAsync(sizes, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<SizeResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<SizeResponse>>> GetAll()
        {
            var alls = await _sizeRepository.GetAllAsync();
            var response = _mapper.Map<List<SizeResponse>>(alls);
            return ApiResponse<List<SizeResponse>>.Success(response);
        }

        public async Task<ApiResponse<SizeResponse>> GetById(int id)
        {
            var size = await _sizeRepository.GetByIdAsync(id);
            if (size == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<SizeResponse>(size);
            return ApiResponse<SizeResponse>.Success(response);
        }

        public async Task<ApiResponse<SizeResponse>> Update(UpdateSizeRequest request)
        {
            var size = _mapper.Map<Size>(request);
            size.UpdatedDate = DateTime.Now;
            _sizeRepository.Update(size);
            if (await _sizeRepository.SaveAsync())
            {
                return ApiResponse<SizeResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }
    }
}
