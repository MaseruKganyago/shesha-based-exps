using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.HomeAffairs.Dto
{
    public class HomeAffairsPersonDto
    {
        public string Error { get; set; }

        public string IdNumber { get; set; }

        public string NewIdNumber { get; set; }

        public string Surname { get; set; }

        public string Names { get; set; }

        public string MaidenName { get; set; }

        public string DeathStatus { get; set; }

        public string BirthPlace { get; set; }

        public string DateOfBirth { get; set; }

        public string DateOfDeath { get; set; }

        public string DeathPlace { get; set; }

        public string MarriageStatus { get; set; }

        public string MarriageDate { get; set; }

        public string MarriagePlace { get; set; }

        public string DivorceDate { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string PostalCode { get; set; }

        public string SpouseIdNumber { get; set; }

        public List<string> ChildIdnumber { get; set; }

        public string MotherIdNumber { get; set; }

        public string FatherIdNumber { get; set; }

        public string IdBookDate { get; set; }

        public string PassportStatus { get; set; }

        public string PassportStatusDate { get; set; }

        public string ID_TAT_Barcode { get; set; }

        public string ID_TAT_Status { get; set; }

        public string ID_TAT_Date { get; set; }

        public string IdCardIndicator { get; set; }

        public string IdCardDate { get; set; }
    }
}
