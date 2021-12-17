using FluentMigrator;
using Shesha;
using Shesha.FluentMigrator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Migrations
{
    /// <summary>
    /// 
    /// </summary>
    [Migration(20211217064800)]
    public class M20211217064800 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {

            Execute.Sql(@"
                ALTER view [dbo].[vw_Report_PatientsWardsView]  AS  
                    select distinct * from
                    (select Ward,Count(*) [NumberOfPatientsAdmitted]
                    ,[Admission_TypeLkp]
                    ,dbo.Frwk_GetRefListItem('His','AdmissionTypes',Admission_TypeLkp) [Admission_Type]
                    ,SpecialityLkp 
                    ,dbo.Frwk_GetRefListItem('Fhir','WardSpecialities',SpecialityLkp) [Speciality]
                    ,[Usable_Beds]
                    ,[SeparationTypeLkp]
                    ,iif ([InPatientDays] > 0 ,Count(*),'') [MidnightInPatientDays]
                    ,iif ([InPatientDays] = 0 ,Count(*),'') [PatientDays]
                    ,iif([SeparationTypeLkp] = 1 or [SeparationTypeLkp] = 2 or [SeparationTypeLkp] = 3,count(*),'') [InPatientDischarge]
                    ,iif([SeparationTypeLkp] = 6 ,count(*),'') [Death]
                    ,iif([SeparationTypeLkp] = 4 ,count(*),'') [InternalTransferOut]
                    ,iif([SeparationTypeLkp] = 5 ,Count(*),'') [ExternalTransferOut]
		
                    ,InPatientDays
                    ,dbo.Frwk_GetRefListItem('His','SeparationTypes',SeparationTypeLkp) [SeparationTypes],WardId,[Hospital]
                    from [dbo].[vw_Report_AllAdmittedPatientsView]  a
                    group by Ward ,[Admission_TypeLkp],SpecialityLkp ,[Usable_Beds],[SeparationTypeLkp],InPatientDays,WardId,[Hospital] ) as a

             ");
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
