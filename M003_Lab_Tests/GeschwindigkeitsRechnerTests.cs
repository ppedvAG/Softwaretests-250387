using M003_Lab;

namespace M003_Lab_Tests;

public class GeschwindigkeitsRechnerTests
{
	[Fact]
	public void Parser_Meter_ResultInt()
	{
		Parser p = new Parser();

		int m = p.ConvertMeter("4500");

		Assert.Equal(4500, m);
	}

	[Fact]
	public void Parser_Time_ResultTimeSpan()
	{
		Parser p = new Parser();

		TimeSpan t = p.ConvertTime("01:05:25");
		long sec = (1 * 60 * 60) + (5 * 60) + 25;

		Assert.Equal(sec, t.TotalSeconds);
	}

	[Fact]
	public void Parser_Time_ResultException()
	{
		Parser p = new Parser();

		Assert.Throws<ArgumentException>(() => p.ConvertTime("01:01"));
	}

	[Fact]
	public void Converter_MeterSekunde_ResultsTrue()
	{
		Converter c = new Converter();

		double ms = c.ConvertMeterSekunde(4500, 3925);

		Assert.Equal(1.1464968, ms, 0.01);
	}

	[Fact]
	public void Converter_KilometerStunde_ResultsTrue()
	{
		Converter c = new Converter();

		double kmh = c.ConvertKilometerStunde(4500, 3925);

		Assert.Equal(4.127388, kmh, 0.01);
	}

	[Fact]
	public void Converter_MeilenStunde_ResultsTrue()
	{
		Converter c = new Converter();

		double ms = c.ConvertMeilenStunde(4500, 3925);

		Assert.Equal(2.56464, ms, 0.01);
	}
}
