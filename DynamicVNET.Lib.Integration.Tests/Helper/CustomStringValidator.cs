namespace DynamicVNET.Lib.Integration.Tests
{
    public class StringValidator : BaseValidator<string>
    {
        protected override void Configure(ITypeRuleMarker<string> builder)
        {
            builder
                .For(x => x)
                .Required()
                .StringLen(5);
        }
    }
}
