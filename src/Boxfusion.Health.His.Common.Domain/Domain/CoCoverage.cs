using Boxfusion.Health.Cdm.Domain.Domain.Fhir;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using Shesha.Enterprise.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Domain.Domain
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "His.CoCoverage")]
	[Table("Fhir_Coverages")]
	public class CoCoverage : Coverage
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual BankAccount BankAccount { get; set; }
	}
}
