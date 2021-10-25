using Abp.Dependency;
using Abp.Domain.Repositories;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Dtos;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Services.Enums;
using Newtonsoft.Json;
using Shesha.AutoMapper.Dto;
using Shesha.Push;
using Shesha.Push.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Encounters.ConsultationEncounters.Helpers
{
	/// <summary>
	/// 
	/// </summary>
	public class ConsultationEncounterUtilityHelper
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="refListFilterIdType"></param>
		/// <param name="filterId"></param>
		/// <returns></returns>
		public static async Task<List<ConsultationEncounterResponse>> GetAllConsultationEncountersWithBackboneElements(RefListFilterIdType refListFilterIdType, Guid filterId)
		{
			var repository = IocManager.Instance.Resolve<IRepository<ConsultationEncounter, Guid>>();
			var diagnosisRespository = IocManager.Instance.Resolve<IRepository<Diagnosis, Guid>>();
			var encounterLocationRepository = IocManager.Instance.Resolve<IRepository<EncounterLocation, Guid>>();
			var participantRespository = IocManager.Instance.Resolve<IRepository<Participant, Guid>>();
			var mapper = IocManager.Instance.Resolve<IMapper>();

			var entityList = new List<ConsultationEncounter>();

			switch (refListFilterIdType)
			{
				case RefListFilterIdType.patientId:
					entityList = await repository.GetAllListAsync(a => a.Subject.Id == filterId);
					break;
				case RefListFilterIdType.practitionerId:
					entityList = await repository.GetAllListAsync(a => a.Performer.Id == filterId);
					break;
				default:
					entityList = await repository.GetAllListAsync();
					break;
			}

			#region Gets all entitities together with their relations
			var entityResults = (from entity in entityList
								 select new ConsultationEncounterResponse()
								 {
									 Id = entity.Id,
									 Identifier = entity.Identifier,
									 Status = mapper.Map<ReferenceListItemValueDto>((int)entity.Status),
									 Class = mapper.Map<ReferenceListItemValueDto>((int)entity.Class),
									 Type = mapper.Map<ReferenceListItemValueDto>((int)entity.Type),
									 ServiceType = mapper.Map<ReferenceListItemValueDto>((int)entity.ServiceType),
									 Priority = mapper.Map<ReferenceListItemValueDto>((int)entity.Priority),
									 Subject = new EntityWithDisplayNameDto<Guid?>(entity.Subject?.Id, entity.Subject?.FullName),
									 EpisodeOfCare = new EntityWithDisplayNameDto<Guid?>(entity.EpisodeOfCare?.Id, ""),
									 BasedOn = new EntityWithDisplayNameDto<Guid?>(entity.BasedOn?.Id, entity.BasedOn?.Identifier),
									 Performer = new EntityWithDisplayNameDto<Guid?>(entity.Performer?.Id, entity.Performer?.FullName),
									 Appointment = new EntityWithDisplayNameDto<Guid?>(entity.Appointment?.Id, ""),
									 StartDateTime = entity.StartDateTime,
									 EndDateTime = entity.EndDateTime,
									 ReasonCode = UtilityHelper.GetMultiReferenceListItemValueList(entity.ReasonCode),
									 ReasonReferenceOwnerId = entity.ReasonReferenceOwnerId,
									 ReasonReferenceOwnerType = entity.ReasonReferenceOwnerType,
									 ServiceProvider = new EntityWithDisplayNameDto<Guid?>(entity.ServiceProvider?.Id, entity.ServiceProvider?.Name),
									 PartOf = new EntityWithDisplayNameDto<Guid?>(entity.PartOf?.Id, entity.PartOf?.Identifier),
									 Participants = (from participant in participantRespository.GetAll().ToList()
													 where (participant.OwnerId == entity.Id.ToString())
													 select new ParticipantResponse()
													 {
														 Id = participant.Id,
														 OwnerId = participant.OwnerId,
														 OwnerType = participant.OwnerType,
														 Type = mapper.Map<ReferenceListItemValueDto>((int)entity.Priority),
														 StartDateTime = participant.StartDateTime,
														 EndDateTime = participant.EndDateTime,
														 Individual = participant.Individual != null ? new EntityWithDisplayNameDto<Guid?>(participant.Individual.Id, participant.Individual.FullName) : null,
														 Required = mapper.Map<ReferenceListItemValueDto>((int)participant.Required),
														 Status = mapper.Map<ReferenceListItemValueDto>((int)participant.Status),
													 }
													 )?.ToList(),
									 Diagnosis = (from diagnosis in diagnosisRespository.GetAll().ToList()
												  where (diagnosis.OwnerId == entity.Id.ToString())
												  select new DiagnosisResponse()
												  {
													  Id = diagnosis.Id,
													  OwnerId = diagnosis.OwnerId,
													  OwnerType = diagnosis.OwnerType,
													  Condition = mapper.Map<ConditionResponse>(diagnosis.Condition),
													  Use = mapper.Map<ReferenceListItemValueDto>((int)diagnosis.Use),
													  Rank = diagnosis.Rank
												  })?.ToList(),
									 Locations = (from location in encounterLocationRepository.GetAll().ToList()
												  where (location.OwnerId == entity.Id.ToString())
												  select new EncounterLocationResponse()
												  {
													  Id = location.Id,
													  OwnerId = location.OwnerId,
													  OwnerType = location.OwnerType,
													  Location = location.Location != null ? new EntityWithDisplayNameDto<Guid?>(location.Location.Id, location.Location.Name) : null,
													  Status = mapper.Map<ReferenceListItemValueDto>((int)location.Status),
													  PhysicalType = mapper.Map<ReferenceListItemValueDto>((int)location.PhysicalType),
													  StartDateTime = location.StartDateTime,
													  EndDateTime = location.EndDateTime
												  })?.ToList(),

									 //Sub-class properties
									 FollowupIsFeelingBetter = entity.FollowupIsFeelingBetter,
									 FollowupNotificationStatus = mapper.Map<ReferenceListItemValueDto>((int)entity.FollowupNotificationStatus),
									 FollowupRequired = entity.FollowupRequired,
									 FollowupAppointment = new EntityWithDisplayNameDto<Guid?>(entity.FollowupAppointment?.Id, ""),
									 FollowupSuggestion = entity.FollowupSuggestion,
									 CHWWorkOrder = new EntityWithDisplayNameDto<Guid?>(entity.CHWWorkOrder?.Id, ""),
									 Rating = entity.Rating,
									 RatingComment = entity.RatingComment,
									 RatingTime = entity.RatingTime
								 });
			#endregion

			return entityResults?.ToList();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static async Task SendFollowUpPushNotification()
		{
			var repository = IocManager.Instance.Resolve<IRepository<ConsultationEncounter, Guid>>();
			var mapper = IocManager.Instance.Resolve<IMapper>();
			var pushNotification = IocManager.Instance.Resolve<IPushNotifier>();

			var entityList = await repository.GetAllListAsync(a => a.FollowupRequired && checkDate(a.FollowUpDate));

			var tasks = new List<Task>();
			foreach (var entity in entityList)
			{
				tasks.Add(Task.Run(async () =>
				{
					var entityResponse = mapper.Map<ConsultationEncounterResponse>(entity);
					try
					{
						await pushNotification.SendNotificationToPersonAsync(new SendNotificationToPersonInput()
						{
							Body = $"Hi {entity.Subject?.FullName} Please complete the Follow-Up evaluation.",
							Title = "Follow-Up Notification",
							PersonId = (Guid)(entity.Subject?.Id),
							Data = new Dictionary<string, string>()
						{
							{"payload", JsonConvert.SerializeObject(entityResponse)}
						}
						});

						entity.FollowupNotificationStatus = RefListFollowupNotificationStatuses.sent;
						await repository.UpdateAsync(entity);
					}
					catch (Exception)
					{

						entity.FollowupNotificationStatus = RefListFollowupNotificationStatuses.failed;
						await repository.UpdateAsync(entity);
					}

				}));
			}

			await Task.WhenAll(tasks);
		}

		private static bool checkDate(DateTime? followUpDate)
		{
			if (followUpDate == null) return false;

			var todaysDate = DateTime.Now.ToString("MM/dd/yyyy");
			if (followUpDate.Value.ToString("MM/dd/yyyy") == todaysDate) return true;

			return false;
		}
	}
}
