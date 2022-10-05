using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Enterprise.Sequences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Invoices
{
	/// <summary>
	/// 
	/// </summary>
	public class HisInvoiceEntityChangingEventHandler: IEventHandler<EntityChangingEventData<HisInvoice>>
	{
		/// <summary>
		/// 
		/// </summary>
		public HisInvoiceEntityChangingEventHandler()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="eventData"></param>
		public void HandleEvent(EntityChangingEventData<HisInvoice> eventData)
		{
			var entity = eventData.Entity;

			var sequenceManager = new SequenceManager();
			var seqNumber = sequenceManager.GetNextSequenceNo("BoxHealth.His.HisInvoice");

			entity.InvoiceNo = $"INV{seqNumber:000000}";
		}
	}
}
