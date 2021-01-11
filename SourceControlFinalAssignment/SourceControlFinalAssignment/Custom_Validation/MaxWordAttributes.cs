using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SourceControlFinalAssignment.Custom_Validation
{
    public class MaxWordAttributes : ValidationAttribute
    {
        private readonly int _maxWords;
        public MaxWordAttributes(int maxWords) : base("{0} has too many words.")
        {
            _maxWords = maxWords;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
                return ValidationResult.Success;
            var textValue = value.ToString();
            if (textValue.Split(' ').Length <= _maxWords)
                return ValidationResult.Success;
            var errorMsg = FormatErrorMessage((validationContext.DisplayName));

            return new ValidationResult(errorMsg);
        }
    }
}