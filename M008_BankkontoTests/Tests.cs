using Bankkonto;

namespace M008_BankkontoTests;

public class Tests
{
	[Fact]
	public void Einzahlen_Plus50_Result50()
	{
		//AAA
		//IKonto konto = new MockKonto();
		IKonto konto = new Konto();

		konto.Einzahlen(50d);

		Assert.Equal(50, konto.Kontostand);
	}

	[Fact]
	public void Auszahlen_Minus50_Result0()
	{
		//AAA
		//IKonto konto = new MockKonto();
		IKonto konto = new Konto();

		konto.Einzahlen(50d); //Realität
							  //((MockKonto) konto).SetKontostand(50);
		konto.Auszahlen(50d);

		Assert.Equal(0, konto.Kontostand);
	}

	[Fact]
	public void NeuesKonto_New_Result0()
	{
		//AAA
		//IKonto konto = new MockKonto();
		IKonto konto = new Konto();

		Assert.Equal(0, konto.Kontostand);
	}

	[Fact]
	public void Einzahlen_Minus50_ResultException()
	{
		//AAA
		//IKonto konto = new MockKonto();
		IKonto konto = new Konto();

		Assert.Throws<ArgumentException>(() => konto.Einzahlen(-50d));
	}

	[Fact]
	public void Auszahlen_Minus50_ResultException()
	{
		//AAA
		//IKonto konto = new MockKonto();
		IKonto konto = new Konto();

		Assert.Throws<ArgumentException>(() => konto.Auszahlen(-50d));
	}
}