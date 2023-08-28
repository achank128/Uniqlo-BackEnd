using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Unit;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.UnitService
{
    public interface IUnitService
    {
        Task<ApiResponse<UnitResponse>> Create(CreateUnitRequest request);
        Task<PagedResponse<UnitResponse>> GetAll(FilterBaseRequest request);
        Task<ApiResponse<UnitResponse>> GetById(int id);
        Task<ApiResponse<UnitResponse>> Update(UpdateUnitRequest request);
        Task<ApiResponse<UnitResponse>> Delete(int id);
    }
}
