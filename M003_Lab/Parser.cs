
namespace M003_Lab;

public class Parser
{
	public int ConvertMeter(string m)
	{
		if (int.TryParse(m, out int x))
			return x;
		throw new ArgumentException("Text kann nicht in Meter konvertiert werden");
	}

	public TimeSpan ConvertTime(string t)
	{
		string[] parts = t.Split(":");
		if (parts.Length == 3)
		{
			List<int> zahlen = [];
			foreach (string s in parts)
			{
				if (int.TryParse(s, out int x))
					zahlen.Add(x);
				else
					throw new ArgumentException("Einer der gegebenen Werte ist keine Zahl.");
			}
			return new TimeSpan(zahlen[0], zahlen[1], zahlen[2]);
		}
		throw new ArgumentException("Es wurden nicht 3 Werte übergeben.");
	}
}

public class Converter
{
	public const double KilometerToMiles = 1.60934;

	public double ConvertMeterSekunde(int meter, int sek)
	{
		return (double) meter / sek;
	}

	public double ConvertKilometerStunde(int meter, int sek)
	{
		return (double) meter / sek * 3.6;
	}

	public double ConvertMeilenStunde(int meter, int sek)
	{
		return (double) meter / sek * 3.6 / KilometerToMiles;
	}
}