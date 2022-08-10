using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	[ReferenceList("Fhir", "ProcedureFollowUpCodes")]
	public enum RefListProcedureFollowUp: long
	{
		[Description("Change of dressing")]
		changeOfDressing = 1,

		[Description("Removal of suture")]
		removalOfSuture = 2,

		[Description("Removal of drain")]
		removalOfDrain = 4,

		[Description("Removal of staples")]
		removalOfStaples = 8,

		[Description("Removal of ligature")]
		removalOfLigature = 16,

		[Description("Cardiopulmonary exercise test")]
		cardiopulmonaryExerciseTest = 32,

		[Description("Scar tissue massage")]
		scarTissueMassage = 64,

		[Description("Suction drainage")]
		suctionDrainage = 128,

		[Description("Diabetes medication review")]
		diabetesMedicationReview = 256,

		[Description("Cytopathology, review of bronchioalveolar lavage specimen")]
		cytopathologyReviewOfBronchioaveolarLavageSpecimen = 512
	}
}
