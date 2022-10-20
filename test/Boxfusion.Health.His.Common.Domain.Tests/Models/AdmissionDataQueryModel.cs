﻿using System;

namespace Boxfusion.Health.His.Common.Tests.Models
{
	public class AdmissionDataQueryModel
	{
		public Guid Id { get; set; }
		public string WardAdmissionNumber { get; set; }
		public long AdmissionType { get; set; }
		public long WardAdmissionStatus { get; set; }
		public DateTime StartDateTime { get; set; }
		public Guid PartOfId { get; set; }
	}
}