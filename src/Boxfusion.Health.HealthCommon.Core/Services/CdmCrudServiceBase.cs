using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityDto"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    [AbpAuthorize()]
    public abstract class CdmCrudServiceBase<TEntity, TEntityDto, TPrimaryKey> : CdmCrudServiceBase<TEntity,
       TEntityDto, TPrimaryKey, PagedAndSortedResultRequestDto, TEntityDto, TEntityDto>
       where TEntity : class, IEntity<TPrimaryKey>
       where TEntityDto : IEntityDto<TPrimaryKey>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        protected CdmCrudServiceBase(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TEntityDto"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <typeparam name="TGetAllInput"></typeparam>
    /// <typeparam name="TCreateInput"></typeparam>
    /// <typeparam name="TUpdateInput"></typeparam>
    public abstract class CdmCrudServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput> : SheshaCrudServiceBase<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
    {
        private readonly ICdmPermissionChecker _permissionChecker;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repository"></param>
        public CdmCrudServiceBase(IRepository<TEntity, TPrimaryKey> repository) : base(repository)
        {
            _permissionChecker = Abp.Dependency.IocManager.Instance.Resolve<ICdmPermissionChecker>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<PagedResultDto<TEntityDto>> GetAllAsync(TGetAllInput input)
        {
            return await DoTaskAsync<PagedResultDto<TEntityDto>>(() => base.GetAllAsync(input));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<TEntityDto> GetAsync(EntityDto<TPrimaryKey> input)
        {
            return await DoTaskAsync<TEntityDto>(() => base.GetAsync(input));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<TEntityDto> CreateAsync(TCreateInput input)
        {
            return await DoTaskAsync<TEntityDto>(() => base.CreateAsync(input));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<TEntityDto> UpdateAsync(TUpdateInput input)
        {
            return await DoTaskAsync<TEntityDto>(() => base.UpdateAsync(input));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task DeleteAsync(EntityDto<TPrimaryKey> input)
        {
            await DoTaskAsync(() => base.DeleteAsync(input));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="doTask"></param>
        /// <returns></returns>
        protected async Task<T> DoTaskAsync<T>(Func<Task<T>> doTask)
        {
            try { return await doTask(); }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="doTask"></param>
        /// <returns></returns>
        protected async Task DoTaskAsync(Func<Task> doTask)
        {
            try { await doTask(); }
            catch (Exception ex)
            {
                throw new UserFriendlyException(ex.Message);
            }
        }

        /// <summary>
        /// This is used to authenticate if the user role has rights to access the api
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="doTask">Logic to be executed</param>
        /// <param name="errorMessage">Custom error message</param>
        /// <param name="roleNames">The roles of people who are supposed to access the api</param>
        /// <returns></returns>
        protected async Task<T> DoTaskWithAuthAsync<T>(Func<Task<T>> doTask, string errorMessage, params string[] roleNames)
        {
            return await DoTaskAsync(async () =>
            {
                var person = await GetCurrentPersonAsync();
                var isAuthorized = await _permissionChecker.IsInAnyOfRoles(person, roleNames);

                if (isAuthorized)
                    return await doTask();    //executes the logic
                else
                    throw new UserFriendlyException(errorMessage ?? "You are not authorized to access this api");
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected async Task<Patient> GetCurrentPatientAsync()
        {
            return await DoTaskAsync<Patient>(async () =>
            {
                var entity = await GetCurrentPersonAsync() as Patient;
                if (entity == null)
                    throw new UserFriendlyException("Account is not found !!");

                return entity;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected async Task<Practitioner> GetCurrentPractitionerAsync()
        {
            return await DoTaskAsync<Practitioner>(async () =>
            {
                var entity = await GetCurrentPersonAsync() as Practitioner;
                if (entity == null)
                    throw new UserFriendlyException("Account is not found !!");

                return entity;
            });
        }
    }
}
