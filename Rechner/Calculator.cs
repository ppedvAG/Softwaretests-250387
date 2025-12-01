using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RechnerTests_xUnit")]

namespace Rechner;

public class Calculator
{
	public int Add(int x, int y)
	{
		return x + y;
	}

	public int Mult(int x, int y)
	{
		return x * y;
	}

	internal double Div(int x, int y)
	{
		return (double) x / y;
	}
}
