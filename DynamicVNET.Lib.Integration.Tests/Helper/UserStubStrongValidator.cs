namespace DynamicVNET.Lib.Integration.Tests
{
    public class UserStubStrongValidator : BaseValidator<UserStub>
    {
        public UserStubStrongValidator()
        {
            Setup(builder =>
            {
                builder.Marker
                .For(x => x.Age)
                .Range(18, 22);

                builder.Marker
                    .For(x => x.Surname)
                    .Required()
                    .MaxLen(4);

                builder.Marker
                    .For(x => x.Token.TokenNumber)
                    .EmailAddress();

                builder.Marker
                    .Branch(x => x.Age > 18, y =>
                    {
                        y.StringLen(m => m.Name, 18);
                    });
            });
        }
    }
}
