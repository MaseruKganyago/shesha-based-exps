using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum
{
	[ReferenceList("Fhir", "SNOMEDCTAdministrationMethodCodes")]
	public enum RefListSNOMEDCTAdministrationMethodCodes: long
	{
		[Description("Apply")]
		apply = 417924000,
		[Description("Administer")]
		administer = 418283001,
		[Description("Use")]
		use = 419385000,
		[Description("Give")]
		give = 419582001,
		[Description("Take")]
		take = 419652001,
		[Description("Chew")]
		chew = 419747000,
		[Description("Suck")]
		suck = 420045007,
		[Description("At")]
		at = 420246001,
		[Description("Dosing Instruction Imperative")]
		dosingInstructionImperative = 420247005,
		[Description("Only")]
		only = 420295001,
		[Description("Constant")]
		constant = 420341009,
		[Description("Sniff")]
		sniff = 420360002,
		[Description("Subtract - dosing instruction fragment")]
		subtractDosingInstructionFragment = 420484009,
		[Description("As")]
		as420503003 = 420503003,
		[Description("Or")]
		or = 420561004,
		[Description("Finish")]
		finish = 420604000,
		[Description("Shampoo")]
		shampoo = 420606003,
		[Description("Push")]
		push = 420620005,
		[Description("Until gone")]
		untilGone = 420652005,
		[Description("Upon")]
		upon = 420771004,
		[Description("Per")]
		per = 420806001,
		[Description("Sparingly")]
		sparingly = 420883007,
		[Description("Call")]
		call = 420942008,
		[Description("When")]
		when = 420974001,
		[Description("To")]
		to = 421035004,
		[Description("Place")]
		place = 421066005,
		[Description("Then")]
		then = 421067001,
		[Description("Inhale")]
		inhale = 421134003,
		[Description("Hold")]
		hold = 421139008,
		[Description("Multiply")]
		multiply = 421206002,
		[Description("Insert")]
		insert = 421257003,
		[Description("Discontinue")]
		discontinue = 421286000,
		[Description("Swish and swallow")]
		swishAndSwallow = 421298005,
		[Description("Dilute")]
		dilute = 421399004,
		[Description("With")]
		with = 421463005,
		[Description("Then discontinue")]
		thenDiscontinue = 421484000,
		[Description("Swallow")]
		swallow = 421521009,
		[Description("Instill")]
		instill = 421538008,
		[Description("Until")]
		until = 421548005,
		[Description("Every")]
		every = 421612001,
		[Description("Dissolve")]
		dissolve = 421682005,
		[Description("Before")]
		before = 421718005,
		[Description("Now")]
		now = 421723005,
		[Description("Follow Directions")]
		followDirections = 421769005,
		[Description("If")]
		if421803000 = 421803000,
		[Description("Swish")]
		swish = 421805007,
		[Description("And")]
		and = 421829000,
		[Description("Twice")]
		twice = 421832002,
		[Description("Follow")]
		follow = 421939007,
		[Description("Until Finished")]
		untilFinished = 421984009,
		[Description("During")]
		during = 421994004,
		[Description("Divide")]
		divide = 422033008,
		[Description("Add")]
		add = 422106007,
		[Description("Once")]
		once = 422114001,
		[Description("Ïnject")]
		inject = 422145002,
		[Description("Wash")]
		wash = 422152000,
		[Description("Sprinkle")]
		sprinkle = 422219000,
		[Description("Then Stop")]
		thenStop = 422327006
	}
}
