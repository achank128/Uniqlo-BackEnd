using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.RegionService
{
    public class RegionService : IRegionService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Province> _provinceRepository;
        private readonly IRepositoryBase<District> _districtRepository;
        private readonly IRepositoryBase<Ward> _wardRepository;

        public RegionService(IMapper mapper, 
            IRepositoryBase<Province> provinceRepository, 
            IRepositoryBase<District> districtRepository, 
            IRepositoryBase<Ward> wardRepository)
        {
            _mapper = mapper;
            _provinceRepository = provinceRepository;
            _districtRepository = districtRepository;
            _wardRepository = wardRepository;
        }

        public async Task<ApiResponse<List<DistrictResponse>>> GetAllDistricts()
        {
            var alls = await _provinceRepository.GetAllAsync();
            var response = _mapper.Map<List<DistrictResponse>>(alls);
            return ApiResponse<List<DistrictResponse>>.Success(response);
        }

        public async Task<ApiResponse<List<ProvinceResponse>>> GetAllProvinces()
        {
            var alls = await _provinceRepository.GetAllAsync();
            var response = _mapper.Map<List<ProvinceResponse>>(alls);
            return ApiResponse<List<ProvinceResponse>>.Success(response);
        }

        public async Task<ApiResponse<List<WardResponse>>> GetAllWards()
        {
            var alls = await _provinceRepository.GetAllAsync();
            var response = _mapper.Map<List<WardResponse>>(alls);
            return ApiResponse<List<WardResponse>>.Success(response);
        }

        public async Task<ApiResponse<List<DistrictResponse>>> GetDistrictsByProvice(string provinceCode)
        {
            var districts = await _districtRepository.GetBy(s => s.ProvinceCode == provinceCode).ToListAsync();
            var response = _mapper.Map<List<DistrictResponse>>(districts);
            return ApiResponse<List<DistrictResponse>>.Success(response);
        }

        public async Task<ApiResponse<List<WardResponse>>> GetWardsByDistrict(string districtCode)
        {
            var wards = await _wardRepository.GetBy(s => s.DistrictCode == districtCode).ToListAsync();
            var response = _mapper.Map<List<WardResponse>>(wards);
            return ApiResponse<List<WardResponse>>.Success(response);
        }
    }
}
