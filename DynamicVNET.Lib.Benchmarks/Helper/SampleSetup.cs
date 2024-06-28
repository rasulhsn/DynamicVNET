using Bogus;

namespace DynamicVNET.Lib.Benchmarks.Helper
{
    public static class SampleSetup
    {
        public static (IValidator Validator, Sample Instance) CreateErrorType()
        {
            var sampleToken = CreateSampleToken();

            var errorModelFaker = new Faker<Sample>()
                     .RuleFor(m => m.Age, m => m.Random.Int(0, 5))
                     .RuleFor(m => m.Name, m => m.Lorem.Word());

            var ErrorModel = errorModelFaker.Generate();
            ErrorModel.Token = sampleToken;

            var validator = ValidatorFactory.Create<Sample>(builder =>
            {
                builder
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
            }, failFirst: true);

            return (validator, ErrorModel);
        }

        public static (IValidator Validator, Sample Instance) CreateNonErrorType()
        {
            var sampleToken = CreateSampleToken();

            var modelFaker = new Faker<Sample>()
                     .RuleFor(m => m.Age, m => m.Random.Int(10, 30))
                     .RuleFor(m => m.Name, m => m.Lorem.Word())
                     .RuleFor(m => m.Surname, m => "fakeSample");

            var NoErrorModel = modelFaker.Generate();
            NoErrorModel.Token = sampleToken;

            var validator = ValidatorFactory.Create<Sample>(builder =>
            {
                builder
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
            });

            return (validator, NoErrorModel);
        }

        private static SampleToken CreateSampleToken()
        {
            var tokenFaker = new Faker<SampleToken>()
                    .RuleFor(x => x.TokenNumber, m => m.Random.Guid().ToString());

            SampleToken tokenSample = tokenFaker.Generate();
            tokenSample.InnerToken = tokenFaker.Generate();
            tokenSample.InnerToken.InnerToken = tokenFaker.Generate();

            return tokenSample;
        }
    }
}
