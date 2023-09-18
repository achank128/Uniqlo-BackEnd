using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.BusinessLogic.Shared.FileUploadService;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.ProductImage;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.ProductImageService
{
    public class ProductImageService  : IProductImageService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<ProductImage> _productImageRepository;
        private readonly IFileUploadService _fileUploadService;

        public ProductImageService(
            IRepositoryBase<ProductImage> productImageRepository, 
            IMapper mapper, 
            IFileUploadService fileUploadService)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
            _fileUploadService = fileUploadService;
        }

        public async Task<ApiResponse<ProductImageResponse>> Create(CreateProductImageRequest request)
        {
            var productImage = _mapper.Map<ProductImage>(request);
            _productImageRepository.Add(productImage);

            if (await _productImageRepository.SaveAsync())
            {
                return ApiResponse<ProductImageResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<ProductImageResponse>> Delete(Guid id)
        {
            var productImage = await _productImageRepository.GetByIdAsync(id);
            if (productImage == null) throw new NotFoundException(Common.NotFound);

            _productImageRepository.Delete(productImage);
            if (await _productImageRepository.SaveAsync())
            {
                return ApiResponse<ProductImageResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<ProductImageResponse>> Filter(FilterBaseRequest request)
        {
            var productImages = _productImageRepository.GetQueryable();
            var paged = await PagedResponse<ProductImage>.CreateAsync(productImages, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<ProductImageResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<ProductImageResponse>>> GetAll()
        {
            var alls = await _productImageRepository.GetAllAsync();
            var response = _mapper.Map<List<ProductImageResponse>>(alls);
            return ApiResponse<List<ProductImageResponse>>.Success(response);
        }

        public async Task<ApiResponse<ProductImageResponse>> GetById(Guid id)
        {
            var productImage = await _productImageRepository.GetByIdAsync(id);
            if (productImage == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<ProductImageResponse>(productImage);
            return ApiResponse<ProductImageResponse>.Success(response);
        }

        public async Task<ApiResponse<ProductImageResponse>> Update(UpdateProductImageRequest request)
        {
            var productImage = _mapper.Map<ProductImage>(request);
            productImage.UpdatedDate = DateTime.Now;
            _productImageRepository.Update(productImage);
            if (await _productImageRepository.SaveAsync())
            {
                return ApiResponse<ProductImageResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }

        public async Task<ApiResponse<List<ProductImageResponse>>> Uploads(UploadProductImageRequest request)
        {
            var filesUploaded = await _fileUploadService.PostMultiFileAsync(request.Images);
            List<ProductImage> productImages = new List<ProductImage>();
            foreach (var file in filesUploaded)
            {
                ProductImage productImage = new ProductImage
                {
                    Id = Guid.NewGuid(),
                    ProductId = request.ProductId,
                    Type = request.Type,
                    Image = file.FileName,
                    ImageUrl = file.FilePath,
                };
                productImages.Add(productImage);
            }

            _productImageRepository.AddRange(productImages);
            if (await _productImageRepository.SaveAsync())
            {
                var response = _mapper.Map<List<ProductImageResponse>> (productImages);
                return ApiResponse<List<ProductImageResponse>>.Success(Common.UpdateSuccess, response);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }
    }
}
