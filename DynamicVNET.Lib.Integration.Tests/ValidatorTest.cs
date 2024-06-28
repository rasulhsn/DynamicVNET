﻿using Xunit;

namespace DynamicVNET.Lib.Integration.Tests
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidatorTest
    {
        [Fact]
        public void IsValid_GivenInvalidObject_ReturnsFalse()
        {
            // Act
            var validator = ValidatorFactory.Create<UserStub>(builder =>
            {
                builder
                    .Required(x => x.Name)
                    .Required(x => x.Surname);
            });

            // Arrange
            bool isValid = validator.IsValid(new UserStub());

            // Assert
            Assert.False(isValid);
        }
    }
}