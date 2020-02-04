using AzureTest.V1.Data.Dtos;
using AzureTest.V1.Data.Models;
using BlazorFileUploader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureTest.V1.Services
{
    public interface IFileUpload
    {
        Task<UploadFileResponse> UploadAsync(IFileListEntry file);
        Task SaveAsync(Uploads file);
    }
}
