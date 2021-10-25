using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.HomeAffairs.Dto
{
    public class HomeAffairsResponseDto
    {
        public HomeAffairsPersonDto NprPerson { get; set; }

        public string IsCallSuccessful { get; set; }

        public string ErrorMessage { get; set; }
    }
}
