using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// This value set defines a set of codes that can be used to indicate dietary preferences or restrictions a patient may have.
    /// </summary>
    [ReferenceList("HealthDomain", "EncounterDiet")]
    public enum RefListEncounterDiet : int
    {
        /// <summary>
        /// Food without meat, poultry or seafood.
        /// </summary>
        [Description("Vegetarian")]
        vegetarian = 1,
        /// <summary>
        /// Excludes dairy products.
        /// </summary>
        [Description("Dairy Free")]
        dairyFree = 2,
        /// <summary>
        /// Excludes ingredients containing nuts.
        /// </summary>
        [Description("Nut Free")]
        nutFree = 3,
        /// <summary>
        /// Excludes ingredients containing gluten.
        /// </summary>
        [Description("Gluten Free")]
        glutenFree = 4,
        /// <summary>
        /// Food without meat, poultry, seafood, eggs, dairy products and other animal-derived substances.
        /// </summary>
        [Description("Vegan")]
        vegan = 5,
        /// <summary>
        /// Foods that conform to Islamic law.
        /// </summary>
        [Description("Halal")]
        halal = 6,
        /// <summary>
        /// Foods that conform to Jewish dietary law.
        /// </summary>
        [Description("Kosher")]
        kosher = 7,
    }
}
