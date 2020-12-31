using System;
using Xunit;

namespace DynamicVNET.Lib.Integration.Tests
{
    /// <summary>
    /// <see cref="TagValidator"/>
    /// </summary>
    public class TagValidatorTests
    {
        private ITagValidator Create()
        {
            TagValidatorBuilder builder = new TagValidatorBuilder();

            builder.MarkAs<UserStub>("OnlyName", (marker) =>
             {
                 marker
                     .For(x => x.Name)
                     .Required()
                     .StringLen(15);
             });

            return builder.Build();
        }

        [Fact]
        public void GetAs_PutValidTag_ReturnsReferencedValidator()
        {
            var tagValidator = Create();

            var validator = tagValidator.GetAs("OnlyName");

            Assert.NotNull(validator);
        }

        [Fact]
        public void GetAs_PutInvalidTag_ThrowException()
        {
            var tagValidator = Create();

            Assert.Throws<Exception>(() => {
                tagValidator.GetAs("Only");
            });
        }
    }
}
