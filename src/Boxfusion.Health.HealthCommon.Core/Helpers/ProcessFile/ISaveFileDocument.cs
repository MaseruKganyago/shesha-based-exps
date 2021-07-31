using Boxfusion.Health.HealthCommon.Core.Helpers.ProcessFile.FileDtos;
using Microsoft.AspNetCore.Http;
using Shesha.StoredFiles.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Boxfusion.Health.HealthCommon.Core.Helpers.ProcessFile
{
    public interface ISaveFileDocument 
    {
        Task<StoredFileDto> UploadFile(UploadFileInput input);
    }
}
