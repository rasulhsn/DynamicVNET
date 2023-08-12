using DynamicVNET.Lib.Exceptions;
using Xunit;
using DynamicVNET.Lib.Internal;
using System.Linq.Expressions;
using System;
using System.Linq;

namespace DynamicVNET.Lib.Integration.Tests
{
    /// <summary>
    /// <see cref="RuleMarker{T}"/>
    /// </summary>
    public class RuleMarkerTest
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
            IMember ageMember = new ExpressionMember(lambda, typeof(UserStub), typeof(int));

            // Arrange
            // Assert
            Assert.Throws<ValidationMarkerException>(() => {
                builder.Null(ageMember, "");
            });
        }

        [Fact]
        public void RulesCount_GivenTwoRules_ReturnsWillBeOne()
        {
            // Act
            int expectedCount = 1;
            RuleMarker<UserStub> builder = new RuleMarker<UserStub>();
            builder.Required(x => x.Name)
                   .Required(x => x.Name);

            // Arrange
            int actualCount = builder.Rules.Count();

            // Assert
            Assert.Equal(expectedCount, actualCount);
        }
    }
}
