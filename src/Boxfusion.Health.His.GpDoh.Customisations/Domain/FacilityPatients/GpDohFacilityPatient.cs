using Boxfusion.Health.His.Common.Patients;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.GpDoh.Domain.FacilityPatients
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "GpDoh.FacilityPatient")]
	[DiscriminatorValue("His.HisPatient")]
	[Discriminator]
	public  class GpDohFacilityPatient: FacilityPatient
	{
	}
}
