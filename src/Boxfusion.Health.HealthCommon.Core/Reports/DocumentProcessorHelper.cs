using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Uow;
using Abp.UI;
using Aspose.Words;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.eScripts;
using Shesha.DocumentProcessing;
using Shesha.Domain;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IoCManager = Abp.Dependency.IocManager;
using shesha = Boxfusion.Health.HealthCommon.Core.Domain.Cdm;

namespace Boxfusion.Health.HealthCommon.Core.Reports
{

    /// <summary>
    /// 
    /// </summary>
    public class DocumentProcessorHelper : AsposeBuilderBase, IDocumentProcessorHelper, ITransientDependency
    {
        private readonly IUnitOfWorkManager _unitOfWork; 
        private readonly IStoredFileService _storedFileService;

        /// <summary>
        /// 
        /// </summary>
        public DocumentProcessorHelper(
            IStoredFileService storedFileService)
        {
            _storedFileService = storedFileService;//IoCManager.Instance.Resolve<IStoredFileService>();
            _unitOfWork = IoCManager.Instance.Resolve<IUnitOfWorkManager>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        protected Dictionary<string, object> Fields<T>(T app) where T: class
        {
            var dict = app.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                        .ToDictionary(prop => prop.Name, prop => prop.GetValue(app, null));

            return dict;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="templatePath"></param>
        /// <returns></returns>
        protected Document CreateDocument(string templatePath)
        {
            var assembly = Assembly.GetExecutingAssembly();

            Document doc = null;
            var resourcePath = assembly.GetManifestResourceNames().FirstOrDefault(str => str.EndsWith(templatePath));
            using (Stream stream = assembly.GetManifestResourceStream(resourcePath))
            {
                doc = new Document(stream);
            }

            return doc;
        }

        ///// <summary>
        ///// /
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="streams"></param>
        ///// <param name="app"></param>
        ///// <param name="template"></param>
        ///// <param name="medicationRequestContent"></param>
        //public void Generate<T>(List<Stream> streams, T app, RefListDocumentTypeValueSets template, List<MedicationRequestContent> medicationRequestContent = null) where T: class
        //{
        //    try
        //    {
        //        string filepath = GetFilePath(template);

        //        var memoryStream = new MemoryStream();
        //        var doc = CreateDocument(filepath);

        //        var builder = new DocumentBuilder(doc);

        //        var fields = Fields(app);

        //        var patientSymptoms = GetDataTableProperty(app, "PatientSymptoms");
        //        var patientProvisionDiagnoses = GetDataTableProperty(app, "PatientProvisionDiagnoses");
        //        var medicationRequests = GetDataTableProperty(app, "MedicationRequests");

        //        // fill the fields with user data
        //        builder.Document.MailMerge.Execute(
        //            fields.Select(x => x.Key).ToArray(),
        //            fields.Select(x => x.Value).ToArray()
        //        );

        //        if(patientSymptoms != null)
        //            builder.Document.MailMerge.ExecuteWithRegions(patientSymptoms);

        //        if (patientProvisionDiagnoses != null)
        //            builder.Document.MailMerge.ExecuteWithRegions(patientProvisionDiagnoses);

        //        if (medicationRequests != null)
        //            builder.Document.MailMerge.ExecuteWithRegions(medicationRequests);
        //        //}

        //        // save the result
        //        doc.Save(memoryStream, SaveFormat.Pdf);
        //        memoryStream.Seek(0, 0);

        //        streams.Add(memoryStream);
        //    }
        //    catch (Exception e)
        //    {
        //        throw new UserFriendlyException(e.Message);
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="streams"></param>
        ///// <param name="patient"></param>
        ///// <param name="template"></param>
        ///// <param name="files"></param>
        ///// <returns></returns>
        //public async Task<List<StoredFile>> SaveFileAsync(List<Stream> streams, Patient patient, RefListDocumentTypeValueSets template, List<StoredFile> files)
        //{
        //    using (var ouw = _unitOfWork.Begin(TransactionScopeOption.RequiresNew))
        //    {
        //        string filepath = GetFilePath(template);
        //        var filepathLength = filepath.Length - 5;

        //        var newfilepath = filepath.Substring(0, filepathLength );

        //        for (int i = 0; i < streams.Count; i++)
        //        {
        //            var file = await _storedFileService.SaveFile(
        //                  stream: streams[i],
        //                  fileName: $"{newfilepath}.pdf",
        //                  prepareFileAction: file =>
        //                  {
        //                      file.SetOwner(patient);
        //                  }
        //               );

        //            files.Add(file);
        //        }

        //        await ouw.CompleteAsync();
        //    }

        //    return files;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="app"></param>
        /// <param name="template"></param>
        /// <returns></returns>
        public Stream Generate<T>(T app, RefListDocumentTypeValueSets template) where T : class
        {
            try
            {
                string filepath = GetFilePath(template);

                var memoryStream = new MemoryStream();
                var doc = CreateDocument(filepath);


                var builder = new DocumentBuilder(doc);

                var fields = Fields(app);

                // fill the fields with user data
                builder.Document.MailMerge.Execute(
                    fields.Select(x => x.Key).ToArray(),
                    fields.Select(x => x.Value).ToArray()
                );

                //print datatable (i.e. list) properties
                fields.ToList().ForEach(field =>
                {
                    var dataTable = field.Value as DataTable;
                    if(dataTable != null)
                        builder.Document.MailMerge.ExecuteWithRegions(dataTable);
                });

                // save the result
                doc.Save(memoryStream, SaveFormat.Pdf);
                memoryStream.Seek(0, 0);

                return memoryStream;
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="patient"></param>
        /// <param name="template"></param>
        /// <returns></returns>
        public async Task<StoredFile> SaveFileAsync(Stream stream, Patient patient, RefListDocumentTypeValueSets template)
        {
            StoredFile storedFile = null;
            using (var ouw = _unitOfWork.Begin(TransactionScopeOption.RequiresNew))
            {
                string filepath = GetFilePath(template);
                var filepathLength = filepath.Length - 5;

                var newfilepath = filepath.Substring(0, filepathLength);

                storedFile = await _storedFileService.SaveFile(
                        stream: stream,
                        fileName: $"{newfilepath}.pdf",
                          prepareFileAction: (file) =>
                          {
                              file.SetOwner(patient);
                          }
                    );

                await ouw.CompleteAsync();
            }

            return storedFile;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        private static string GetFilePath(RefListDocumentTypeValueSets template)
        {
            string fileName = string.Empty;

            switch (template)
            {
                case RefListDocumentTypeValueSets.Covid19:
                    fileName = UtilityHelper.GetRefListItemText("Fhir", "DocumentTypeValueSets", (int)RefListDocumentTypeValueSets.Covid19);
                    break;
                case RefListDocumentTypeValueSets.eScript:
                    fileName = UtilityHelper.GetRefListItemText("Fhir", "DocumentTypeValueSets", (int)RefListDocumentTypeValueSets.eScript);
                    break;
                case RefListDocumentTypeValueSets.ReferralToFacility:
                    fileName = UtilityHelper.GetRefListItemText("Fhir", "DocumentTypeValueSets", (int)RefListDocumentTypeValueSets.ReferralToFacility);
                    break;
                case RefListDocumentTypeValueSets.SickNote:
                    fileName = UtilityHelper.GetRefListItemText("Fhir", "DocumentTypeValueSets", (int)RefListDocumentTypeValueSets.SickNote);
                    break;
                case RefListDocumentTypeValueSets.ConsultationReport:
                    fileName = UtilityHelper.GetRefListItemText("Fhir", "DocumentTypeValueSets", (int)RefListDocumentTypeValueSets.ConsultationReport);
                    break;
            }

            return $"Boxfusion.Health.HealthCommon.Core.Reports.Templates.Telemedicine {fileName}.docx";
        }
    }
}
