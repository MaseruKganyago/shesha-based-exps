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
using Boxfusion.Health.Cdm.Appointments;
using NHibernate;
using NHibernate.Linq;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.Enterprise.Domain;
using Shesha.Enterprise.Sequences;
using Shesha.Services.ReferenceLists.Dto;

namespace Boxfusion.Health.His.MpDoh.Appointments
{
    /// <summary>
    /// Intercepts a new appointment before saving to generate and assign a reference number based on the 
    /// customer's Reference numbering conventions.
    /// </summary>
    public class AppointmentsChangingEventHandler : IEventHandler<EntityChangingEventData<CdmAppointment>>, ITransientDependency
    {
        public AppointmentsChangingEventHandler()
        {

        }

        /// <summary>
        /// Adds a newly generated reference number to a new appointment.
        /// </summary>
        /// <param name="eventData"></param>
        public void HandleEvent(EntityChangingEventData<CdmAppointment> eventData)
        {
            var appointment = eventData.Entity;
            
            if (!string.IsNullOrWhiteSpace(appointment.RefNumber))
                return;

            var appointmentDay = appointment.Start.Value.Date;
            var sequenceManager = new SequenceManager();
            var seqNumber = sequenceManager.GetNextSequenceNo("Boxfusion.MyProject.AppointmentRefNo", appointmentDay.ToString(), 1);

            appointment.RefNumber = $"APP{appointmentDay:MMdd}-{seqNumber:000}";

        }
    }
}