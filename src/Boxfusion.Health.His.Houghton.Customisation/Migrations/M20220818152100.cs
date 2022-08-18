using FluentMigrator;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Houghton.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20220818152100)]
    public class M20220818152100 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {
            Execute.Sql(@"Create or Alter vw_His_FlattenedCaseManagementTracker
                            As
                          Select adm.His_HospitalAdmissionNumber AdmissionNumber,
		                        patient.His_HospitalPatientNumber FileNumber,
		                        patient.FirstName,
		                        patient.LastName,
		                        adm.StartDateTime AdmissionDate,
		                        adm.EndDateTime DischargeDate,
		                        classf.ClassificationTypeLkp Classification
                            from Fhir_Encounters adm
                            join Core_Persons patient on patient.Id = adm.SubjectId
                            join Fhir_Encounters hospAdm on hospAdm.Id = adm.PartOfId and hospAdm.Frwk_Discriminator = 'His.HospitalAdmission'
                            left join His_BillingClassifications classf on classf.Id = hospAdm.His_BillingClassificationId
                            where adm.Frwk_Discriminator = 'His.WardAdmission'
                            GO");
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Down()
        {
            throw new NotImplementedException();
        }

    }
}
