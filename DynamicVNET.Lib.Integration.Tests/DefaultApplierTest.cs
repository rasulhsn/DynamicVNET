using System.Collections.Generic;
using System.Linq;
using DynamicVNET.Lib.Integration.Tests.Stub;
using DynamicVNET.Lib.Internal;
using Xunit;

namespace DynamicVNET.Lib.Integration.Tests
{
    /// <summary>
    /// <see cref="DefaultApplier"/>
    /// </summary>
    public class DefaultApplierTest
    {
        private readonly UserStub _stub;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApplierTest"/> class.
        /// </summary>
        public DefaultApplierTest()
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
        public void Apply_WhenGivenRightMarkerWithInstance_ShouldReturnAllValidationRules()
        {
            var rules = CreateRules();
            var applier = new DefaultApplier();

            var actual = applier.Apply(rules, _stub);

            Assert.True(actual.Count() == 4);
        }
    }
}
