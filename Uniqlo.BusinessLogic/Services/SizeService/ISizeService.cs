﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Size;
using Uniqlo.Models.RequestModels.Unit;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.SizeService
{
    public interface ISizeService
    {
        Task<ApiResponse<SizeResponse>> Create(CreateSizeRequest request);
        Task<PagedResponse<SizeResponse>> Filter(FilterBaseRequest request);
        Task<ApiResponse<List<SizeResponse>>> GetAll();
        Task<ApiResponse<List<SizeResponse>>> GetByGenderType(int genderTypeId);
        Task<ApiResponse<SizeResponse>> GetById(int id);
        Task<ApiResponse<SizeResponse>> Update(UpdateSizeRequest request);
        Task<ApiResponse<SizeResponse>> Delete(int id);
    }
}
