using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace playground_20180220.ValidateAttributes
{
    public class NoIsAttribute : ValidationAttribute, IClientValidatable
    {
        /// <summary>
        /// Input description
        /// </summary>
        public string Input { get; set; }

        public NoIsAttribute(string input)
        {
            this.Input = input;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
                return true;

            if(value is string)
            {
                if (Input.Contains(value.ToString()))
                    return false;
            }

            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            ModelClientValidationRule rule = new ModelClientValidationRule
            {
                ValidationType = "nois",
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName())
            };

            rule.ValidationParameters["input"] = Input;

            yield return rule;
        }
    }
}