using Boxfusion.Health.HealthCommon.Core.Helpers.ProcessFile.FileDtos;
using Microsoft.AspNetCore.Http;
using Shesha.Domain;
using Shesha.StoredFiles.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Boxfusion.Health.HealthCommon.Core.Helpers.ProcessFile
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISaveFileDocument 
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<StoredFileDto> UploadFile(UploadFileInput input);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileDto"></param>
        void MapStoredFile(StoredFile file, StoredFileDto fileDto);
    }
}
