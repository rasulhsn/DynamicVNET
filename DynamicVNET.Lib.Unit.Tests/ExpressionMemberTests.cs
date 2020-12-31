using System;
using System.Linq.Expressions;
using DynamicVNET.Lib.Internal;
using Xunit;

namespace DynamicVNET.Lib.Unit.Tests
{
    /// <summary>
    /// <see cref="ExpressionMember"/>
    /// </summary>
    public class ExpressionMemberTests
    {
        private UserStub _instance;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpressionMemberTests"/> class.
        /// </summary>
        public ExpressionMemberTests()
        {
            _instance = new UserStub()
            {
                Age = 30,
                Token = new TokenStub()
                {
                    InnerToken = new TokenStub()
                    {
                        TokenNumber = "11111"
                    }
                },
            };
        }


        [Fact]
        public void Initialize_GivenNestedProperty_ReturnPropertyNameByModel()
        {
            // Act
            const string expected = nameof(_instance.Token.InnerToken.TokenNumber);
            Expression<Func<UserStub, string>> lambda = (x) => x.Token.InnerToken.TokenNumber;

            // Arrange
            ExpressionMember vMember = new ExpressionMember(lambda, typeof(UserStub), typeof(string));

            // Assert
            Assert.Equal(expected, vMember.EndPointName);
        }

        [Fact]
        public void ResolveValue_GivenModelPropertyLambdaExpressionMethod_ReturnsSameWithModelAge()
        {
            // Act
            const int expectedAge = 30;
            Expression<Func<UserStub, int>> lambda = (model) => model.GetAge();
            ExpressionMember vMember = new ExpressionMember(lambda, typeof(UserStub), typeof(string));

            // Arrange
            int actualAge = int.Parse(vMember.ResolveValue(_instance).ToString());

            // Assert
            Assert.Equal(expectedAge, actualAge);
        }
    }
}
