using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
using Uniqlo.Models.RequestModels.UserAddress;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.UserAddressService
{
    public class UserAddressService : IUserAddressService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<UserAddress> _userAddressRepository;

        public UserAddressService(IRepositoryBase<UserAddress> userAddressRepository, IMapper mapper)
        {
            _userAddressRepository = userAddressRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<UserAddressResponse>> Create(CreateUserAddressRequest request)
        {
            var addresses = await _userAddressRepository.GetBy(a => a.UserId == request.UserId).ToListAsync();

            if(addresses.Count() == 0) {
                request.IsDefault = true;
            }

            var userAddress = _mapper.Map<UserAddress>(request);
            _userAddressRepository.Add(userAddress);

            if (userAddress.IsDefault)
            {
                foreach (var item in addresses)
                {
                    item.IsDefault = false;
                    _userAddressRepository.Update(item);
                }
            }

            if (await _userAddressRepository.SaveAsync())
            {
                return ApiResponse<UserAddressResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<UserAddressResponse>> Delete(Guid id)
        {
            var userAddress = await _userAddressRepository.GetByIdAsync(id);
            if (userAddress == null) throw new NotFoundException(Common.NotFound);

            _userAddressRepository.Delete(userAddress);
            if (await _userAddressRepository.SaveAsync())
            {
                return ApiResponse<UserAddressResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<UserAddressResponse>> Filter(FilterBaseRequest request)
        {
            var userAddresses = _userAddressRepository.GetQueryable();
            var paged = await PagedResponse<UserAddress>.CreateAsync(userAddresses, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<UserAddressResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<UserAddressResponse>>> GetAll()
        {
            var alls = await _userAddressRepository.GetAllAsync();
            var response = _mapper.Map<List<UserAddressResponse>>(alls);
            return ApiResponse<List<UserAddressResponse>>.Success(response);
        }

        public async Task<ApiResponse<UserAddressResponse>> GetById(Guid id)
        {
            var userAddress = await _userAddressRepository.GetByIdAsync(id);
            if (userAddress == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<UserAddressResponse>(userAddress);
            return ApiResponse<UserAddressResponse>.Success(response);
        }

        public async Task<ApiResponse<List<UserAddressResponse>>> GetByUser(Guid userId)
        {
            var userAddresses = _userAddressRepository.GetBy(u => u.UserId == userId);
            userAddresses = userAddresses
                .Include(u => u.Province)
                .Include(u => u.District)
                .Include(u => u.Ward);
            var addresses = await userAddresses.ToListAsync();
            var response = _mapper.Map<List<UserAddressResponse>>(userAddresses);
            return ApiResponse<List<UserAddressResponse>>.Success(response);
        }

        public async Task<ApiResponse<UserAddressResponse>> SetDefault(Guid id, Guid userId)
        {
            var addresses = await _userAddressRepository.GetBy(a => a.UserId == userId).ToListAsync();
            foreach (var item in addresses)
            {
                item.IsDefault = false;
                _userAddressRepository.Update(item);
            }
            var userAddress = await _userAddressRepository.GetByIdAsync(id);
            if (userAddress == null) throw new NotFoundException(Common.NotFound);
            userAddress.IsDefault = true;
            userAddress.UpdatedDate = DateTime.Now;
            _userAddressRepository.Update(userAddress);
            if (await _userAddressRepository.SaveAsync())
            {
                return ApiResponse<UserAddressResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }

        public async Task<ApiResponse<UserAddressResponse>> Update(UpdateUserAddressRequest request)
        {
            var userAddress = _mapper.Map<UserAddress>(request);
            userAddress.UpdatedDate = DateTime.Now;
            _userAddressRepository.Update(userAddress);
            if (await _userAddressRepository.SaveAsync())
            {
                return ApiResponse<UserAddressResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }
    }
}
