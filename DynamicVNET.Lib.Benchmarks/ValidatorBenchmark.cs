using BenchmarkDotNet.Attributes;
using DynamicVNET.Lib.Benchmarks.Helper;

namespace DynamicVNET.Lib.Benchmarks
{
    [MemoryDiagnoser]
    public class ValidatorBenchmark
    {
        private (IValidator Validator, Sample Instance) _validator;
        private (IValidator Validator, Sample Instance) _failFastValidator;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _validator = SampleSetup.CreateNonErrorType();
            _failFastValidator = SampleSetup.CreateErrorType();
        }

        [Benchmark]
        public object FailValidate()
        {
            var model = _failFastValidator.Instance;

            object vResult = null;

            vResult = _failFastValidator.Validator.Validate(model);

            return vResult;
        }

        [Benchmark]
        public object Validate()
        {
            var model = _validator.Instance;

            var vResult = new object();

            vResult = _validator.Validator.Validate(model);

            return vResult;
        }

        [Benchmark]
        public object FailIsValid()
        {
            var model = _failFastValidator.Instance;

            object vResult = null;

            vResult = _failFastValidator.Validator.IsValid(model);

            return vResult;
        }

        [Benchmark]
        public object IsValid()
        {
            var model = _validator.Instance;

            var vResult = new object();

            vResult = _validator.Validator.IsValid(model);

            return vResult;
        }
    }
}
