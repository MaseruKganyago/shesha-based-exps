using System;
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
            //if (!RequestContextHelper.HasFacilityId) return;
            //TODO:NOW Reinstate above once we know data gets passed

            var abpSession = IocManager.Instance.Resolve<IAbpSession>();
            var currentUserId = abpSession.GetUserId();

                // make sure that we have active session
            using (_unitOfWorkManager.Current == null ? _unitOfWorkManager.Begin() : null)
                {
                using (var session = IocManager.Instance.Resolve<ISessionFactory>().OpenSession())
                {
                    var query = session
                      .CreateSQLQuery("EXEC Sp_His_UpsertFacilityPatientIdentifier ")
                      .SetParameter("patientId", eventData.Entity.Id)
                      .SetParameter("facilityId", RequestContextHelper.FacilityId)
                      .SetParameter("facilityPatientIdentifier", eventData.Entity.FacilityPatientIdentifier)
                      .SetParameter("currentUserId", currentUserId);

                    query.ExecuteUpdate();

                    session.Flush();
                }
            }


            throw new NotImplementedException();
        }
    }
}