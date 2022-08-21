using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.His.Common.Products;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Beds
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "His.BedTypes")]
    public class BedType : HisProduct
	{
    }
}
