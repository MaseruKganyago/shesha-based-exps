using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos
{
	/// <summary>
	/// 
	/// </summary>
	public class ValidateIdDto
	{
		/// <summary>
		/// 
		/// </summary>
		public string IdentityNumber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public Guid CurrentWardId { get; set; }
	}
}
