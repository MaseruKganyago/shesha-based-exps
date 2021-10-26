using Abp.Domain.Entities;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Dashboard
{
    /// <summary>
    /// 
    /// </summary>
    [ImMutable]
    [Table("vw_UserItems")]
    public class UserItems : Entity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
		public virtual string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
		public virtual string Supervisor { get; set; }
	}
}
