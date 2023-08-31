using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.Shared.FileUploadService;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadsController : ControllerBase
    {
        private readonly IFileUploadService _fileUploadService;

        public FileUploadsController(IFileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }


        /// <summary>
        /// Upload 1 file
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Single")]
        public async Task<IActionResult> Upload(IFormFile request)
        {
            var response = await _fileUploadService.PostFileAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Upload nhiều files
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Multiple")]
        public async Task<IActionResult> Uploads(List<IFormFile> request)
        {
            var response = await _fileUploadService.PostMultiFileAsync(request);
            return Ok(response);
        }
    }
}
