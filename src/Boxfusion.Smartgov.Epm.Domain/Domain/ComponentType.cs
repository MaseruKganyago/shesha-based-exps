using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Domain
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "Epm.ComponentType")]
	public class ComponentType: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// Unique name for this type of component.
		/// </summary>
		public virtual string Name { get; set; }

		/// <summary>
		/// What will be displayed to the user for this type of component.
		/// </summary>
		public virtual string Caption { get; set; }
		public virtual string Description { get; set; }
		public virtual string Icon { get; set; }
		public virtual string AdminTreeCreateForm { get; set; }
		public virtual string AdminTreeDetailsForm { get; set; }
		public virtual string AdminTreeUpdateForm { get; set; }
		public virtual string ViewerTreeDetailsForm { get; set; }

		/// <summary>
		/// If true, indicates that the component represents an indicator.
		/// </summary>
		public virtual bool IsIndicator { get; set; }

		/// <summary>
		/// If false, will not display this component when viewing as a regular user.
		/// </summary>
		public virtual bool ShowInAdminTree { get; set; }
		public virtual bool ShowInViewerTree { get; set; }

		/// <summary>
		/// If true, a Progress Reporting for this component and all its child Components is done at this level.
		/// </summary>
		public virtual bool ProgressReportingRequired { get; set; }

		/// <summary>
		/// Name of the form used to display Component progress details.
		/// </summary>
		public virtual string ProgressDetailsSubForm { get; set; }
		public virtual bool ProgressQA1Required { get; set; }
		public virtual bool ProgressQA2Required { get; set; }
		public virtual bool ProgressAuditRequired { get; set; }
	}
}
