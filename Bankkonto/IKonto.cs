namespace Bankkonto;

public interface IKonto
{
	double Kontostand { get; }

	void Auszahlen(double v);

	void Einzahlen(double v);
}