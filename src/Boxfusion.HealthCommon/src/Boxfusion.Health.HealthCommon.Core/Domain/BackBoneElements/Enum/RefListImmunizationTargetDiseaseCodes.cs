using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Fhir", "ImmunizationTargetDiseaseCodes")]
	public enum RefListImmunizationTargetDiseaseCodes: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Gestational Rubella Syndrome")]
		gestationalRubellaSyndrome = 1,

		/// <summary>
		/// 
		/// </summary>
		[Description("Diphtheria due to Corynebacterium Diphtheriae")]
		diphtheriaDueToCorynebacteriumDiphtheriae = 2,

		/// <summary>
		/// 
		/// </summary>
		[Description("Measles")]
		measles = 4,

		/// <summary>
		/// 
		/// </summary>
		[Description("Mumps")]
		mumps = 8,

		/// <summary>
		/// 
		/// </summary>
		[Description("Rubella")]
		rubella = 16,

		/// <summary>
		/// 
		/// </summary>
		[Description("Tetanus")]
		tetanus = 32,

		/// <summary>
		/// 
		/// </summary>
		[Description("Haemophilus influenzae type b infection")]
		haemophilusInfluenzaTypeBInfection = 64,

		/// <summary>
		/// 
		/// </summary>
		[Description("Pertussis")]
		pertussis = 128,

		/// <summary>
		/// 
		/// </summary>
		[Description("Acute Poliomyelitis")]
		acutePoliomyelitis = 256
	}
}
