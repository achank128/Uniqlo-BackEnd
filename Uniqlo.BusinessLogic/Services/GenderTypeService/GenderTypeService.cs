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
using Uniqlo.Models.RequestModels.GenderType;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.GenderTypeService
{
    public class GenderTypeService : IGenderTypeService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<GenderType> _genderTypeRepository;

        public GenderTypeService(IRepositoryBase<GenderType> genderTypeRepository, IMapper mapper)
        {
            _genderTypeRepository = genderTypeRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<GenderTypeResponse>> Create(CreateGenderTypeRequest request)
        {
            var genderType = _mapper.Map<GenderType>(request);
            _genderTypeRepository.Add(genderType);

            if (await _genderTypeRepository.SaveAsync())
            {
                return ApiResponse<GenderTypeResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<GenderTypeResponse>> Delete(int id)
        {
            var genderType = await _genderTypeRepository.GetByIdAsync(id);
            if (genderType == null) throw new NotFoundException(Common.NotFound);

            _genderTypeRepository.DeleteBy(id);
            if (await _genderTypeRepository.SaveAsync())
            {
                return ApiResponse<GenderTypeResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<GenderTypeResponse>> Filter(FilterBaseRequest request)
        {
            var genderTypes = _genderTypeRepository.GetQueryable();
            var paged = await PagedResponse<GenderType>.CreateAsync(genderTypes, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<GenderTypeResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<GenderTypeResponse>>> GetAll()
        {
            var alls = await _genderTypeRepository.GetAllAsync();
            var response = _mapper.Map<List<GenderTypeResponse>>(alls);
            return ApiResponse<List<GenderTypeResponse>>.Success(response);
        }

        public async Task<ApiResponse<GenderTypeResponse>> GetById(int id)
        {
            var genderType = await _genderTypeRepository.GetByIdAsync(id);
            if (genderType == null) throw new NotFoundException(Common.NotFound);
            var response = _mapper.Map<GenderTypeResponse>(genderType);
            return ApiResponse<GenderTypeResponse>.Success(response);
        }

        public async Task<ApiResponse<GenderTypeResponse>> Update(UpdateGenderTypeRequest request)
        {
            var genderType = _mapper.Map<GenderType>(request);
            genderType.UpdatedDate = DateTime.Now;
            _genderTypeRepository.Update(genderType);
            if (await _genderTypeRepository.SaveAsync())
            {
                return ApiResponse<GenderTypeResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }
    }
}
