using System.Collections.Generic;

namespace DynamicVNET.Lib.Unit.Tests
{
    public class UserStub
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public TokenStub Token { get; set; }

        public IEnumerable<string> Tokens { get; set; }

        public int GetAge()
        {
            return this.Age;
        }
    }
}
