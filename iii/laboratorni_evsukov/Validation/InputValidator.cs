namespace LaboratorniEvsukov.Validation
{
    public static class InputValidator
    {
        public const int MaxSourceLength = 100;

        public static bool IsValidSource(string value) =>
            !string.IsNullOrWhiteSpace(value) && value.Length <= MaxSourceLength;
    }
}