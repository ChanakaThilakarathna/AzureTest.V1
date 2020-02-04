using AzureTest.V1.Data;
using AzureTest.V1.Data.Dtos;
using AzureTest.V1.Data.Enums;
using AzureTest.V1.Data.Models;
using BlazorFileUploader;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AzureTest.V1.Services
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment _environment;
        private readonly Azuretestv1Context _context;
       
        public FileUpload(IWebHostEnvironment env, Azuretestv1Context context)
        {
            _environment = env;
            _context = context;
        }

        public async Task<UploadFileResponse> UploadAsync(IFileListEntry fileEntry)
        {
            try {
                var path = Path.Combine(_environment.ContentRootPath, "Upload", fileEntry.Name);
                var ms = new MemoryStream();
                await fileEntry.Data.CopyToAsync(ms);
                using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    ms.WriteTo(file);
                }
                await SaveAsync(new Uploads() { Id = Guid.NewGuid(), FileName = fileEntry.Name, FilePath = path, Extention = fileEntry.Extension, UploadDate = DateTime.UtcNow });
                return new UploadFileResponse() { Message = "File Upload Successful", Responsetype = ResponseTypes.Success, SavedPath = path };  
            } catch {
                return new UploadFileResponse() { Message="File Upload Unsuccessful",Responsetype=ResponseTypes.Fail,SavedPath=""};
            }
        }

        public async Task SaveAsync(Uploads file)
        {
            _context.Uploads.Add(file);
           await _context.SaveChangesAsync();
        }
    }
}
