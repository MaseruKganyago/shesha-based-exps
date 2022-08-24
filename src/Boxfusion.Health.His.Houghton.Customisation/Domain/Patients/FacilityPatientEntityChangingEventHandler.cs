using Abp.Dependency;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Boxfusion.Health.Cdm.Appointments;
using Boxfusion.Health.His.Common.Patients;
using Shesha.Enterprise.Sequences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Houghton.Customisation.Domain.Patients
{
	/// <summary>
	/// Intercepts a new facilityPatient before saving to generate and assign a file number based on the 
	/// customer's Reference numbering conventions.
	/// </summary>
	public class FacilityPatientEntityChangingEventHandler: IEventHandler<EntityChangingEventData<HisPatient>>, ITransientDependency
	{
		/// <summary>
		/// 
		/// </summary>
		public FacilityPatientEntityChangingEventHandler()
		{
		}

		/// <summary>
		/// Assgin new generated number using {}
		/// </summary>
		/// <param name="eventData"></param>
		public void HandleEvent(EntityChangingEventData<HisPatient> eventData)
		{
			var patient = eventData.Entity;

			if (!string.IsNullOrEmpty(patient.PatientMasterIndexNumber))
				return;

			var sequenceManager = new SequenceManager();
			var seqNumber = sequenceManager.GetNextSequenceNo("BoxHealth.Houghton.FacilityPatientIdentifier");

			patient.PatientMasterIndexNumber = formatSeqNumber($"{seqNumber:0000000000}");
		}

		private string formatSeqNumber(string seqString)
		{
			return seqString.Insert(3, "/").Insert(7, "/");
		}
	}
}
