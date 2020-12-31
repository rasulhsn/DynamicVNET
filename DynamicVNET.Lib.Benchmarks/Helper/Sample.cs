namespace DynamicVNET.Lib.Benchmarks.Helper
{
    public class SampleToken
    {
        public SampleToken InnerToken { get; set; }
        public string TokenNumber { get; set; }
    }
    public class Sample
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public SampleToken Token { get; set; }
    }
}
