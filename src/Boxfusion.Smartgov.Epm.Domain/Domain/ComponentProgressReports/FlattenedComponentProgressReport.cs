using Abp.Domain.Entities;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain.ComponentProgressReports
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "Epm.FlattenedComponentProgressReport")]
	[Table("vw_Epm_FlattenedComponentProgressReport")]
	[ImMutable]
	public class FlattenedComponentProgressReport: Entity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual string TemplateName { get; protected set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string PeriodCoveredName { get; protected set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string Name { get; protected set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Epm", "NodeProgressReportStatus")]
		public virtual long? ProgressReportStatus { get; protected set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Guid? ResponsibleReportingPersonId { get; protected set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Guid? ResponsibleQA1PersonId { get; protected set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Guid? ResponsibleQA2PersonId { get; protected set; }
	}
}
