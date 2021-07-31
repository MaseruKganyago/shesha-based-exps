using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
	[ReferenceList("Fhir", "SNOMEDCTAdditionalDosageInstructions")]
	public enum RefListSNOMEDCTAdditionalDosageInstructions: int
	{
		[Description("Half to one hour before food")]
		halfToOneHourbeforeFood = 311501008,
		[Description("With or after food")]
		withOrAfterFood = 311504000,
		[Description("Times")]
		times = 417929005,
		[Description("Contains aspirin")]
		containsAspirin = 417980006,
		[Description("Dissolve or mix with water before taking")]
		dissolveOrMixWithWaterbeforeTaking = 417995008,
		[Description("Warning. Causes drowsiness which may continue the next day. If affected do not drive or operate machinery. Avoid alcoholic drink")]
		warningCausesDrownsinessWhichMayContinueTheNextDayIfAffectedDoNotDriveOrOperateMachineryAvoidAlcoholicDrink = 418071006,
		[Description("Contains an aspirin-like medicine")]
		containsAnAspirinLikeMedicine = 418194009,
		[Description("Do not take anything containing aspirin while taking this medicine")]
		doNotTakeAnythingContainingAspirinWhileTakingThisMedicine = 418281004,
		[Description("Do not take more than . . . in 24 hours or . . . in any one week")]
		doNotTakeMoreThanIn24HoursOrInAnyOneWeek = 418443006,
		[Description("Avoid exposure of skin to direct sunlight or sun lamps")]
		avoidExposureOfSkinToDirectSunlightOrSunLamps = 418521000,
		[Description("Take at regular intervals. Complete the prescribed course unless otherwise directed")]
		takeAtRegularIntervalsCompleteThePrescribedCourseUnlessOtherwiseDirected = 418577003,
		[Description("Do not take with any other paracetamol products")]
		doNotTakeWithAnyParacetamolProducts = 418637003,
		[Description("Warning. May cause drowsiness")]
		warningMayCauseDrowsiness = 418639000,
		[Description("Swallowed whole, not chewed")]
		swallowedWholeNotChewed = 418693002,
		[Description("Warning. Follow the printed instructions you have been given with this medicine")]
		warningFollowThePrintedInstructionsYouHaveBeenGivenWithThisMedicine = 418849000,
		[Description("Contains aspirin and paracetamol. Do not take with any other paracetamol products")]
		containsAspirinAndParacetamolDonotTakeWithAnyOtherParacetamolProducts = 418850000,
		[Description("Warning. May cause drowsiness. If affected do not drive or operate machinery. Avoid alcoholic drink")]
		warningMayCausesDrownsinessWhichMayContinueTheNextDayIfAffectedDoNotDriveOrOperateMachineryAvoidAlcoholicDrink = 418914006,
		[Description("Sucked or chewed")]
		suckedOrChewed = 418991002,
		[Description("Allow to dissolve under the tongue. Do not transfer from this container. Keep tightly closed. Discard eight weeks after opening")]
		allowToDissolveUnderTheTongueDoNotTransferFromThisContainerKeepTightlyClosedDiscardEightWeeksAfterOpening = 419111009,
		[Description("Do not take milk, indigestion remedies, or medicines containing iron or zinc at the same time of day as this medicine")]
		doNotTakeMilkIndigestionRemediesOrMedicinesContainingIronOrZincAtTheSameTimeOfDayAsThisMedicine = 419115000,
		[Description("With plenty of water")]
		withPlentyOfWater = 419303009,
		[Description("Do not take more than 2 at any one time. Do not take more than 8 in 24 hours")]
		doNotTakeMoreThan2AtAnyOneTimeDoNotTakeMoreThan8In24Hours = 419437002,
		[Description("Caution flammable: keep away from fire or flames")]
		cautionFlammableKeepAwayFromFireOrFlames = 419439004,
		[Description("Do not stop taking this medicine except on your doctor's advice")]
		doNotStopTakingThisMedicineExceptOnYourDoctorsAdvice = 419444006,
		[Description("Each")]
		each = 419473009,
		[Description("Dissolved under the tongue")]
		dissolveUnderTheTongue = 419529008,
		[Description("Warning. Avoid alcoholic drink")]
		warningAvoidAlcoholicDrink = 419822006,
		[Description("This medicine may color the urine")]
		thisMedicineMayColorTheUrine = 419974005,
		[Description("Do not take more than . . . in 24 hours")]
		doNotTakeMoreThanIn24Hours = 420003005,
		[Description("Do not take indigestion remedies or medicines containing iron or zinc at the same time of day as this medicine")]
		doNotTakeIndigestionRemediesOrMedicinesContainingIronOrZincAtTheSameTimeOfDayAsThisMedicine = 420082003,
		[Description("Do not take indigestion remedies at the same time of day as this medicine")]
		doNotTakeIndigestionRemediesAtTheSameTimeOfDayAsThisMedicine = 420110001,
		[Description("To be spread thinly")]
		toBeSpreadThinly = 420162004,
		[Description("Until gone")]
		untilGone = 420652005,
		[Description("Then discontinue")]
		thenDiscontinue = 421484000,
		[Description("Follow directions")]
		followDirections = 421769005,
		[Description("Until finished")]
		untilFinished = 421984009,
		[Description("Then stop")]
		thenStop = 422327006,
		[Description("Use with caution")]
		useWithCaution = 428579001,
		[Description("Take on an empty stomach")]
		takeOnAnEmptyStomach = 717154004
	}
}
