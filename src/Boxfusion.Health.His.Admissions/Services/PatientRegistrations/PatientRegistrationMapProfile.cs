using Boxfusion.Health.His.Common.Patients;
using Shesha.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.PatientRegistrations
{
	/// <summary>
	/// 
	/// </summary>
	public class PatientRegistrationMapProfile: ShaProfile
	{
		/// <summary>
		/// 
		/// </summary>
		public PatientRegistrationMapProfile()
		{
			CreateMap<RegisterPatientDto, HisPatient>()
				.ForMember(a => a.MobileNumber1, opt => opt.MapFrom(b => b.CellNumber))
				.ForMember(a => a.MobileNumber2, opt => opt.MapFrom(b => b.AlternativeNumber))
				.ForMember(a => a.WorkAddress, opt => opt.Ignore())
				.MapReferenceListValuesFromDto();
		}
	}
}
