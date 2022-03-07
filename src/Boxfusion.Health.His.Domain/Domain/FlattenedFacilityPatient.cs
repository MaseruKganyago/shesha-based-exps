using Abp.Domain.Entities;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.His.Domain
{
    /// <summary>
    /// Flattened/Optimised version of the Patient record joining in the Facility specific Patient Identifier.
    /// </summary>
    [Entity(TypeShortAlias = "His.FlattenedFacilityPatient")]

    [Table("vw_His_FlattenedFacilityPatients")]
    [ImMutable]
    public class FlattenedFacilityPatient : Entity<Guid>
    {
        [ReferenceList("Shesha.Core", "PersonTitles")] 
        public virtual long? Title { get; protected set; }
        public virtual string IdentityNumber { get; protected set; }
        public virtual string PatientMasterIndexNumber { get; protected set; }
        public virtual string FacilityPatientIdentifier { get; protected set; }
        public virtual string PassportNumber { get; protected set; }
        public virtual string PermitNumber { get; protected set; }
        public virtual string DispensaryNumber { get; protected set; }

        [ReferenceList("His", "IdentificationTypes")]
        public virtual long? IdentificationType { get; protected set; }

        public virtual string Initials { get; protected set; }
        public virtual string FirstName { get; protected set; }
        public virtual string LastName { get; protected set; }
        public virtual string MobileNumber1 { get; protected set; }
        public virtual string MobileNumber2 { get; protected set; }
        public virtual DateTime? DateOfBirth { get; protected set; }
        public virtual string EmailAddress1 { get; protected set; }
        public virtual string EmailAddress2 { get; protected set; }
        public virtual bool EmailAddressConfirmed { get; protected set; }
        
        [ReferenceList("Shesha.Core", "Gender")]
        public virtual long? Gender { get; protected set; }

        public virtual string HomeNumber { get; protected set; }
        
        [ReferenceList("Shesha.Core", "PreferredContactMethod")]
        public virtual long? PreferredContactMethod { get; protected set; }
        //public virtual long? TypeOfAccountLkp { get; protected set; }
        public virtual bool DetailsValidated { get; protected set; }
        public virtual Guid? PostalAddressId { get; protected set; }    //TODO: ???
        public virtual Guid? ResidentialAddressId { get; protected set; }  //TODO: ???
        public virtual long? UserId { get; protected set; }
        public virtual string FullName { get; protected set; }
        public virtual string FullName2 { get; protected set; }
        
        [ReferenceList("Shesha.Core", "CommonLanguage")]
        public virtual long? CommunicationLanguage { get; protected set; }

        [ReferenceList("Cdm", "Countries")]
        public virtual long? Nationality { get; protected set; }
        
        [ReferenceList("Cdm", "PersonEthnicity")]
        public virtual long? Ethnicity { get; protected set; }
        
        public virtual string OtherIdentityNumber { get; protected set; }
        
        [ReferenceList("Fhir", "MaritalStatus")]
        public virtual long? MaritalStatus { get; protected set; }
        public virtual string GeneralPractitioner { get; protected set; }
        public virtual bool IsDisabled { get; protected set; }
        public virtual bool IsEmployed { get; protected set; }
        public virtual bool HasMedicalAid { get; protected set; }
        public virtual string MedicalAidName { get; protected set; }
        public virtual string MedicalAidNumber { get; protected set; }
        
        [ReferenceList("His", "Provinces")]
        public virtual long? PatientProvince { get; protected set; }
        public virtual Guid? FacilityId { get; protected set; }
        public virtual string FacilityName { get; protected set; }
        public virtual string FacilityDiscriminator { get; protected set; }
        public virtual DateTime? CreationTime { get; protected set; }
        public virtual long? CreatorUserId { get; protected set; }
        public virtual DateTime? LastModificationTime { get; protected set; }
        public virtual long? LastModifierUserId { get; protected set; }

    }
}
