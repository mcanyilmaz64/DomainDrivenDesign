namespace DomainDrivenDesign.Domain.Users
{
    public sealed record Password
    {
        public string Value { get; init; }
        public Password(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Password cannot be null or empty.");
            }
            Value = value;
        }
    }
}
