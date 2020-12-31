using DynamicVNET.Lib.Internal;
using System.Linq;
using Xunit;

namespace DynamicVNET.Lib.Integration.Tests
{
    /// <summary>
    /// <see cref="OnlyInvalidResultStrategy"/>
    /// </summary>
    public class OnlyInvalidResultStrategyTests
    {
        private UserStub _stub;

        /// <summary>
        /// Initializes a new instance of the <see cref="OnlyInvalidResultStrategyTests"/> class.
        /// </summary>
        public OnlyInvalidResultStrategyTests()
        {
            _stub = new UserStub()
            {
                Age = 30,
                Name = "NameTest",
                Surname = "SurnameTest",
                Token = new TokenStub()
                {
                    InnerToken = new TokenStub()
                    {
                        TokenNumber = "11111"
                    }
                },
            };
        }

        /// <summary>
        /// Creates the strategy.
        /// </summary>
        /// <returns></returns>
        private OnlyInvalidResultStrategy CreateStrategy()
        {
            RuleMarker<UserStub> builder = new RuleMarker<UserStub>();
            builder.For(x => x.Name).Required().StringLen(10);
            builder.For(x => x.Surname).Required().StringLen(6);

            return new OnlyInvalidResultStrategy(builder);
        }


        [Fact]
        public void Build_GivenConditionForOnlyInvalid_ReturnAllValidationRulesResult()
        {
            var strategy = CreateStrategy();

            var actual = strategy.Build(_stub);

            Assert.True(actual.Count() == 1);
        }
    }
}
