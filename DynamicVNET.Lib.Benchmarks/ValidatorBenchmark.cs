using BenchmarkDotNet.Attributes;
using DynamicVNET.Lib.Benchmarks.Helper;

namespace DynamicVNET.Lib.Benchmarks
{
    [MemoryDiagnoser]
    public class ValidatorBenchmark
    {
        private IValidator _validator;
        private IValidator _failFastValidator;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _validator = SampleSetup.WithNoErrors;
            _failFastValidator = SampleSetup.WithErrors;
        }

        [Benchmark]
        public object FailValidate()
        {
            var model = SampleSetup.ErrorModel;

            object vResult = null;

            vResult = _failFastValidator.Validate(model);

            return vResult;
        }

        [Benchmark]
        public object Validate()
        {
            var model = SampleSetup.NoErrorModel;

            var vResult = new object();

            vResult = _validator.Validate(model);

            return vResult;
        }

        [Benchmark]
        public object FailIsValid()
        {
            var model = SampleSetup.ErrorModel;

            object vResult = null;

            vResult = _failFastValidator.IsValid(model);

            return vResult;
        }

        [Benchmark]
        public object IsValid()
        {
            var model = SampleSetup.NoErrorModel;

            var vResult = new object();

            vResult = _validator.IsValid(model);

            return vResult;
        }
    }
}
