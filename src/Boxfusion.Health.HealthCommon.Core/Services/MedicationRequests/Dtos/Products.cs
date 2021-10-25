using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.MedicationRequests.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class Products
    {
        /// <summary>
        /// 
        /// </summary>
        public bool HasPreviousPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool HasNextPage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalPages { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ThisCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<ProductResponse> PageResult { get; set; }
    }
}
