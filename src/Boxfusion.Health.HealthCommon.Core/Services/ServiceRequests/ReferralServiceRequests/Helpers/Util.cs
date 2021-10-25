using Abp.Dependency;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.Referrals;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.Covid19;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.eScripts;
using Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.ConsultationSummaries;
using NHibernate.Transform;
using Shesha.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.ServiceRequests.ReferralServiceRequests.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrganisationId"></param>
        /// <param name="FacilityId"></param>
        /// <param name="PractitionerId"></param>
        /// <returns></returns>
        public static ReferralFacilityContent GetReferralLetterInfo(Guid OrganisationId, Guid FacilityId, Guid PractitionerId)
        {
            var sessionProvider = IocManager.Instance.Resolve<ISessionProvider>();
            return (sessionProvider.Session.CreateSQLQuery(
                @"SELECT * FROM [dbo].[GetReferralLetterInfo](:OrganisationId,:FacilityId,:PractitionerId)")
                .SetParameter("OrganisationId", OrganisationId)
                .SetParameter("FacilityId", FacilityId)
                .SetParameter("PractitionerId", PractitionerId)
                .SetResultTransformer(Transformers.AliasToBean<ReferralFacilityContent>())
                .List<ReferralFacilityContent>())
                .FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrganisationId"></param>
        /// <param name="FacilityId"></param>
        /// <param name="PractitionerId"></param>
        /// <returns></returns>
        public static EScriptContent GetEScriptContentInfo(Guid OrganisationId, Guid FacilityId, Guid PractitionerId)
        {
            var sessionProvider = IocManager.Instance.Resolve<ISessionProvider>();
            return (sessionProvider.Session.CreateSQLQuery(
                @"SELECT * FROM [dbo].[GetReferralLetterInfo](:OrganisationId,:FacilityId,:PractitionerId)")
                .SetParameter("OrganisationId", OrganisationId)
                .SetParameter("FacilityId", FacilityId)
                .SetParameter("PractitionerId", PractitionerId)
                .SetResultTransformer(Transformers.AliasToBean<EScriptContent>())
                .List<EScriptContent>())
                .FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrganisationId"></param>
        /// <param name="FacilityId"></param>
        /// <param name="PractitionerId"></param>
        /// <returns></returns>
        public static Covid19TestReferralContent GetCovid19TestReferralContentInfo(Guid OrganisationId, Guid FacilityId, Guid PractitionerId)
        {
            var sessionProvider = IocManager.Instance.Resolve<ISessionProvider>();
            return (sessionProvider.Session.CreateSQLQuery(
                @"SELECT * FROM [dbo].[GetReferralLetterInfo](:OrganisationId,:FacilityId,:PractitionerId)")
                .SetParameter("OrganisationId", OrganisationId)
                .SetParameter("FacilityId", FacilityId)
                .SetParameter("PractitionerId", PractitionerId)
                .SetResultTransformer(Transformers.AliasToBean<Covid19TestReferralContent>())
                .List<Covid19TestReferralContent>())
                .FirstOrDefault();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrganisationId"></param>
        /// <param name="FacilityId"></param>
        /// <param name="PractitionerId"></param>
        /// <returns></returns>
        public static ConsultationReportContent GetConsultationReportContentInfo(Guid OrganisationId, Guid FacilityId, Guid PractitionerId)
        {
            var sessionProvider = IocManager.Instance.Resolve<ISessionProvider>();
            return (sessionProvider.Session.CreateSQLQuery(
                @"SELECT * FROM [dbo].[GetReferralLetterInfo](:OrganisationId,:FacilityId,:PractitionerId)")
                .SetParameter("OrganisationId", OrganisationId)
                .SetParameter("FacilityId", FacilityId)
                .SetParameter("PractitionerId", PractitionerId)
                .SetResultTransformer(Transformers.AliasToBean<ConsultationReportContent>())
                .List<ConsultationReportContent>())
                .FirstOrDefault();
        }
    }
}
