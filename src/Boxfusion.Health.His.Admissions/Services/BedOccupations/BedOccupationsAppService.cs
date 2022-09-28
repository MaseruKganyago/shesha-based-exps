using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.Beds;
using Boxfusion.Health.His.Common.Beds.BedFees.Enums;
using Boxfusion.Health.His.Common.Beds.BedOccupations;
using Boxfusion.Health.His.Common.ChargeItems;
using Microsoft.AspNetCore.Mvc;
using Shesha;
using Shesha.DynamicEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.BedOccupations
{
	/// <summary>
	/// 
	/// </summary>
	[AbpAuthorize]
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/His/[controller]")]
	public class BedOccupationsAppService: SheshaAppServiceBase
	{
		private readonly BedOccupationManager _bedOccupationManager;
		private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepository;
		private readonly IRepository<Bed, Guid> _bedRepository;
		private readonly HisChargeItemsManager _chargeItemManager;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bedOccupationManager"></param>
		/// <param name="wardAdmissionRepository"></param>
		/// <param name="bedRepository"></param>
		/// <param name="chargeItemManager"></param>
		public BedOccupationsAppService(BedOccupationManager bedOccupationManager,
			IRepository<WardAdmission, Guid> wardAdmissionRepository,
			IRepository<Bed, Guid> bedRepository,
			HisChargeItemsManager chargeItemManager)
		{
			_bedOccupationManager = bedOccupationManager;
			_wardAdmissionRepository = wardAdmissionRepository;
			_chargeItemManager = chargeItemManager;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="wardAdmissionId"></param>
		/// <param name="bedId"></param>
		/// <returns></returns>
		public async Task<DynamicDto<BedOccupation, Guid>> ChangeBedOccupation(Guid wardAdmissionId, Guid bedId)
		{
			var admission = await _wardAdmissionRepository.GetAsync(wardAdmissionId);
			var bed = await _bedRepository.GetAsync(bedId);

			admission.Bed = bed;
			await _wardAdmissionRepository.UpdateAsync(admission);

			var chargeItem = await _chargeItemManager.GetOpenChargeItemByServiceIdAsync(wardAdmissionId);
			var currentBedFee = await _bedOccupationManager.GetOpenBedOccupationByWardAdmissionIdAsync(wardAdmissionId);

			var newBedOccupation = await _bedOccupationManager.CloseAndOpenNewBedFeeAsync(currentBedFee, chargeItem);

			return await MapToDynamicDtoAsync<BedOccupation, Guid>(newBedOccupation);
		}
	}
}
