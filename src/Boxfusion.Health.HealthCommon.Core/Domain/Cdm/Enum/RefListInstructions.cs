using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum
{
    /// <summary>
    /// 
    /// </summary>
	[ReferenceList("Cdm", "Instructions")]
    public enum RefListInstructions : long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Before meals")]
        BeforeMeals = 1,
        /// <summary>
        /// 
        /// </summary>
        [Description("At bedtime")]
        AtBedtime = 2,
        /// <summary>
        /// 
        /// </summary>
        [Description("Between meals")]
        BetweenMeals = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("After meals")]
        AfterMeals = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Before meals and at bedtime")]
        BeforeMealsAndAtBedtime = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("Before breakfast")]
        BeforeBreakfast = 6,

        /// <summary>
        /// 
        /// </summary>
        [Description("Before breakfast and dinner")]
        BeforeBreakfastAndDinner = 7,

        /// <summary>
        /// 
        /// </summary>
        [Description("Before breakfast and lunch")]
        BeforeBreakfastAndLunch = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("Before dinner")]
        BeforeDinner = 9,

        /// <summary>
        /// 
        /// </summary>
        [Description("Before lunch")]
        BeforeLunch = 10,

        /// <summary>
        /// 
        /// </summary>
        [Description("Before lunch and dinner")]
        BeforeLunchAndDinner = 11,

        /// <summary>
        /// 
        /// </summary>
        [Description("After meals and at bedtime")]
        AfterMealsAndAtBedtime = 12,

        /// <summary>
        /// 
        /// </summary>
        [Description("After breakfast")]
        AfterBreakfast = 13,

        /// <summary>
        /// 
        /// </summary>
        [Description("After breakfast and dinner")]
        AfterBreakfastAndDinner = 14,

        /// <summary>
        /// 
        /// </summary>
        [Description("After breakfast and lunch")]
        AfterBreakfastAndLunch = 15,

        /// <summary>
        /// 
        /// </summary>
        [Description("After dinner")]
        AfterDinner = 16,

        /// <summary>
        /// 
        /// </summary>
        [Description("After lunch")]
        AfterLunch = 17,

        /// <summary>
        /// 
        /// </summary>
        [Description("After lunch and dinner")]
        AfterLunchAndDinner = 18,

        /// <summary>
        /// 
        /// </summary>
        [Description("As directed")]
        AsDirected = 19,

        /// <summary>
        /// 
        /// </summary>
        [Description("With breakfast")]
        WithBreakfast = 20,

        /// <summary>
        /// 
        /// </summary>
        [Description("With breakfast and dinner")]
        WithBreakfastAndDinner = 21,

        /// <summary>
        /// 
        /// </summary>
        [Description("With breakfast and lunch")]
        WithBreakfastAndLunch = 22,

        /// <summary>
        /// 
        /// </summary>
        [Description("With dinner")]
        WithDinner = 23,

        /// <summary>
        /// 
        /// </summary>
        [Description("With lunch")]
        WithLunch = 24,

        /// <summary>
        /// 
        /// </summary>
        [Description("With lunch and dinner")]
        WithLunchAndDinner = 25,

        /// <summary>
        /// 
        /// </summary>
        [Description("With meals")]
        WithMeals = 26,

        /// <summary>
        /// 
        /// </summary>
        [Description("With meals and at bedtime")]
        WithMealsAndAtBbedtime = 27
    }
}
