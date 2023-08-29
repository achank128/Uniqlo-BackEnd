using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.Repositories.Interfaces;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRepositoryBase<WishList> _wishListRepository;

        public UserService(
            IMapper mapper, 
            IUserRepository userRepository, 
            IRepositoryBase<WishList> wishListRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _wishListRepository = wishListRepository;
        }

        public async Task<PagedResponse<UserResponse>> GetAll(FilterBaseRequest request)
        {
            var users = _userRepository.GetQueryable();
            var paged = await PagedResponse<User>.CreateAsync(users, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<UserResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<UserResponse>> GetById(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<UserResponse>(user);
            return ApiResponse<UserResponse>.Success(response);
        }

        
    }
}
