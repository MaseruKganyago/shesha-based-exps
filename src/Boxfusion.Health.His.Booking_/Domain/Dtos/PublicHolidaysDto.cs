using Abp.AutoMapper;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Bookings.Domain.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    //TODO:IH-Should use the PublicHoliday entity and Dto from Shesha enterprise
    [AutoMap(typeof(PublicHoliday))]
    public class PublicHolidaysDto
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Date { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
    }
}
