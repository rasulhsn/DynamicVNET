using DynamicVNET.Lib.Exceptions;
using Xunit;
using DynamicVNET.Lib.Internal;
using System.Linq.Expressions;
using System;

namespace DynamicVNET.Lib.Integration.Tests
{
    /// <summary>
    /// <see cref="RuleMarker{T}"/>
    /// </summary>
    public class RuleMarkerTests
    {

        [Fact]
        public void Null_GivenInvalidTypeMember_ThrowValidationMarkerException()
        {
            // Act
            UserStub model = new UserStub()
            {
                Name = "TestName",
                Surname = "TestSurname",
                Age = 30
            };
            RuleMarker<UserStub> builder = new RuleMarker<UserStub>();
            Expression<Func<UserStub, int>> lambda = x => x.Age;
            IMember ageMember = new ExpressionMember(lambda, typeof(UserStub), typeof(int));// must be mock

            // Arrange
            // Assert
            Assert.Throws<ValidationMarkerException>(() => {
                builder.Null(ageMember, "");
            });
        }
    }
}
