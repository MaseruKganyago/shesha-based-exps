using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Shesha.Domain;
using Shesha.Extensions;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.WardRoleAppointedPersons
{
	/// <summary>
	/// 
	/// </summary>
	public  class WardRoleAppointedPersonManager: DomainService
	{
		private readonly IRepository<HisHealthFacility, Guid> _facilityRep;

		/// <summary>
		/// 
		/// </summary>
		public WardRoleAppointedPersonManager()
		{
			_facilityRep = StaticContext.IocManager.Resolve<IRepository<HisHealthFacility, Guid>>();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="ward"></param>
		/// <returns></returns>
		public HisHealthFacility GetFacilityFromWard(HisWard ward)
		{
			return _facilityRep.FirstOrDefault(a => a.Id == ward.OwnerOrganisation.Id);
		}
	}
}
