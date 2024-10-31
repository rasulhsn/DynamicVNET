using DynamicVNET.Lib.Integration.Tests.Stub;
using Xunit;

namespace DynamicVNET.Lib.Integration.Tests
{
    public class ValidatorTest
    {
        [Fact]
        public void IsValid_WhenGivenInvalidObject_ReturnsFalse()
        {
            // Act
            UserStub userInstance = new UserStub();
            var validator = ValidatorFactory.Create<UserStub>(builder =>
            {
                builder
                    .Required(x => x.Name)
                    .Required(x => x.Surname);
            });

            // Arrange
            bool isValid = validator.IsValid(userInstance);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void test()
        {
            // Act
            UserStub userInstance = new UserStub()
            {
                Age = 0
            };
            var validator = ValidatorFactory.Create<UserStub>(builder =>
            {
                var aa = builder;
                builder.GreaterThan(x => x.Age, 20);
            });

            // Arrange
            bool isValid = validator.IsValid(userInstance);

            // Assert
            Assert.False(isValid);
        }
    }
}
