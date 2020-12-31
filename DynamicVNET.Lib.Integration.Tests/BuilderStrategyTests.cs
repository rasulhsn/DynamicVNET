using System.Linq;
using DynamicVNET.Lib.Internal;
using Xunit;

namespace DynamicVNET.Lib.Integration.Tests
{
    /// <summary>
    /// <see cref="BuilderStrategy"/>
    /// </summary>
    public class BuilderStrategyTests
    {
        private readonly UserStub _stub;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuilderStrategyTests"/> class.
        /// </summary>
        public BuilderStrategyTests()
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
        private BuilderStrategy CreateStrategy()
        {
            RuleMarker<UserStub> builder = new RuleMarker<UserStub>();
            builder.For(x => x.Name).Required().StringLen(10);
            builder.For(x => x.Surname).Required().StringLen(6);

            return new BuilderStrategy(builder);
        }


        [Fact]
        public void Build_GivenRightMarkerWithInstance_ReturnAllValidationRulesResult()
        {
            var strategy = CreateStrategy();

            var actual = strategy.Build(_stub);

            Assert.True(actual.Count() == 4);
        }
    }
}
