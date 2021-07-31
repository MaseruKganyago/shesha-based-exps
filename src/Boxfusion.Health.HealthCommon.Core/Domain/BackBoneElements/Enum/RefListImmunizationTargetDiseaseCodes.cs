using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
	[ReferenceList("Fhir", "ImmunizationTargetDiseaseCodes")]
	public enum RefListImmunizationTargetDiseaseCodes: int
	{
		[Description("Gestational Rubella Syndrome")]
		gestationalRubellaSyndrome = 1,
		[Description("Diphtheria due to Corynebacterium Diphtheriae")]
		diphtheriaDueToCorynebacteriumDiphtheriae = 2,
		[Description("Measles")]
		measles = 4,
		[Description("Mumps")]
		mumps = 8,
		[Description("Rubella")]
		rubella = 16,
		[Description("Tetanus")]
		tetanus = 32,
		[Description("Haemophilus influenzae type b infection")]
		haemophilusInfluenzaTypeBInfection = 64,
		[Description("Pertussis")]
		pertussis = 128,
		[Description("Acute Poliomyelitis")]
		acutePoliomyelitis = 256
	}
}
