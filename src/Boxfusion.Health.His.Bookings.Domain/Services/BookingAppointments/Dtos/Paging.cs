using System;

namespace Boxfusion.Health.His.Bookings.Services.BookingAppointments.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class Paging
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="totalPagesCount"></param>
        public Paging(int? pageNumber, int? pageSize, int? totalCount)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
            TotalPagesCount = (int)Math.Ceiling((double)(totalCount / PageSize ?? 1));
        }

        /// <summary>
        /// 
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TotalCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? TotalPagesCount { get; set; }
    }
}