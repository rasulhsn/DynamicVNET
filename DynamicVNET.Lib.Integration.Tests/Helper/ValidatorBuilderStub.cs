namespace DynamicVNET.Lib.Integration.Tests
{
    public class StringValidatorBuilder : ValidatorBuilder<string>
    {
        public StringValidatorBuilder()
        {
            this.Marker
                .For(x => x)
                .Required()
                .StringLen(5);
        }
    }

    public class UserStubBuilder : TagValidatorBuilder
    {
        public UserStubBuilder()
        {
            this.MarkAs<UserStub>("DefaultUser", val =>
            {
                val.For(x => x.Age)
                 .Range(18, 22);
                val.For(x => x.Surname)
                      .Required()
                      .MaxLen(4);
                val.For(x => x.Token.TokenNumber)
                     .EmailAddress();
                val.Branch(x => x.Age > 18, y =>
                     {
                         y.StringLen(m => m.Name, 18);
                     });
            });

            MarkAs<UserStub>("UserWithStrategy", val =>
             {
                 val.Required(x => x.Name)
                 .Required(x => x.Surname);
             }).SetStrategy((result) => result.HasNestedResults);
        }
    }

    public class ModelValidatorBuilder : ValidatorBuilder<UserStub>
    {
        public ModelValidatorBuilder()
        {
            this.Marker
                .For(x => x.Age)
                .Range(18, 22);

            this.Marker
                .For(x => x.Surname)
                .Required()
                .MaxLen(4);

            this.Marker
                .For(x => x.Token.TokenNumber)
                .EmailAddress();

            this.Marker
                .Branch(x => x.Age > 18, y =>
                {
                    y.StringLen(m => m.Name, 18);
                });
        }
    }
}
