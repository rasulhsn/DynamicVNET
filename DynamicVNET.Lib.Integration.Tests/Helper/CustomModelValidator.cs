namespace DynamicVNET.Lib.Integration.Tests.Helper
{
    public class ModelValidator : BaseValidator<UserStub>
    {
        protected override void Configure(ITypeRuleMarker<UserStub> builder)
        {
            builder
                .For(x => x.Age)
                .Range(18, 22);

            builder
                .For(x => x.Surname)
                .Required()
                .MaxLen(4);

            builder
                .For(x => x.Token.TokenNumber)
                .EmailAddress();

            builder
                .Branch(x => x.Age > 18, y =>
                {
                    y.StringLen(m => m.Name, 18);
                });
        }
    }
}
