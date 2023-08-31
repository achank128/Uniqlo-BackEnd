using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.Repositories.Interfaces;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Shipment;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.ShipmentService
{
    public class ShipmentService : IShipmentService
    {
        private readonly IMapper _mapper;
        private readonly IShipmentRepository _shipmentRepository;

        public ShipmentService(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ShipmentResponse>> Create(CreateShipmentRequest request)
        {
            var shipment = _mapper.Map<Shipment>(request);
            _shipmentRepository.Add(shipment);

            if (await _shipmentRepository.SaveAsync())
            {
                return ApiResponse<ShipmentResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<ShipmentResponse>> Delete(Guid id)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(id);
            if (shipment == null) throw new NotFoundException(Common.NotFound);

            _shipmentRepository.Delete(shipment);
            if (await _shipmentRepository.SaveAsync())
            {
                return ApiResponse<ShipmentResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<ShipmentResponse>> Filter(FilterBaseRequest request)
        {
            var shipments = _shipmentRepository.GetQueryable();
            var paged = await PagedResponse<Shipment>.CreateAsync(shipments, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<ShipmentResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<ShipmentResponse>>> GetAll()
        {
            var alls = await _shipmentRepository.GetAllAsync();
            var response = _mapper.Map<List<ShipmentResponse>>(alls);
            return ApiResponse<List<ShipmentResponse>>.Success(response);
        }

        public async Task<ApiResponse<ShipmentResponse>> GetById(Guid id)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(id);
            if (shipment == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<ShipmentResponse>(shipment);
            return ApiResponse<ShipmentResponse>.Success(response);
        }

        public async Task<ApiResponse<ShipmentResponse>> Update(UpdateShipmentRequest request)
        {
            var shipment = _mapper.Map<Shipment>(request);
            shipment.UpdatedDate = DateTime.Now;
            _shipmentRepository.Update(shipment);
            if (await _shipmentRepository.SaveAsync())
            {
                return ApiResponse<ShipmentResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }
    }
}
