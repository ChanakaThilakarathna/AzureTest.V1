using AzureTest.V1.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureTest.V1.Data.Dtos
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public ResponseTypes Responsetype { get; set; }
    }
    public class UploadFileResponse : BaseResponse
    {
        public string SavedPath { get; set; }
    }
}
