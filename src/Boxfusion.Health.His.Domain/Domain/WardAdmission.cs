using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Shesha.Domain.Attributes;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Boxfusion.Health.His.Domain.Domain
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
        public virtual Ward Ward { get; set; }
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


        //public virtual Ward AdmissionDestinationWard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Ward SeparationDestinationWard { get; set; }

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


        // public virtual HisAdmission HisAdmission { get; set; }

        /// <summary>
        /// Used to like the serparations
        /// </summary>
        public virtual WardAdmission InternalTransferOriginalWard { get; set; }
    }
}
