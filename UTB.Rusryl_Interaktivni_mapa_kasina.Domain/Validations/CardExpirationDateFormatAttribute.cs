using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class CardExpirationDateFormatAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return ValidationResult.Success;
            }
            else if(value is string expirationDate)
            {
                if (expirationDate == String.Empty)
                {
                    return ValidationResult.Success;
                }

                var expirationDateRegex = new Regex(@"\b(?:0[1-9]|1[0-2])/(?:2[6-9]|3[0-9]|4[0-9]|50)\b");

                if(expirationDateRegex.IsMatch(expirationDate)){
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"The {validationContext.MemberName} field contains incorrect expiration date format. Please use MM/YY.");
                }
            }
            else
            {
                throw new NotImplementedException($"The {nameof(CardNumberLengthAttribute)} is not implemented for the type: {value.GetType()}");
            }
        }
    }
}