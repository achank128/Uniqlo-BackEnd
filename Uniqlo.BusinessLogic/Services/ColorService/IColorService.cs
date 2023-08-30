using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Color;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.ColorService
{
    public interface IColorService
    {
        Task<ApiResponse<ColorResponse>> Create(CreateColorRequest request);
        Task<PagedResponse<ColorResponse>> Filter(FilterBaseRequest request);
        Task<ApiResponse<List<ColorResponse>>> GetAll();
        Task<ApiResponse<ColorResponse>> GetById(int id);
        Task<ApiResponse<ColorResponse>> Update(UpdateColorRequest request);
        Task<ApiResponse<ColorResponse>> Delete(int id);
    }
}
