using System;

namespace Boxfusion.Health.His.Common.Authorization
{
    /// <summary>
    /// Health.His Permission names
    /// </summary>
    /// 
    public class CommonPermissions
    {
        public const string GroupName = "Common";

        public static class UserManagement
        {
            public const string Default = GroupName + ".UserManagement";
            public const string Create = Default + ".Create";
            public const string Edit = Default + ".Edit";
            public const string Delete = Default + ".Delete";
        }
    }

    [Obsolete("Replace with CommonPermissions wherever you find this")]
    public static class CommonPermissionsObsolete
    {

        public const string ScheduleManagement = "pages:ScheduleManagement";
        public const string BookingAdministration = "pages:BookingAdministration";
        public const string UserAdministration = "pages:UserAdministration";
        public const string SystemAdministration = "pages:SystemAdministration";

        ///// <summary>
        ///// 
        ///// </summary>
        //public const string Administration = "pages:Administration";


        ///// <summary>
        ///// 
        ///// </summary>
        //public const string Reports = "pages:Reports";

        ///// <summary>
        ///// Pages: Admission Dashboard
        ///// </summary>
        //public const string DailyAppointmentBooking = "pages:dailyAppointmentBooking";

        ///// <summary>
        ///// Pages: Admission Dashboard
        ///// </summary>
        //public const string BookAppointment = "pages:bookAppointment";

        ///// <summary>
        ///// Pages: Admission Dashboard
        ///// </summary>
        //public const string RescheduleAppointment = "pages:rescheduleAppointment";


        ///// <summary>
        ///// Pages: Admission Dashboard
        ///// </summary>
        //public const string AdmissionDashboard = "pages:admissionDashboard";

        ///// <summary>
        ///// 
        ///// </summary>
        //public const string DailyAdmissionDashboard = "pages:dailyAdmissionDashboard";

        ///// <summary>
        ///// 
        ///// </summary>
        //public const string AllAdmissionDashboard = "pages:allAdmissionDashboard";

        ///// <summary>
        ///// 
        ///// </summary>
        //public const string ApproveReport = "pages:approveReport";

        ///// <summary>
        ///// 
        ///// </summary>
        //public const string DisapproveReport = "pages:disapproveReport";

        ///// <summary>
        ///// 
        ///// </summary>
        //public const string DailyReports = "pages:dailyReports";

        ///// <summary>
        ///// 
        ///// </summary>
        //public const string MonthlyReports = "pages:monthlyReports"; 

        ///// <summary>
        ///// 
        ///// </summary>
        //public const string CreateFacility = "pages:createfacility";
        
        ///// <summary>
        ///// 
        ///// </summary>
        //public const string Facilities = "pages:facilities";

        ///// <summary>
        ///// 
        ///// </summary>
        //public const string CaptureAdmissions = "pages:captureAdmissions";

        ///// <summary>
        ///// 
        ///// </summary>
        //public const string SeparateAndTransfer = "pages:separateandtransfer";

        ///// <summary>
        ///// 
        ///// </summary>
        //public const string SubmitsReportsForApproval = "pages:submitsReportsForApproval";

        ///// <summary>
        ///// 
        ///// </summary>
        //public const string Wards = "pages:wards";

        ///// <summary>
        ///// 
        ///// </summary>
        //public const string Speciality = "pages:speciality";

        ///// <summary>
        ///// 
        ///// </summary>
        //public const string ReportsAndStats = "pages:reportsAndStats";


    }
}
