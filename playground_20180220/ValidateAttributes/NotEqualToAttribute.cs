using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace playground_20180220.ValidateAttributes
{
    public class NotEqualToAttribute : ValidationAttribute, IClientValidatable
    {
        public string OtherProperty { get; private set; }

        public NotEqualToAttribute(string otherProperty)
        {
            OtherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //利用反射去取得指定的欄位是否存在
            var property = validationContext.ObjectType.GetProperty(OtherProperty);
            if (property == null)
            {
                return new ValidationResult(
                    string.Format(
                        CultureInfo.CurrentCulture,
                        "{0} 不存在",
                        OtherProperty
                    )
                );
            }

            //指定的欄位值
            var otherValue = property.GetValue(validationContext.ObjectInstance, null);
            if (object.Equals(value, otherValue))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return null;
        }

        /// <summary>
        /// 在類別中實作時，傳回該類別的用戶端驗證規則。
        /// </summary>
        /// <param name="metadata">模型中繼資料。</param>
        /// <param name="context">控制器內容。</param>
        /// <returns>
        /// 此驗證程式的用戶端驗證規則。
        /// </returns>
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ValidationType = "notequalto",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };
            rule.ValidationParameters["other"] = OtherProperty;
            yield return rule;
        }

        public override string FormatErrorMessage(string name)
        {
            return this.ErrorMessage ?? string.Format("{0} what happend?", name);
        }
    }
}