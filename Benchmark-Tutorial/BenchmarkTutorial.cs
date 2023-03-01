using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;

namespace Benchmark_Tutorial;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
[GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
[InvocationCount(100)]
[BenchmarkCategory("StringOperations")]
[BaselineColumn]
public class BenchmarkTutorial
{
    
    
    [Params( 100,500, 1000)] 
    public int iterationCount;

    [Benchmark]
    public void StringConcat()
    {
        string temp = string.Empty;

        for (int i = 0; i < iterationCount; i++)
        {
            temp = string.Concat(temp, "a");
        }
    }

    [Benchmark(Baseline = true)]
    public void StringConcatUsingPlus()
    {
        string temp = string.Empty;

        for (int i = 0; i < iterationCount; i++)
        {
            temp += "a";
        }
    }

    [Benchmark]
    public void StringBuilderTest()
    {
        StringBuilder temp = new StringBuilder();

        for (int i = 0; i < iterationCount; i++)
        {
            temp.Append("a");
        }
    }


}