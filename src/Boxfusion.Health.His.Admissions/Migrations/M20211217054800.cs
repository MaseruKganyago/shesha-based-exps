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
    [Migration(20211217054800)]
    public class M20211217054800 : Migration
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Up()
        {

            Execute.Sql(@"
                  Update Core_ShaRoleAppointments
                  Set Frwk_Discriminator = 'His.WardRoleAppointedPerson'
                  WHERE Frwk_Discriminator = 'Fhir.WardRoleAppointedPerson'

                  Update Core_ShaRoleAppointments
                  Set Frwk_Discriminator = 'His.HospitalRoleAppointedPerson'
                  WHERE Frwk_Discriminator = 'Fhir.HospitalRoleAppointedPerson'

                  Update Core_Persons
                  Set Frwk_Discriminator = 'His.HisUser'
                  WHERE Frwk_Discriminator = 'Fhir.PersonFhirBase'

                  Update Core_Organisations
                  Set Frwk_Discriminator = 'His.HisHospital'
                  WHERE Frwk_Discriminator = 'Fhir.Hospital'

                  Update Core_Facilities
                  Set Frwk_Discriminator = 'His.HisWard'
                  WHERE Frwk_Discriminator = 'Fhir.Ward'
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
