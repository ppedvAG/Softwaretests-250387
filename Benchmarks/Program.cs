using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Bogus;
using System.Text;

namespace Benchmarks;

internal class Program
{
	static void Main(string[] args)
	{
		BenchmarkRunner.Run<Benchmarks>();

		//BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args, new DebugInProcessConfig());
	}
}

[MemoryDiagnoser(false)]
[HtmlExporter]
//[IterationCount(50)]
public class Benchmarks
{
	//1. StringBuilder und String +
	//[Benchmark]
	[IterationCount(50)]
	public void BenchmarkStringBuilder()
	{
		StringBuilder sb = new StringBuilder(); //Speichert eine Liste von Strings; am Ende werden diese Strings mit ToString() zusammengebaut
		for (int i = 0; i < 10000; i++)
		{
			sb.Append(i);
		}
		string str = sb.ToString();
	}

	//[Benchmark]
	[IterationCount(50)]
	public void BenchmarkStringPlus()
	{
		string str = string.Empty;
		for (int i = 0; i < 10000; i++)
		{
			str += i;
		}
	}

	//2. Vergleich zw. Linq, Methodenketten, foreach-Schleife
	public List<Fahrzeug> Fahrzeuge = [];

	[Params(10000, 50000, 100000)]
	public int Anzahl;

	[GlobalSetup]
	public void BenchmarkSetup()
	{
		Faker<Fahrzeug> generator = new Faker<Fahrzeug>()
			.RuleFor(f => f.ID, f => f.IndexFaker)
			.RuleFor(f => f.MaxV, f => f.Random.Int(100, 300))
			.RuleFor(f => f.Marke, f => f.PickRandom<FahrzeugMarke>());
		Fahrzeuge = generator.Generate(Anzahl);
	}

	[Benchmark]
	public void BenchmarkForeach()
	{
		List<Fahrzeug> fzg = [];
		foreach (Fahrzeug f in Fahrzeuge)
			if (f.Marke == FahrzeugMarke.BMW)
				fzg.Add(f);
	}

	[Benchmark]
	public void BenchmarkLinq()
	{
		List<Fahrzeug> fzg = (from f in Fahrzeuge
							  where f.Marke == FahrzeugMarke.BMW
							  select f).ToList();
	}

	[Benchmark]
	public void BenchmarkLinqMethodenketten()
	{
		List<Fahrzeug> fzg = Fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).ToList();
	}
}

public class Fahrzeug
{
	public int ID { get; set; }

	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }
}

public enum FahrzeugMarke { Audi, BMW, VW }