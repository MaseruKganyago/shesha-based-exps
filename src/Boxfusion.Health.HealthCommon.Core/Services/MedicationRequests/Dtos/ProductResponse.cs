using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.MedicationRequests.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public string DateFormat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NappiCodeFirstSixDigits { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string NappiCodeSuffixLastThreeDigits { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StrengthMetric1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UnitOfMeasure1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VolumeMetric2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UnitOfMeasure2 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string VolumeMetric3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string UnitOfMeasure3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public PresentationResponse Presentation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PresentationCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int StandardPacksize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DispensingVolumePacksize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool VolumePackFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DrugSchedule { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AtcLevel5Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object AtcLevel5 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ManufacturerResponse Manufacturer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ManufacturerCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool NonSubstitutableProductFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MedpraxGenericIdCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GenericIndicatorCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool ProductStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double SingleExitPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime SingleExitPriceStartDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object SingleExitPriceEndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool EdlFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool OncologyFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CatalogueNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Product0201 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object ProductIndicator { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ProductSize { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string RxUnit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ScriptingDosage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string GenderFlag { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MaximumAdultDosage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object DrugExclusionDescriptionCodeList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object AdministrationRouteCodeList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object ActiveSubstanceDescriptionCodeList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object ActiveSubstanceList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object DrugClassCodeList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object DrugClassList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object MimsCodeList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string FullDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object ReferencePriceFileList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object FormularyList { get; set; }
    }
}
