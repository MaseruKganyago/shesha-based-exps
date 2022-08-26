using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using Shesha.Enterprise.Invoices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.Cdm.Domain.Domain.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.FhirInvoice")]
	public class FhirInvoice: Invoice
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual Patient Subject { get; set; }
	}
}
