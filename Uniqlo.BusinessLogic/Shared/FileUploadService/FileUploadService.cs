using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;

namespace Uniqlo.BusinessLogic.Shared.FileUploadService
{
    public class FileUploadService : IFileUploadService
    {
        public Task DownloadFileById(int fileName)
        {
            throw new NotImplementedException();
        }

        public async Task<FileResponse> PostFileAsync(IFormFile postedFile)
        {
            string extension = Path.GetExtension(postedFile.FileName);
            string fileName = Guid.NewGuid() + DateTime.Now.ToString("yymmssfff") + extension;

            string path = Path.Combine("Resources", "Images");
            string filePath = Path.Combine(path, fileName);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                postedFile.CopyTo(fileStream);
            }

            return new FileResponse
            {
                FileName = fileName,
                FilePath = filePath,
            };
        }

        public async Task<List<FileResponse>> PostMultiFileAsync(List<IFormFile> filesData)
        {
            var fileResponses = new List<FileResponse>();
            foreach (var file in filesData)
            {
                if (file.Length > 0)
                {
                    string extension = Path.GetExtension(file.FileName);
                    string fileName = Guid.NewGuid() + DateTime.Now.ToString("yymmssfff") + extension;

                    string path = Path.Combine("Resources", "Images");
                    string filePath = Path.Combine(path, fileName);
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    fileResponses.Add(new FileResponse
                    {
                        FileName = fileName,
                        FilePath = filePath,
                    });
                }
            }

            return fileResponses;
        }
    }
}
