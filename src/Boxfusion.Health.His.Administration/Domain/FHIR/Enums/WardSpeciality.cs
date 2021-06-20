using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.Enums
{
    /// <summary>
    /// Ward speciality e.g. medicine, surgery etc. A speciality can have more than one ward
    /// </summary>
    [ReferenceList("HealthDomain", "WardSpeciality")]
    public enum RefListWardSpeciality : int
    {
        /// <summary>
        /// Medicine speciality
        /// </summary>
        Medicine = 1,
        /// <summary>
        /// Orthopaedics speciality
        /// </summary>
        Orthopaedics = 2,
        /// <summary>
        /// Surgery speciality
        /// </summary>
        Surgery = 3,
        /// <summary>
        /// Gynaecology speciality
        /// </summary>
        Gynaecology = 4,
        /// <summary>
        /// Maternity speciality
        /// </summary>
        Maternity = 5,
        /// <summary>
        /// Paediatrics speciality
        /// </summary>
        Paediatrics = 6,
        /// <summary>
        /// Psychiatry  speciality
        /// </summary>
        Psychiatry = 7
    }
}
