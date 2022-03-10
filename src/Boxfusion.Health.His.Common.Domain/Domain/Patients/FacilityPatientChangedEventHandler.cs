﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Abp.ObjectMapping;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;
using NHibernate;
using NHibernate.Linq;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Services.ReferenceLists.Dto;

namespace Boxfusion.Health.His.Common.Patients
{
    public class FacilityPatientChangedEventHandler : IEventHandler<EntityChangedEventData<FacilityPatient>>, ITransientDependency
    {
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public FacilityPatientChangedEventHandler(IUnitOfWorkManager unitOfWorkManager)
        {
            _unitOfWorkManager = unitOfWorkManager;

        }

        public void HandleEvent(EntityChangedEventData<FacilityPatient> eventData)
        {
            if (!RequestContextHelper.HasFacilityId) return;

            var abpSession = IocManager.Instance.Resolve<IAbpSession>();
            var currentUserId = abpSession.GetUserId();
            var facilityId = RequestContextHelper.FacilityId;

            // make sure that we have active session
            using (_unitOfWorkManager.Current == null ? _unitOfWorkManager.Begin() : null)
                {
                using (var session = IocManager.Instance.Resolve<ISessionFactory>().OpenSession())
                {
                    var query = session
                      .CreateSQLQuery(@"
                            EXEC Sp_His_UpsertFacilityPatientIdentifier 
                             @patientId = :patientId,
                             @facilityId = :facilityId,
                             @facilityPatientIdentifier = :facilityPatientIdentifier,
                             @currentUserId = :currentUserId")
                      .SetParameter("patientId", eventData.Entity.Id)
                      .SetParameter("facilityId", facilityId)
                      .SetParameter("facilityPatientIdentifier", eventData.Entity.FacilityPatientIdentifier)
                      .SetParameter("currentUserId", currentUserId);

                    query.ExecuteUpdate();
                }
            }
        }
    }
}