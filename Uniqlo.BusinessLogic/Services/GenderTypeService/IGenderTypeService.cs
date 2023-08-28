using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.GenderType;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.GenderTypeService
{
    public interface IGenderTypeService
    {
        Task<ApiResponse<GenderTypeResponse>> Create(CreateGenderTypeRequest request);
        Task<PagedResponse<GenderTypeResponse>> GetAll(FilterBaseRequest request);
        Task<ApiResponse<GenderTypeResponse>> GetById(int id);
        Task<ApiResponse<GenderTypeResponse>> Update(UpdateGenderTypeRequest request);
        Task<ApiResponse<GenderTypeResponse>> Delete(int id);
    }
}
