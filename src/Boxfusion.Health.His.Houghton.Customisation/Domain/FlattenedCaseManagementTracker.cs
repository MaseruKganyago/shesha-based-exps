using Abp.Domain.Entities;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Houghton.Customisation.Domain
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "His.FlatCaseManagementTracker")]
	[Table("vw_His_FlattenedCaseManagementTracker")]
	[ImMutable]
	[NotMapped]
	public class FlattenedCaseManagementTracker : Entity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual string AdmissionNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string FileNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>

		public virtual string FirstName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string LastName { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? AdmissionDate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? DischargeDate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("His", "BillingClassificationType")]
		public virtual long? Classification { get; set; }
	}
}
