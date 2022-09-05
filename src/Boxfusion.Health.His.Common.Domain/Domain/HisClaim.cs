using Boxfusion.Health.Cdm.Domain.Domain.Fhir;
using Boxfusion.Health.His.Common.Invoices;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "His.HisClaim")]
	public class HisClaim: Claim
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual HisInvoice Invoice { get; set; }
	}
}
