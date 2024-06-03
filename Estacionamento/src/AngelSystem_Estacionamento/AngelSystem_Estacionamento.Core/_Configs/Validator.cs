using FluentValidation;
using FluentValidation.Results;

namespace AngelSystem_Estacionamento.Core.Configs;

public abstract class Validator
{
    public ValidationResult ValidationResult { get; set; }
    protected Validator() => ValidationResult = new ValidationResult();

    public void AddErrorValidationResult(int errorStatus, string description)
    {
        var failure = new ValidationFailure(errorStatus.ToString(), description);
        failure.Severity = Severity.Error;
        failure.ErrorCode = errorStatus.ToString();
        ValidationResult.Errors.Add(failure);
    }

    public void AddValidationResult(ValidationResult validationResult) => ValidationResult = validationResult;

    public abstract bool IsValid();

}