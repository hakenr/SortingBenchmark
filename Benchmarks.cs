using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace SortingBenchmark
{
	public class Benchmarks
    {
		[Benchmark(Baseline = true)]
		public int[] BoubleSort()
		{
			int temp;
			for (int j = 0; j <= data.Length - 2; j++)
			{
				for (int i = 0; i <= data.Length - 2; i++)
				{
					if (data[i] > data[i + 1])
					{
						temp = data[i + 1];
						data[i + 1] = data[i];
						data[i] = temp;
					}
				}
			}
			return data;
		}

		[Benchmark]
		public int[] BoubleSort_YourOptimization()
		{
			// TODO
			int temp;
			for (int j = 0; j <= data.Length - 2; j++)
			{
				for (int i = 0; i <= data.Length - 2; i++)
				{
					if (data[i] > data[i + 1])
					{
						temp = data[i + 1];
						data[i + 1] = data[i];
						data[i] = temp;
					}
				}
			}
			return data;
		}

		[Benchmark]
		public int[] YourImplementation()
		{
			// your implementation goes here
			throw new NotImplementedException();
		}

		[Params(3_000, 10_000)]
		public int N;

		private int[] originalData;
		private int[] data;

		[GlobalSetup]
		public void GlobalSetup()
		{
			originalData = new int[N];
			for (int i = 0; i < N; i++)
			{
				originalData[i] = Random.Shared.Next(N);
			}
		}

		[IterationSetup]
		public void IterationSetup()
		{
			data = (int[])originalData.Clone();
		}
	}
}
