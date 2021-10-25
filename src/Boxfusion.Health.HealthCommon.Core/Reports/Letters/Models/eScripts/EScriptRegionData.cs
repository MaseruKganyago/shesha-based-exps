using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.eScripts
{
    /// <summary>
    /// 
    /// </summary>
    public class EScriptRegionData
    {
        /// <summary>
        /// 
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Quantity { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="medicationRequestContents"></param>
        ///// <returns></returns>
        //public static DataTable GetEScriptRegionData(List<MedicationRequestContent> medicationRequestContents)
        //{
        //    var eScriptRegionDatas = medicationRequestContents.Select(x => new EScriptRegionData
        //    {
        //        Key = $"{x.MedicationName}, {x.Dosage}, {x.Route}, {x.Frequency}, {x.Duration}, {x.Repeat}, {x.Instruction}",
        //        Quantity = x.Quantity
        //    }).ToList();

        //    DataTable table = new DataTable();
        //    using (var reader = ObjectReader.Create(eScriptRegionDatas))
        //    {
        //        table.Load(reader);
        //    }

        //    table.TableName = "MedicationRequestContent";
        //    return table;
        //}
    }
}
