using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.His.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Domain.Dtos
{
	/// <summary>
	/// 
	/// </summary>
	[AutoMapFrom(typeof(HisAdmission))]
	public class HisAdmissionResponse: HospitalisationEncounterResponse
	{
	}
}
