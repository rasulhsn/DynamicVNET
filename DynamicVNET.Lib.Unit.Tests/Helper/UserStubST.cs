namespace DynamicVNET.Lib.Unit.Tests
{
    public struct UserStubST
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public TokenStub Token { get; set; }

        public UserStubST(string name, string surname, TokenStub token)
        {
            this.Age = 15;
            this.Name = name;
            this.Surname = surname;
            this.Token = token;
        }
    }
}
