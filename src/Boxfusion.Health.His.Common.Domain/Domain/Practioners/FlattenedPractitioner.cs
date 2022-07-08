using Abp.Domain.Entities;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Domain.Domain.Practioners
{
    /// <summary>
    /// Flattened version of the Practitioner linked to all the facilities
    /// </summary>
    [Entity(TypeShortAlias = "His.FlattenedPractitioner")]
    [Table("vw_His_FlattenedPractitioner")]
    [ImMutable]
    public class FlattenedPractitioner: Entity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string MobileNumber1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string EmailAddress1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string FacilityNames { get; set; }
    }
}
