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

namespace Boxfusion.Health.His.Common.Beds.BedFees
{
	/// <summary>
	/// 
	/// </summary>
	public class BedFeeManager: DomainService
	{
		private readonly IRepository<BedFee, Guid> _bedFeeRepository;

		/// <summary>
		/// 
		/// </summary>
		public BedFeeManager(IRepository<BedFee, Guid> bedFeeRepository)
		{
			_bedFeeRepository = bedFeeRepository;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bedFee"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		public async Task<BedFee> CreateBedFeeAsync(BedFee bedFee, RefListBedFeeStatus status = RefListBedFeeStatus.open)
		{
			bedFee.Status = (long?)status;
			return await _bedFeeRepository.InsertAsync(bedFee);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="currentBedFeeId"></param>
		/// <param name="newChargeItem"></param>
		/// <returns></returns>
		public async Task<BedFee> CloseAndOpenNewBedFeeAsync(Guid currentBedFeeId, HisChargeItem newChargeItem)
		{
			var closedBedFee = await CloseBedFeeAsync(currentBedFeeId);

			var newBedFee = new BedFee()
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
		/// <param name="bedFeeId"></param>
		/// <returns></returns>
		public async Task<BedFee> CloseBedFeeAsync(Guid bedFeeId)
		{
			var bedFee = await _bedFeeRepository.GetAsync(bedFeeId);

			bedFee.Status = (long?)RefListBedFeeStatus.closed;
			bedFee.EndDate = DateTime.Now;

			return await _bedFeeRepository.UpdateAsync(bedFee);
		}
	}
}
