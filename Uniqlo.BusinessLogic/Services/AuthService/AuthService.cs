using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.Repositories.Interfaces;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.User;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;


        public AuthService(IMapper mapper, IUserRepository userRepository, IConfiguration configuration)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<string> GenerateToken(UserResponse user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:SecretKey").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<ApiResponse<AuthResponse>> Login(UserLoginRequest request)
        {
            var userLogin = _userRepository.GetQueryable().SingleOrDefault(p => p.Email == request.Email);

            if (userLogin == null)
            {
                throw new BadRequestException(AuthKeywords.EmailIncorrect);
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, userLogin.Password))
            {
                throw new BadRequestException(AuthKeywords.PasswordIncorrect);
            }

            var user = _mapper.Map<UserResponse>(userLogin);
            string token = await GenerateToken(user);
            AuthResponse response = new AuthResponse
            {
                AccessToken = token,
                User = user
            };
            return ApiResponse<AuthResponse>.Success(AuthKeywords.LoginSuccess, response);
        }

        public async Task<ApiResponse<AuthResponse>> Register(UserRegisterRequest request)
        {
            var userEmail = _userRepository.GetQueryable().SingleOrDefault(p => p.Email == request.Email);
            if(userEmail != null) throw new BadRequestException(AuthKeywords.EmailExist);

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            User newUser = new User {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Password = passwordHash,
                FirstName = "",
                LastName = "",
                Gender = request.Gender,
                BirthDate = request.BirthDate,
            };
          
            _userRepository.Add(newUser);
            if (await _userRepository.SaveAsync())
            {
                var user = _mapper.Map<UserResponse>(newUser);
                string token = await GenerateToken(user);
                AuthResponse response = new AuthResponse
                {
                    AccessToken = token,
                    User = user
                };
                return ApiResponse<AuthResponse>.Success(AuthKeywords.RegisterSuccess, response);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }

        }
    }
}
