using Bankkonto;

namespace M008_BankkontoTests;

internal class MockKonto : IKonto
{
	private double _kontostand;

	public double Kontostand => _kontostand;

	public void Auszahlen(double d)
	{
		if (d <= 0)
			throw new ArgumentException("Der Betrag muss größer als 0 sein!");

		if (_kontostand - d < 0)
			throw new ArgumentException("Neuer Kontostand würde 0 unterschreiten!");

		_kontostand -= d;
	}

	public void Einzahlen(double d)
	{
		if (d <= 0)
			throw new ArgumentException("Der Betrag muss größer als 0 sein!");

		_kontostand += d;
	}

	public void SetKontostand(double d)
	{
		_kontostand = d;
	}
}
