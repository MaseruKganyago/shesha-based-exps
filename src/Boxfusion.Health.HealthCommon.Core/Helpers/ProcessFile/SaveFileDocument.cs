using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.UI;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Helpers.ProcessFile.FileDtos;
using Microsoft.AspNetCore.Http;
using Shesha.Domain;
using Shesha.Extensions;
using Shesha.Reflection;
using Shesha.Services;
using Shesha.StoredFiles.Dto;
using Shesha.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Helpers.ProcessFile
{
    /// <summary>
    /// 
    /// </summary>
    public class SaveFileDocument : ISaveFileDocument, ITransientDependency
    {
        private readonly IUnitOfWorkManager _unitOfWork;
        private readonly IDynamicRepository _dynamicRepository;
        private readonly IStoredFileService _fileService;
        private readonly IRepository<StoredFile, Guid> _fileRepository;
        private readonly IRepository<StoredFileVersion, Guid> _fileVersionRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="dynamicRepository"></param>
        /// <param name="fileService"></param>
        /// <param name="fileRepository"></param>
        /// <param name="fileVersionRepository"></param>
        /// <param name="mapper"></param>
        /// <param name="httpContextAccessor"></param>
        public SaveFileDocument(
            IUnitOfWorkManager unitOfWork,
            IDynamicRepository dynamicRepository,
            IStoredFileService fileService,
            IRepository<StoredFile, Guid> fileRepository,
            IRepository<StoredFileVersion, Guid> fileVersionRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _dynamicRepository = dynamicRepository;
            _fileService = fileService;
            _fileRepository = fileRepository;
            _fileVersionRepository = fileVersionRepository;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<StoredFileDto> UploadFile(UploadFileInput input)
        {
            if (string.IsNullOrWhiteSpace(input.OwnerType))
                throw new UserFriendlyException($"{nameof(input.OwnerType)} must not be null");
            if (string.IsNullOrWhiteSpace(input.OwnerId))
                throw new UserFriendlyException(nameof(input.OwnerId), $"{nameof(input.OwnerId)} must not be null");

            if (input.File == null)
                throw new UserFriendlyException(nameof(input.File), $"{nameof(input.File)} must not be null");

            var owner = await _dynamicRepository.GetAsync(input.OwnerType, input.OwnerId);
            if (owner == null)
                throw new Exception($"Owner not found (type = '{input.OwnerType}', id = '{input.OwnerId}')");

            var uploadedFile = new StoredFileDto();
            var fileName = input.File.FileName.CleanupFileName();

            if (!string.IsNullOrWhiteSpace(input.PropertyName))
            {
                // single file upload (stored as a property of an entity)
                var property = ReflectionHelper.GetProperty(owner, input.PropertyName);
                if (property == null || property.PropertyType != typeof(StoredFile))
                    throw new Exception(
                        $"Property '{input.PropertyName}' not found in class '{owner.GetType().FullName}'");

                if (property.GetValue(owner, null) is StoredFile storedFile)
                {
                    storedFile.IsVersionControlled = true;
                    var version = await _fileService.GetNewOrDefaultVersionAsync(storedFile);

                    await using (var fileStream = input.File.OpenReadStream())
                    {
                        await _fileService.UpdateVersionContentAsync(version, fileStream);
                    }

                    version.FileName = fileName;
                    version.FileType = Path.GetExtension(fileName);
                    await _fileVersionRepository.InsertOrUpdateAsync(version);

                    // copy to the main todo: remove duplicated properties (filename, filetype), add a link to the last version and update it using triggers
                    storedFile.FileName = version.FileName;
                    storedFile.FileType = version.FileType;
                    await _fileRepository.UpdateAsync(storedFile);
                }
                else
                {
                    await using (var fileStream = input.File.OpenReadStream())
                    {
                        storedFile = await _fileService.SaveFile(fileStream, fileName);

                        property.SetValue(owner, storedFile, null);
                    }
                }

                MapStoredFile(storedFile, uploadedFile);
            }
            else
            {
                // add file as an attachment (linked to an entity using OwnerType and OwnerId)
                await using (var fileStream = input.File.OpenReadStream())
                {
                    var storedFile = await _fileService.SaveFile(fileStream, fileName, file =>
                    {
                        file.SetOwner(input.OwnerType, input.OwnerId);
                        file.Category = input.FilesCategory;
                    });

                    MapStoredFile(storedFile, uploadedFile);
                }
            }

            return uploadedFile;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileDto"></param>
        public void MapStoredFile(StoredFile file, StoredFileDto fileDto)
        {
            fileDto.Id = file.Id;
            fileDto.FileCategory = file.Category;
            fileDto.Name = file.FileName;
            fileDto.Url = file.GetFileUrl(); 
            fileDto.Size = file.LastVersion()?.FileSize ?? 0;
            fileDto.Type = !string.IsNullOrWhiteSpace(file.FileName) ? Path.GetExtension(file.FileName)  : null;
        }
    }
}

