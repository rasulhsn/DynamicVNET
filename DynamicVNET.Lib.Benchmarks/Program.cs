using BenchmarkDotNet.Running;

namespace DynamicVNET.Lib.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
            => BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
    }
}
