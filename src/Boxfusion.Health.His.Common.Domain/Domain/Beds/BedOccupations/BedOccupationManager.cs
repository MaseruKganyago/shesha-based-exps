using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.UI;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.Beds.BedFees.Enums;
using Boxfusion.Health.His.Common.Beds.Enums;
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
		private readonly IRepository<Bed, Guid> _bedRepository;

		/// <summary>
		/// 
		/// </summary>
		public BedOccupationManager(IRepository<BedOccupation, Guid> bedOccupationRepository, IRepository<Bed, Guid> bedRepository)
		{
			_bedOccupationRepository = bedOccupationRepository;
			_bedRepository = bedRepository;
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
		public async Task<BedOccupation> CreateBedOccupationAsync(BedOccupation bedOccupation, RefListBedOccupationStatus status = RefListBedOccupationStatus.Open)
		{
			var bed = await _bedRepository.GetAsync((Guid)bedOccupation.Bed?.Id);

			if (bed.BedAvailability == RefListBedAvailability.Occupied) throw new UserFriendlyException($"Current bed: {bedOccupation.Bed?.Name} is occupied.");
			if (bed.BedAvailability == RefListBedAvailability.OutOfService) throw new UserFriendlyException($"Current bed: {bedOccupation.Bed?.Name} is Out of service.");

			bedOccupation.Status = status;
			var entity = await _bedOccupationRepository.InsertAsync(bedOccupation);

			//Update used Bed, Availability
			bed.BedAvailability = RefListBedAvailability.Occupied;
			await _bedRepository.UpdateAsync(bed);
			return entity;
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
			bedOccupation.Status = RefListBedOccupationStatus.Closed;
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
												a.Status == RefListBedOccupationStatus.Open);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="charge"></param>
		/// <returns></returns>
		/// <exception cref="UserFriendlyException"></exception>
		public async Task<decimal> GetQuantityFromBedOccupationAsync(HisChargeItem charge)
		{
			var bedOccupation = await _bedOccupationRepository.FirstOrDefaultAsync(a => a.ChargeItem.Id == charge.Id);

			if (bedOccupation.StartDate == null) throw new UserFriendlyException($"BedOccupation for current WardAdmission," +
													$" does not specify StartDate.");

			return DateTime.Now.Subtract(bedOccupation.StartDate.Value).Days;
		}
	}
}
