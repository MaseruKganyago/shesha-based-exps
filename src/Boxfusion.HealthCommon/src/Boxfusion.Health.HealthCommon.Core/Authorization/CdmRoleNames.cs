namespace Boxfusion.Health.HealthCommon.Core
{
    /// <summary>
    /// Role Names
    /// </summary>
    public static class CdmRoleNames
    {
        /// <summary>
        /// Data Administrator
        /// </summary>
        public const string Patient = "Patient";

        /// <summary>
        /// System Administrator
        /// </summary>
        public const string Practitioner = "Practitioner";

        /// <summary>
        /// 
        /// </summary>
        public const string SystemAdministrator = "System Administrator";

        /// <summary>
        /// Ward Clerk
        /// </summary>
        public const string WardClerk = "Ward Clerk";

        /// <summary>
        /// System Administrator
        /// </summary>
        public const string Nurse = "Nurse";

        /// <summary>
        /// Unit Manager
        /// </summary>
        public const string UnitManager = "Unit Manager";

        /// <summary>
        /// Matrons
        /// </summary>
        public const string Matrons = "Matron";

        /// <summary>
        /// Nursing Manager/Clinical Services Manager
        /// </summary>
        public const string NursingManagerClinicalServicesManager = "Nursing Manager/Clinical Services Manager";

        /// <summary>
        /// HIS Team Members
        /// </summary>
        public const string HISTeamMembers = "HIS Team Members";

        /// <summary>
        /// HIS Manager
        /// </summary>
        public const string HISManager = "HIS Manager";

        /// <summary>
        /// CEO
        /// </summary>
        public const string CEO = "CEO";

        /// <summary>
        /// Case Management
        /// </summary>
        public const string CaseManagement = "Case Management";

        /// <summary>
        /// 
        /// </summary>
        public static readonly string[] PractitionerAppAccessRoles = { Practitioner, SystemAdministrator };

        /// <summary>
        /// 
        /// </summary>
        public static readonly string[] PatientAppAccessRoles = { Patient, SystemAdministrator };

        /// <summary>
        /// 
        /// </summary>
        public static readonly string[] AllAccessRoles = { Patient, Practitioner, SystemAdministrator };

    }
}
