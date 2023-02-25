using BenchmarkDotNet.Attributes;
using Microsoft.Diagnostics.Runtime.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Bench
{

    [MemoryDiagnoser]
    [RankColumn]
    [RPlotExporter]
    public class Benchmarks
    {
        public List<IntEntity> Ints { get; set; }


        [Benchmark]
        public int WithIntEntityToDictionary()
        {
            var dic = Ints.ToDictionary(x => x.Value);
            return dic.Count;
        }

        [Benchmark]
        public int WithIntEntityToFixedCapacityDictionary()
        {
            var dic = new Dictionary<int, IntEntity>(Ints.Count);
            Ints.ForEach(x => dic.Add(x.Value, x));
            return dic.Count;
        }

        [Benchmark]
        public int WithIntEntityToDictionaryGrowingLinq()
        {
            var dic = new Dictionary<int, IntEntity>();
            Ints.ForEach(x => dic.Add(x.Value, x));
            return dic.Count;
        }

        [Benchmark]
        public int WithIntEntityToDictionaryGrowingForEach()
        {
            var dic = new Dictionary<int, IntEntity>();
            foreach (var ie in Ints)
            {
                dic.Add(ie.Value, ie);
            }
            return dic.Count;
        }

        [Benchmark]
        public int WithIntEntityToDictionaryGrowingForLoop()
        {
            var dic = new Dictionary<int, IntEntity>();
            for (int i = -10000; i <= 10000; i++)
            {
                var item = new IntEntity(i);
                dic.Add(item.Value, item);
            }
            return dic.Count;
        }

        [Benchmark]
        public int WithIntEntityToDictionaryFixedCapacityForLoop()
        {
            var dic = new Dictionary<int, IntEntity>(200001);
            for (int i = -10000; i <= 10000; i++)
            {
                var item = new IntEntity(i);
                dic.Add(item.Value, item);
            }
            return dic.Count;
        }

        private List<IntEntity> GetInts()
        {
            var results = new List<IntEntity>();
            for (int i = -10000; i <= 10000; i++)
            {
                results.Add(new IntEntity(i));
            }
            return results;
        }

        [GlobalSetup]
        public void Setup()
        {
            Ints = GetInts();
        }
    }
}
