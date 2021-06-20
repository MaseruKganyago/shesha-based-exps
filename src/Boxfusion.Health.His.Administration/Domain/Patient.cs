using Boxfusion.Health.Domain.Domain.DataTypes;
using Boxfusion.Health.Domain.Domain.Enums;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Domain
{
    /// <summary>
    /// Patient resource inherits from shesha person
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.Patient")]
    public class Patient<T> : Person where T : struct, IComparable, IConvertible, IFormattable
    {
        /// <summary>
        /// Identifier(s) by which this encounter is known. (This is a business identifier, not a resource identifier)
        /// </summary>
        public virtual Identifier<T> Identifier { get; set; }

        /// <summary>
        /// Patient number issued by the hospital or clinic or private practice etc.
        /// </summary>
        public virtual string OrganisationPatientNumber { get; set; }
        /// <summary>
        /// The patient's identification number issued by the South African government
        /// </summary>
        public virtual RefListIdentificationType? IdentificationType { get; set; }
        /// <summary>
        /// Passport number issued by any government
        /// </summary>
        public virtual string PassportNumber { get; set; }
        /// <summary>
        /// Immigration number issued by the South African government to all legal foreign nationals
        /// </summary>
        public virtual string ImmigrationNumber { get; set; }
        /// <summary>
        /// Asylum seeker number issued to all persons seeking asylum in South Africa
        /// </summary>
        public virtual string AsylumNumber { get; set; }
        /// <summary>
        /// Other for of identification number
        /// </summary>
        public virtual string OtherIdentificationNumber { get; set; }
        /// <summary>
        /// Patient's province of residence
        /// </summary>
        public virtual RefListProvince? PatientProvince { get; set; }
        /// <summary>
        /// Patient's nationality
        /// </summary>
        public virtual RefListCountry? Nationality { get; set; }
    }
}
