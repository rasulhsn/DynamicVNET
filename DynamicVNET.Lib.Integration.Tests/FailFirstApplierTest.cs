using System.Collections.Generic;
using System.Linq;
using DynamicVNET.Lib.Integration.Tests.Stub;
using DynamicVNET.Lib.Internal;
using Xunit;

namespace DynamicVNET.Lib.Integration.Tests
{
    /// <summary>
    /// <see cref="FailFirstApplier"/>
    /// </summary>
    public class FailFirstApplierTest
    {
        private UserStub _stub;

        /// <summary>
        /// Initializes a new instance of the <see cref="FailFirstApplierTest"/> class.
        /// </summary>
        public FailFirstApplierTest()
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

        private IEnumerable<IValidation> CreateRules()
        {
            RuleMarker<UserStub> marker = new RuleMarker<UserStub>();
            marker.For(x => x.Name).Required().StringLen(10);
            marker.For(x => x.Surname).Required().StringLen(6);

            return marker.Rules;
        }

        [Fact]
        public void Apply_GivenConditionForOnlyInvalid_ReturnAllValidationRulesResult()
        {
            var rules = CreateRules();
            var applier = new FailFirstApplier();

            var actual = applier.Apply(rules, _stub);

            Assert.True(actual.Count() == 1);
        }
    }
}
