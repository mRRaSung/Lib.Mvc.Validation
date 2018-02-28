using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Ryan.Validation
{
    public sealed class DayRangeAttribute : ValidationAttribute, IClientValidatable
    {
        private int minimumDays;
        private int maximumDays;

        public DayRangeAttribute(int min, int max)
        {
            if(min.CompareTo(max) > -1)
            {
                throw new Exception("範圍設定錯誤，最小日期不可小於等於最大日期");
            }

            minimumDays = min;
            maximumDays = max;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            var compareDate = value as DateTime?;

            if(compareDate.HasValue)
            {
                compareDate = compareDate.Value.Date;

                return compareDate.Value >= DateTime.Today.AddDays(minimumDays) &&
                        compareDate.Value <= DateTime.Today.AddDays(maximumDays);
            }

            return false;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "rangeday",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };

            //傳至前端的html attribute, will be data-val-rangeday-min="xxx"
            rule.ValidationParameters["min"] = minimumDays;
            rule.ValidationParameters["max"] = maximumDays;

            yield return rule;
        }
    }
}