using Xunit;

namespace DynamicVNET.Lib.Integration.Tests
{
    public class ValidatorBuilderTests
    {
        [Fact]
        public void IsValid()
        {
            // Act
            ValidatorBuilder<UserStub> builder = new ValidatorBuilder<UserStub>();
            builder.Marker
                    .Required(x => x.Name)
                    .Required(x => x.Surname);
            var validator = builder.Build();

            // Arrange
            bool isValid = validator.IsValid(new UserStub());

            // Assert
            Assert.False(isValid);
        }
    }
}
