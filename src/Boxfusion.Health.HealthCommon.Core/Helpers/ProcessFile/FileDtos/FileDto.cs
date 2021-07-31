using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Helpers.ProcessFile.FileDtos
{

    public class FileDto : EntityDto<Guid>
    {
        public string OwnerId { get; set; }

        public string OwnerType { get; set; }

        public int? FilesCategory { get; set; }

        public string PropertyName { get; set; }

        public IFormFile File { get; set; }
    }
}
