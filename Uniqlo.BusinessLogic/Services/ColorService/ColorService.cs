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
using Uniqlo.Models.RequestModels.Color;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.ColorService
{
    public class ColorService : IColorService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Color> _colorRepository;

        public ColorService(IRepositoryBase<Color> colorRepository, IMapper mapper)
        {
            _colorRepository = colorRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ColorResponse>> Create(CreateColorRequest request)
        {
            var color = _mapper.Map<Color>(request);
            _colorRepository.Add(color);

            if (await _colorRepository.SaveAsync())
            {
                return ApiResponse<ColorResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<ColorResponse>> Delete(int id)
        {
            var color = await _colorRepository.GetByIdAsync(id);
            if (color == null) throw new NotFoundException(Common.NotFound);

            _colorRepository.DeleteBy(id);
            if (await _colorRepository.SaveAsync())
            {
                return ApiResponse<ColorResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<ColorResponse>> GetAll(FilterBaseRequest request)
        {
            var colors = _colorRepository.GetQueryable();
            var paged = await PagedResponse<Color>.CreateAsync(colors, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<ColorResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<ColorResponse>> GetById(int id)
        {
            var color = await _colorRepository.GetByIdAsync(id);
            if (color == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<ColorResponse>(color);
            return ApiResponse<ColorResponse>.Success(response);
        }

        public async Task<ApiResponse<ColorResponse>> Update(UpdateColorRequest request)
        {
            var color = _mapper.Map<Color>(request);
            color.UpdatedDate = DateTime.Now;
            _colorRepository.Update(color);
            if (await _colorRepository.SaveAsync())
            {
                return ApiResponse<ColorResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }
    }
}
