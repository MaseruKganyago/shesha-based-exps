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
		/// <param name="bedFee"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public async Task<BedOccupation> CreateBedFeeAsync(BedOccupation bedFee, RefListBedOccupationStatus status = RefListBedOccupationStatus.open)
		{
			bedFee.Status = (long?)status;
			return await _bedOccupationRepository.InsertAsync(bedFee);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="currentBedFee"></param>
		/// <param name="newChargeItem"></param>
		/// <returns></returns>
		public async Task<BedOccupation> CloseAndOpenNewBedFeeAsync(BedOccupation currentBedFee, HisChargeItem newChargeItem)
		{
			var closedBedFee = await CloseBedFeeAsync(currentBedFee);

			var newBedFee = new BedOccupation()
			{
				StartDate = DateTime.Now,
				WardAdmission = closedBedFee.WardAdmission,
				Bed = closedBedFee.Bed,
				ChargeItem = newChargeItem
			};
			return await CreateBedFeeAsync(newBedFee);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bedFee"></param>
		/// <returns></returns>
		public async Task<BedOccupation> CloseBedFeeAsync(BedOccupation bedFee)
		{
			bedFee.Status = (long?)RefListBedOccupationStatus.closed;
			bedFee.EndDate = DateTime.Now;

			return await _bedOccupationRepository.UpdateAsync(bedFee);
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
