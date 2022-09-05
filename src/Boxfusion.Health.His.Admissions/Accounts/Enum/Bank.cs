using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Accounts.Enum
{
    public enum Bank : long
    {
        [Description("First National Bank")]
        FNB = 1,

        [Description("ABSA")]
        ABSA = 2,

        [Description("Standard Bank")]
        StandardBank = 3
    }
}
