using Aspose.Words;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.eScripts;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Reports
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocumentProcessor<T> where T: class
    {
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="streams"></param>
        ///// <param name="app"></param>
        ///// <param name="template"></param>
        ///// <param name="eScriptRegionDatas"></param>
        //void GeneratePDF(List<Stream> streams, T app, RefListDocumentTypeValueSets template);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="template"></param>
        /// <returns></returns>
        Stream GeneratePDF(T app, RefListDocumentTypeValueSets template);
    }
}
