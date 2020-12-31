using Bogus;

namespace DynamicVNET.Lib.Benchmarks.Helper
{
    public static class SampleSetup
    {
        private static IValidator CreateValidator(bool generateValid = true)
        {
            var tokenFaker = new Faker<SampleToken>()
                    .RuleFor(x => x.TokenNumber, m => m.Random.Guid().ToString());

            SampleToken tokenSample = tokenFaker.Generate();
            tokenSample.InnerToken = tokenFaker.Generate();
            tokenSample.InnerToken.InnerToken = tokenFaker.Generate();

            if (!generateValid)
            {
                var errorModelFaker = new Faker<Sample>()
                     .RuleFor(m => m.Age, m => m.Random.Int(0, 5))
                     .RuleFor(m => m.Name, m => m.Lorem.Word());

                ErrorModel = errorModelFaker.Generate();
                ErrorModel.Token = tokenSample;

                var builder = new ValidatorBuilder<Sample>();
                builder
                    .Marker
                    .Range(x => x.Age, 10, 30)
                    .Required(x => x.Name)
                    .Required(x => x.Surname)
                    .PhoneNumber(x => x.Surname)
                    .Predicate(x =>
                    {
                        if (!string.IsNullOrEmpty(x.Surname) && x.Surname.Contains("fakeSample"))
                            return true;
                        return false;
                    })
                    .Null(x => x.Token)
                    .Null(x => x.Token.TokenNumber)
                    .Null(x => x.Token.InnerToken.TokenNumber)
                    .Null(x => x.Token.InnerToken.InnerToken.TokenNumber);

                return builder.Build();
            }
            else
            {
                var modelFaker = new Faker<Sample>()
                     .RuleFor(m => m.Age, m => m.Random.Int(10, 30))
                     .RuleFor(m => m.Name, m => m.Lorem.Word())
                     .RuleFor(m => m.Surname, m => "fakeSample");

                NoErrorModel = modelFaker.Generate();
                NoErrorModel.Token = tokenSample;

                var builder = new ValidatorBuilder<Sample>();
                builder
                    .Marker
                    .Range(x => x.Age, 10, 30)
                    .Required(x => x.Name)
                    .Required(x => x.Surname)
                    .PhoneNumber(x => x.Surname)
                    .Predicate(x =>
                    {
                        if (!string.IsNullOrEmpty(x.Surname) && x.Surname.Contains("fakeSample"))
                            return true;
                        return false;
                    })
                    .NotNull(x => x.Token)
                    .NotNull(x => x.Token.TokenNumber)
                    .NotNull(x => x.Token.InnerToken.TokenNumber)
                    .NotNull(x => x.Token.InnerToken.InnerToken.TokenNumber);

                return builder.Build();
            }
        }

        public static Sample ErrorModel { get; private set; }
        public static Sample NoErrorModel { get; private set; }

        public static IValidator WithNoErrors => CreateValidator();
        public static IValidator WithErrors => CreateValidator(false);
    }
}
