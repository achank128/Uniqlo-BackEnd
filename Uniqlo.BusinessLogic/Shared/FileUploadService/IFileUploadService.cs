using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;

namespace Uniqlo.BusinessLogic.Shared.FileUploadService
{
    public interface IFileUploadService
    {
        public Task<FileResponse> PostFileAsync(IFormFile fileData);

        public Task<List<FileResponse>> PostMultiFileAsync(List<IFormFile> filesData);

        public Task DownloadFileById(int fileName);
    }
}
