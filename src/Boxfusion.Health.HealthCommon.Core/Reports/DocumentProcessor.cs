using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.UI;
using Aspose.Words;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.eScripts;
using Shesha.DocumentProcessing;
using Shesha.Domain;
using Shesha.Utilities;

namespace Boxfusion.Health.HealthCommon.Core.Reports
{
    /// <summary>
    /// 
    /// </summary>
    public class DocumentProcessor<T> : ITransientDependency, IDocumentProcessor<T>  where T : class
    {
        private readonly IDocumentProcessorHelper _documentProcessorHelper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="documentProcessorHelper"></param>
        public DocumentProcessor(
            IDocumentProcessorHelper documentProcessorHelper)
        {
            _documentProcessorHelper = documentProcessorHelper;
        }

        ///// <summary>
        ///// 
        ///// </summary>        
        //public void GeneratePDF(List<Stream> streams, T app, RefListDocumentTypeValueSets template)
        //{
        //    try
        //    {
        //        _documentProcessorHelper.Generate(
        //            streams,
        //            app,
        //            template
        //        );
        //    }
        //    catch (Exception e)
        //    {
        //        throw new UserFriendlyException(e.Message);
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>        
        public Stream GeneratePDF(T app, RefListDocumentTypeValueSets template)
        {
            try
            {
                return _documentProcessorHelper.Generate(
                    app,
                    template
                );
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
        }
    }
}