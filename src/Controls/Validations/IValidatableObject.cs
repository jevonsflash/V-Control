namespace VControl.Controls.Validations;

public interface IValidatableObject
{
    bool IsValid { get; }
    bool Validate();

    IEnumerable<string> Errors { get; }
}
