using Abp.Dependency;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.eScripts;
using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Reports
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocumentProcessorHelper : ITransientDependency
    {
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="streams"></param>
        ///// <param name="app"></param>
        ///// <param name="template"></param>
        ///// <param name="eScriptRegionDatas"></param>
        //void Generate<T>(List<Stream> streams, T app, RefListDocumentTypeValueSets template, List<MedicationRequestContent> eScriptRegionDatas = null) where T : class;

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="streams"></param>
        ///// <param name="patient"></param>
        ///// <param name="template"></param>
        ///// <param name="files"></param>
        ///// <returns></returns>
        //Task<List<StoredFile>> SaveFileAsync(List<Stream> streams, Patient patient, RefListDocumentTypeValueSets template, List<StoredFile> files);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="patient"></param>
        /// <param name="template"></param>
        /// <returns></returns>
        Task<StoredFile> SaveFileAsync(Stream stream, Patient patient, RefListDocumentTypeValueSets template);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="app"></param>
        /// <param name="template"></param>
        /// <returns></returns>
        Stream Generate<T>(T app, RefListDocumentTypeValueSets template) where T : class;

    }
}
