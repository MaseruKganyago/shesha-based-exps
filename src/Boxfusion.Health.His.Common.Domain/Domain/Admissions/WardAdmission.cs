using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Common.Beds;
using Boxfusion.Health.His.Common.Domain.Domain.Room;
using Boxfusion.Health.His.Common.Enums;
using Shesha.Domain.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boxfusion.Health.His.Common.Admissions
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.WardAdmission")]
    [Table("Fhir_Encounters")]
    public class WardAdmission : HisAdmission
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual HisWard Ward { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string WardAdmissionNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListAdmissionTypes? AdmissionType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListAdmissionStatuses? AdmissionStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListTransferRejectionReasons? TransferRejectionReason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string TransferRejectionReasonComment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListSeparationTypes? SeparationType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual HisWard SeparationDestinationWard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual RefListSeparationChildHealths? SeparationChildHealth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? SeparationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string SeparationComment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool CapturedAfterApproval { get; set; }

        /// <summary>
        /// Used to like the serparations
        /// </summary>
        public virtual WardAdmission InternalTransferOriginalWard { get; set; }

        /// <summary>
        /// Used to like the serparations
        /// </summary>
        public virtual WardAdmission InternalTransferDestinationWard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Bed Bed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Room Room { get; set; }
    }
}
