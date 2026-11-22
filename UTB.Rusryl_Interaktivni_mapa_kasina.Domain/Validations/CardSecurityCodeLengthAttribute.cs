using System.ComponentModel.DataAnnotations;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class CardSecurityCodeLengthAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return ValidationResult.Success;
            }
            else if(value is string securityCode)
            {
                if (securityCode == String.Empty)
                {
                    return ValidationResult.Success;
                }

                if(securityCode.Length == 3 || securityCode.Length == 4){
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"The {validationContext.MemberName} field must contain a valid security code length.");
                }
            }
            else
            {
                throw new NotImplementedException($"The {nameof(CardNumberLengthAttribute)} is not implemented for the type: {value.GetType()}");
            }
        }
    }
}