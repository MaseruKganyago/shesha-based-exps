using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Authorization
{
    /// <summary>
    /// 
    /// </summary>
    public class CdmRoleIds
    {
        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid WardClerkId = Guid.Parse("9cae82ae-cb34-4e7c-8c5d-20022b2b6878");

        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid NurseId = Guid.Parse("404310a1-2448-43d7-9493-77aae6d6e1b1");

        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid UnitManagerId = Guid.Parse("b4a2575b-cd83-4fcf-a99a-249aab3a1c00");

        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid MatronId = Guid.Parse("5b891d35-1113-4410-8b5b-59aeca66f3cc");

        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid NursingManagerClinicalServicesManagerId = Guid.Parse("ec10f57d-922e-48fa-af45-d4406b3f1d01");

        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid HISTeamMembersId = Guid.Parse("A201EB24-17CE-4976-BA5A-83A0B9DCDA7D");

        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid HISManagerId = Guid.Parse("FBC2D95E-575F-4342-9465-D9A327BB905E");

        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid CEOId = Guid.Parse("EA0845CC-7F8A-4B57-94D5-B6125088E5CA");

        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid CaseManagementId = Guid.Parse("15B6ADB9-7D8E-46A4-B1BF-F658A6EC799F");

        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid SystemAdministratorId = Guid.Parse("8d2e4b7a-59ba-4be2-8c56-4463dc16459e");

        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid[] ClinicalIds = { WardClerkId, NurseId, UnitManagerId, MatronId, NursingManagerClinicalServicesManagerId };

        /// <summary>
        /// 
        /// </summary>
        public static readonly Guid[] nonClinicalIds = { HISTeamMembersId, HISManagerId, CEOId, CaseManagementId, SystemAdministratorId };
    }
}
