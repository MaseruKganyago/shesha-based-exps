using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Domain.Domain.Enums;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Boxfusion.Health.Domain.Domain.DataTypes
{
    /// <summary>
    /// An identifier intended for computation
    /// </summary>
    [Entity(TypeShortAlias = "HealthDomain.Identifier")]
    public class Identifier<T> : FullAuditedEntity<Guid> where T : struct, IComparable, IConvertible, IFormattable
    {
        /// <summary>
        /// usual | official | temp | secondary | old (If known)
        /// </summary>
        public virtual RefListIdentifierUse? Use { get; set; }
        /// <summary>
        /// A coded type for an identifier that can be used to determine which identifier to use for a specific purpose.
        /// </summary>
        public virtual CodeableConcept<T> Type { get; set; }
        /// <summary>
        /// The namespace for the identifier value
        /// </summary>
        public virtual string System { get; set; }
        /// <summary>
        /// The value that is unique
        /// </summary>
        public virtual string Value { get; set; }
        /// <summary>
        /// Time period when id is/was valid for use
        /// </summary>
        public virtual Period Period { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Organization Assigner { get; set; }

        /// <summary>
        /// The Id of the entity this audit entry relates to.
        /// </summary>
        [Column("Frwk_OwnerId")]
        [StringLength(40)]
        public virtual string OwnerId { get; protected set; }
   
        /// <summary>
        /// The Type of entity this audit entry relates to.
        /// </summary>
        [Column("Frwk_OwnerType")]
        [StringLength(100)]
        public virtual string OwnerType { get; protected set; }
    }
}
