using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.RegionService
{
    public interface IRegionService
    {
        Task<ApiResponse<List<ProvinceResponse>>> GetAllProvinces();
        Task<ApiResponse<List<DistrictResponse>>> GetAllDistricts();
        Task<ApiResponse<List<WardResponse>>> GetAllWards();
        Task<ApiResponse<List<DistrictResponse>>> GetDistrictsByProvice(string provinceCode);
        Task<ApiResponse<List<WardResponse>>> GetWardsByDistrict(string districtCode);

    }
}
