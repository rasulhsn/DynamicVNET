namespace DynamicVNET.Lib.Integration.Tests
{
    public class TokenStub
    {
        public int? Version { get; set; }
        public TokenStub InnerToken { get; set; }
        public string TokenNumber { get; set; }
    }
}
