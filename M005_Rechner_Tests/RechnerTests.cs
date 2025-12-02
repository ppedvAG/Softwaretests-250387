using M005_Rechner;

namespace M005_Rechner_Tests;

/// <summary>
/// Fine Code Coverage
/// 
/// Optionen -> Fine Code Coverage -> Editor Line Highlighting -> ShowLineCoverageHighlighting
/// </summary>
public class RechnerTests
{
	[Fact]
	public void Test1()
	{
		Calc c = new Calc();
		double summe = c.Add(2, 3);
		Assert.Equal(5, summe);
	}

	[Fact]
	public void Test2()
	{
		Calc c = new Calc();
		double diff = c.Sub(2, 3);
		Assert.Equal(-1, diff);
	}
}
