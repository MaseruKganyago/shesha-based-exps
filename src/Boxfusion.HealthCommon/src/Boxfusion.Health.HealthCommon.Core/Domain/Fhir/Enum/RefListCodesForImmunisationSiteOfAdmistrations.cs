using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
	/// <summary>
	/// 
	/// </summary>
	[ReferenceList("Fhir", "CodesForImmunizationSiteOfAdministrations")]
	public enum RefListCodesForImmunisationSiteOfAdmistrations: long
	{
		/// <summary>
		/// 
		/// </summary>
		[Description("Bilateral Ears (BE)")]
		bilateralEars = 1,
		/// <summary>
		/// 
		/// </summary>
		[Description("Bilateral Nares (BN)")]
		bilateralNares = 2,
		/// <summary>
		/// 
		/// </summary>
		[Description("Buttock (BU)")]
		buttock = 3,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Arm (LA)")]
		leftArm = 4,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Anterior Chest (LAC)")]
		leftAnteriorChest = 5,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Antecubital Fossa (LACF)")]
		leftAntecubitalFossa = 6,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Deltoid (LD)")]
		leftDeltoid = 7,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Ear (LE)")]
		leftEar = 8,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left External Jugular (LEJ)")]
		leftExternalJugular = 9,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Foot (LF)")]
		leftFoot = 10,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Gluteus Medius (LG)")]
		leftGluteusMedius = 11,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Hand (LH)")]
		leftHand = 12,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Internal Jugular (LIJ)")]
		leftInternalJugular = 13,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Lower ABD Quadrant (LLAQ)")]
		leftLowerABDQuadrant = 14,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Lower Forearm (LLFA)")]
		leftLowerForearm = 15,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Mid Forearm (LMFA)")]
		leftMidForearm = 16,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Naris (LN)")]
		leftNaris = 17,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Post Chest (LPC)")]
		leftPostChest = 18,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Subclavian (LSC)")]
		leftSubclavian = 19,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Thigh (LT)")]
		leftThigh = 20,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Upper Arm (LUA)")]
		leftUpperArm = 21,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Upper ABD Quadrant (LUAQ)")]
		leftUpperABDQuadrant = 22,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Upper Forearm (LUFA)")]
		leftUpperForearm = 23,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Ventragluteal (LVG)")]
		leftVentragluteal = 24,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Vastus Lateralis (LVL)")]
		leftVastusLateralis = 25,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Eye (OD)")]
		rightEye = 26,
		/// <summary>
		/// 
		/// </summary>
		[Description("Left Eye (OS)")]
		leftEye = 27,
		/// <summary>
		/// 
		/// </summary>
		[Description("Bilateral Eyes")]
		bilateralEyes = 28,
		/// <summary>
		/// 
		/// </summary>
		[Description("Perianal (PA)")]
		perianal = 29,
		/// <summary>
		/// 
		/// </summary>
		[Description("Perineal (PERIN)")]
		perineal = 30,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Arm (RA)")]
		rightArm = 31,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Anterior Chest (RAC)")]
		rightAnteriorChest = 32,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Antecubital Fossa (RACF)")]
		rightAntecubitalFossa = 33,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Deltoid (RD)")]
		rightDeltoid = 34,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Ear (RE)")]
		rightEar = 35,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right External Jugular (REJ)")]
		rightExternalJugular = 36,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Foot (RF)")]
		rightFoot = 37,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Gluteus Medius (RG)")]
		rightGluteusMedius = 38,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Hand (RH)")]
		rightHand = 39,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Internal Jugular (RIJ)")]
		rightInternalJugular = 40,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Lower ABD Quadrant")]
		rightLowerABDQuadrant = 41,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Lower Forearm (RLFA)")]
		rightLowerForearm = 42,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right mid Forearm (RMFA)")]
		rightMidForearm = 43,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Naris (RN)")]
		rightNaris = 44,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Posterior Chest (RPC)")]
		rightPosteriorChest = 45,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Subclavian (RSC)")]
		rightSubclavian = 46,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Thigh (RT)")]
		rightThigh = 47,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Upper arm (RUA)")]
		rightUpperArm = 48,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Upper ABD Quadrant (RUAQ)")]
		rightUpperABDQuadrant = 49,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Upper Forearm (RUFA)")]
		rightUpperForearm = 50,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Ventragluteal (RVG)")]
		rightVentragluteal = 51,
		/// <summary>
		/// 
		/// </summary>
		[Description("Right Vastus Lateralis (RVL)")]
		rightVastusLateralis = 52

	}
}
