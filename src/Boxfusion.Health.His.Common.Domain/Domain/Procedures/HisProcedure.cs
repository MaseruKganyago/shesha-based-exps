using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Procedures
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.HisProcedure")]
    public class HisProcedure : Procedure
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual ProcedureService ProcedureService { get; set; }
    }
}
