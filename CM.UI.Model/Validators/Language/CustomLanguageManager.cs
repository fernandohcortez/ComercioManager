using FluentValidation.Resources;

namespace CM.UI.Model.Validators.Language
{
    public class CustomLanguageManager : LanguageManager
    {
        public CustomLanguageManager()
        {
            AddTranslation("pt", "NotNullValidator", "'{PropertyName}' é obrigatório.");
            AddTranslation("pt", "MaximumLengthValidator", "O tamanho máximo do campo '{PropertyName}' deve ser {MaxLength} caracteres. Você informou {TotalLength} caracteres.");
            AddTranslation("pt", "MinimumLengthValidator", "O tamanho do campo '{PropertyName}' deve ter pelo menos {MinLength} caracteres.Você informou {TotalLength} caracteres.");
            AddTranslation("pt", "EmailValidator", "'{PropertyValue}' não é um endereço de email válido.");
            AddTranslation("pt", "LengthValidator", "'{PropertyName}' deve conter entre {MinLength} e {MaxLength} caracteres. Você informou {TotalLength} caracteres.");
            AddTranslation("pt", "NotEmptyValidator", "'{PropertyName}' não deve estar em vazio.");
            AddTranslation("pt", "NullValidator", "'{PropertyName}' deve ser vazio.");
            //AddTranslation("pt", "", "");
            //AddTranslation("pt", "", "");
            //AddTranslation("pt", "", "");
            //AddTranslation("pt", "", "");
            //AddTranslation("pt", "", "");
        }
    }

    //internal class PortugueseLanguage : Language
    //{
    //    public override string Name => "pt";

    //    public PortugueseLanguage()
    //    {
    //        Translate<EmailValidator>("'{PropertyName}' is not a valid email address.");
    //        Translate<GreaterThanOrEqualValidator>("'{PropertyName}' must be greater than or equal to '{ComparisonValue}'.");
    //        Translate<GreaterThanValidator>("'{PropertyName}' must be greater than '{ComparisonValue}'.");
    //        Translate<LengthValidator>("'{PropertyName}' must be between {MinLength} and {MaxLength} characters. You entered {TotalLength} characters.");
    //        Translate<MinimumLengthValidator>("The length of '{PropertyName}' must be at least {MinLength} characters. You entered {TotalLength} characters.");
    //        Translate<MaximumLengthValidator>("The length of '{PropertyName}' must be {MaxLength} characters or fewer. You entered {TotalLength} characters.");
    //        Translate<LessThanOrEqualValidator>("'{PropertyName}' must be less than or equal to '{ComparisonValue}'.");
    //        Translate<LessThanValidator>("'{PropertyName}' must be less than '{ComparisonValue}'.");
    //        Translate<NotEmptyValidator>("'{PropertyName}' must not be empty.");
    //        Translate<NotEqualValidator>("'{PropertyName}' must not be equal to '{ComparisonValue}'.");
    //        Translate<NotNullValidator>("'{PropertyName}' must not be empty.");
    //        Translate<PredicateValidator>("The specified condition was not met for '{PropertyName}'.");
    //        Translate<AsyncPredicateValidator>("The specified condition was not met for '{PropertyName}'.");
    //        Translate<RegularExpressionValidator>("'{PropertyName}' is not in the correct format.");
    //        Translate<EqualValidator>("'{PropertyName}' must be equal to '{ComparisonValue}'.");
    //        Translate<ExactLengthValidator>("'{PropertyName}' must be {MaxLength} characters in length. You entered {TotalLength} characters.");
    //        Translate<InclusiveBetweenValidator>("'{PropertyName}' must be between {From} and {To}. You entered {Value}.");
    //        Translate<ExclusiveBetweenValidator>("'{PropertyName}' must be between {From} and {To} (exclusive). You entered {Value}.");
    //        Translate<CreditCardValidator>("'{PropertyName}' is not a valid credit card number.");
    //        Translate<ScalePrecisionValidator>("'{PropertyName}' must not be more than {ExpectedPrecision} digits in total, with allowance for {ExpectedScale} decimals. {Digits} digits and {ActualScale} decimals were found.");
    //        Translate<EmptyValidator>("'{PropertyName}' must be empty.");
    //        Translate<NullValidator>("'{PropertyName}' must be empty.");
    //        Translate<EnumValidator>("'{PropertyName}' has a range of values which does not include '{PropertyValue}'.");
    //    }
    //}
}
