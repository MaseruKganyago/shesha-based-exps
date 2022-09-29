using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common.Beds.BedFees.Enums;
using Boxfusion.Health.His.Common.ChargeItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Beds.BedOccupations
{
	/// <summary>
	/// 
	/// </summary>
	public class BedOccupationManager: DomainService
	{
		private readonly IRepository<BedOccupation, Guid> _bedOccupationRepository;

		/// <summary>
		/// 
		/// </summary>
		public BedOccupationManager(IRepository<BedOccupation, Guid> bedOccupationRepository)
		{
			_bedOccupationRepository = bedOccupationRepository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public IRepository<BedOccupation, Guid> repository()
		{
			return _bedOccupationRepository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bedOccupation"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public async Task<BedOccupation> CreateBedOccupationAsync(BedOccupation bedOccupation, RefListBedOccupationStatus status = RefListBedOccupationStatus.open)
		{
			bedOccupation.Status = (long?)status;
			return await _bedOccupationRepository.InsertAsync(bedOccupation);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="currentBedOccupation"></param>
		/// <param name="chargeItem"></param>
		/// <returns></returns>
		public async Task<BedOccupation> CloseAndOpenNewBedOccupationAsync(BedOccupation currentBedOccupation, HisChargeItem chargeItem)
		{
			var closedBedOccupation = await CloseBedOccupationAsync(currentBedOccupation);

			var newBedOccupation = new BedOccupation()
			{
				StartDate = DateTime.Now,
				WardAdmission = closedBedOccupation.WardAdmission,
				Bed = closedBedOccupation.Bed,
				ChargeItem = chargeItem
			};
			return await CreateBedOccupationAsync(newBedOccupation);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bedOccupation"></param>
		/// <returns></returns>
		public async Task<BedOccupation> CloseBedOccupationAsync(BedOccupation bedOccupation)
		{
			bedOccupation.Status = (long?)RefListBedOccupationStatus.closed;
			bedOccupation.EndDate = DateTime.Now;

			return await _bedOccupationRepository.UpdateAsync(bedOccupation);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="wardAdmissionId"></param>
		/// <returns></returns>
		public async Task<BedOccupation> GetOpenBedOccupationByWardAdmissionIdAsync(Guid wardAdmissionId)
		{
			return await _bedOccupationRepository.FirstOrDefaultAsync(a => a.WardAdmission.Id == wardAdmissionId &&
												a.Status == (long?)RefListBedOccupationStatus.open);
		}
	}
}
