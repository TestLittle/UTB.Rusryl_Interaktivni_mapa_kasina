using System.ComponentModel.DataAnnotations;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class CardNumberLengthAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return ValidationResult.Success;
            }
            else if(value is string cardNumber)
            {
                if (cardNumber == String.Empty)
                {
                    return ValidationResult.Success;
                }

                if(cardNumber.Length >= 12 && cardNumber.Length <= 19){
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult($"The {validationContext.MemberName} field must contain a valid card number length.");
                }
            }
            else
            {
                throw new NotImplementedException($"The {nameof(CardNumberLengthAttribute)} is not implemented for the type: {value.GetType()}");
            }
        }
    }
}