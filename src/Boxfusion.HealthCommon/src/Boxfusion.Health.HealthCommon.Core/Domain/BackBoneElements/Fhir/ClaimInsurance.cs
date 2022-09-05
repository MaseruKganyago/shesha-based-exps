using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Cdm.Domain.Domain.Fhir;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.Cdm.Domain.Domain.BackBoneElements.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	public class ClaimInsurance: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual bool Focal { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Coverage Coverage { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string PreAuthRef { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual ClaimResponse ClaimResponse { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DisplayFormat(DataFormatString = "0.00")]
		public virtual decimal? Total { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual FhirInvoice Invoice { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "ClaimSubmissionMethod")]
		public virtual long? ClaimSubmissionMethod { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DisplayFormat(DataFormatString = "0.00")]
		public virtual decimal? AmountExcluded { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DisplayFormat(DataFormatString = "0.00")]
		public virtual decimal? PaidToProvider { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[DisplayFormat(DataFormatString = "0.00")]
		public virtual decimal? PaidToMember { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[StringLength(2000)]
		public virtual string RemarksCode { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[StringLength(2000)]
		public virtual string Remarks { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[StringLength(int.MaxValue)]
		public virtual string ResponseSystemMessage { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[StringLength(int.MaxValue)]
		public virtual string ResponseMessage { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual StoredFile ResponseAttachments { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? ResponseDate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "ClaimResponseOutcome")]
		public virtual long? ResponseOutcome { get; set; }
	}
}
