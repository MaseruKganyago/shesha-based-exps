using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Invoices
{
	/// <summary>
	/// 
	/// </summary>
	public class SplitBillInvoiceDto: EntityDto<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public Guid PatientAccountId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[Required]
		public DateTime OccurenceDate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public List<Guid> ChargeItemIds { get; set; }
	}
}
