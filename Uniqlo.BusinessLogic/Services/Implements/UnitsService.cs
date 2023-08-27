﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.BusinessLogic.Services.Interfaces;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Unit;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.Implements
{
    public class UnitsService : IUnitsService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Unit> _unitRepository;

        public UnitsService(IRepositoryBase<Unit> unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }
        public async Task<ApiResponse<UnitResponse>> Create(CreateUnitRequest request)
        {
            var unit = _mapper.Map<Unit>(request);
            _unitRepository.Add(unit);

            if (await _unitRepository.SaveAsync())
            {
                return ApiResponse<UnitResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<UnitResponse>> Delete(int id)
        {
            var unit = await _unitRepository.GetByIdAsync(id);
            if(unit == null) throw new NotFoundException(Common.NotFound);
            
            _unitRepository.DeleteBy(id);
            if (await _unitRepository.SaveAsync())
            {
                return ApiResponse<UnitResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<UnitResponse>> GetAll(FilterBaseRequest request)
        {
            var units = _unitRepository.GetQueryable();
            var paged = await PagedResponse<Unit>.CreateAsync(units, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<UnitResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<UnitResponse>> GetById(int id)
        {
            var unit = await _unitRepository.GetByIdAsync(id);
            var response = _mapper.Map<UnitResponse>(unit);
            return ApiResponse<UnitResponse>.Success(response);
        }

        public async Task<ApiResponse<UnitResponse>> Update(UpdateUnitRequest request)
        {
            var unit = _mapper.Map<Unit>(request);
            _unitRepository.Update(unit);
            if (await _unitRepository.SaveAsync())
            {
                return ApiResponse<UnitResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }
    }
}
