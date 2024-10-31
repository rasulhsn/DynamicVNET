using System.Linq;
using DynamicVNET.Lib.Integration.Tests.Stub;
using Xunit;

namespace DynamicVNET.Lib.Integration.Tests
{
    public class ModelValidatorTest
    {
        [Fact]
        public void Example()
        {
            UserStub model = new UserStub()
            {
                Age = 12,
                Name = "a",
                Surname = "b",
                Token = new TokenStub() { TokenNumber = "AAAAAAAAAAAAAAAAA" }
            };
            var validator = new ModelValidator();

            bool actual = validator.IsValid(model);
            var result = validator.Validate(model);

            Assert.False(actual);
            Assert.True(result != null && result.Count() == 4);
        }

        [Fact]
        public void Example2()
        {
            UserStub model = new UserStub()
            {
                Age = 19,
                Name = "a",
                Surname = "b",
                Token = new TokenStub() { TokenNumber = "resul@gmail" }
            };
            var validator = new ModelValidator();

            bool actual = validator.IsValid(model);

            Assert.False(actual);
        }


        [Fact]
        public void Example3()
        {
            UserStub model = new UserStub()
            {
                Age = 19,
                Name = "a",
                Surname = "b",
                Token = new TokenStub() { TokenNumber = "resul@gmail.com" }
            };
            var validator = new ModelValidator();

            bool actual = validator.IsValid(model);

            Assert.True(actual);
        }

        [Fact]
        public void Example4()
        {
            string value = "aaaa";
            var validator = new StringValidator();

            bool actual = validator.IsValid(value);

            Assert.True(actual);
        }


        [Fact]
        public void Example5()
        {
            UserStub model = new UserStub()
            {
                Age = 20,
                Name = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Surname = "b",
                Token = new TokenStub() { TokenNumber = "resul@gmail.com" }
            };
            var validator = new ModelValidator();

            bool actual = validator.IsValid(model);

            Assert.False(actual);
        }

        [Fact]
        public void Example6()
        {
            string value = "HuseynovHuseynov";
            var validator = new StringValidator();

            bool actual = validator.IsValid(value);

            Assert.False(actual);
        }

        [Fact]
        public void ExampleWithFailFast8()
        {
            UserStub model = new UserStub()
            {
                Age = 12,
                Name = "a",
                Surname = "b",
                Token = new TokenStub() { TokenNumber = "AAAAAAAAAAAAAAAAA" }
            };
            var validator = new UserStubStrongValidator();

            var result = validator.Validate(model);

            Assert.True(result != null && result.Count() == 1);
        }

        [Fact]
        public void Example9()
        {
            UserStub model = new UserStub()
            {
                Age = 19,
                Name = "a",
                Surname = "b",
                Token = new TokenStub() { TokenNumber = "resul@gmail" }
            };
            var validator = new UserStubStrongValidator();

            bool actual = validator.IsValid(model);

            Assert.False(actual);
        }

        [Fact]
        public void Example10()
        {
            UserStub model = new UserStub()
            {
                Age = 20,
                Name = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
                Surname = "b",
                Token = new TokenStub() { TokenNumber = "resul@gmail.com" }
            };
            var validator = new UserStubStrongValidator();

            bool actual = validator.IsValid(model);

            Assert.False(actual);
        }
    }
}
