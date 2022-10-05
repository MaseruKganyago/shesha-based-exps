using Boxfusion.Health.HealthCommon.Core.Helpers;
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
				.ForMember(a => a.EmailAddress1, opt => opt.MapFrom(b => b.EmailAddress))
				.ForMember(a => a.WorkTelephone, opt => opt.MapFrom(b => b.WorkTelephoneNo))
				.ForMember(a => a.WorkAddress, opt => opt.Ignore())
				.ForMember(a => a.CommunicationLanguage, opt => opt.MapFrom(b => UtilityHelper.SetMultiValueReferenceList(b.CommunicationLanguage)))
				.MapReferenceListValuesFromDto();
		}
	}
}
