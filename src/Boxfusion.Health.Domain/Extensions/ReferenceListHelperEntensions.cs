using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Shesha.Domain;
using Shesha.Services;
using Shesha.Services.ReferenceLists.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.Domain.Extensions
{
    public static class ReferenceListHelperEntensions
    {
        /// <summary>
        /// Given an enum item name, return underlying integer
        /// </summary>
        /// <param name="refListNamespace"></param>
        /// <param name="refListName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int GetItemDisplayValue(this ReferenceListHelper, string refListNamespace, string refListName, string text)
        {
            if (string.IsNullOrWhiteSpace(refListNamespace))
                throw new Exception($"{nameof(refListNamespace)} must not be null");
            if (string.IsNullOrWhiteSpace(refListName))
                throw new Exception($"{nameof(refListName)} must not be null");

            if (string.IsNullOrWhiteSpace(text))
                throw new Exception($"{nameof(text)} must not be null");

            var _unitOfWorkManager = IocManager.Instance.Resolve<IUnitOfWorkManager>();
            var _referenceListHelper = IocManager.Instance.Resolve<IReferenceListHelper>();

            // make sure that we have active session
            using (_unitOfWorkManager.Current == null ? _unitOfWorkManager.Begin() : null)
            {
                var items = _referenceListHelper.GetItems(refListNamespace, refListName);
                return items.FirstOrDefault(i => i.Item == text)?.ItemValue;
            }
        }
    }
}

