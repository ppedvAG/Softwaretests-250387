using Rechner;

namespace RechnerTests_xUnit;

/// <summary>
/// Schritt 1: Projektverweis hinzufügen (Rechtsklick auf Abhängigkeiten -> Projektverweis hinzufügen -> Projekt auswählen)
/// Schritt 2: Text Explorer öffnen (Ansicht -> Test Explorer)
/// </summary>
public class RechnerTests : IDisposable
{
	/// <summary>
	/// Konstruktor: Startcode
	/// Bei jedem Test wird der Konstruktor einmal ausgeführt
	/// </summary>
	public RechnerTests()
	{

	}

	/// <summary>
	/// IDisposable
	/// Mechanismus, um Verbindungen nach außen wieder aufzuräumen
	/// Kann hier auch verwendet werden, um z.B. DB Verbindungen aufzuräumen
	/// </summary>
	public void Dispose()
	{

	}

	//////////////////////////////////////////////////////////////////////

	[Fact] //Effektiv Test
	[Trait("Category", "Add")]
	public void Sum_3and4_result7()
	{
		//AAA

		//Arrange
		Calculator c = new Calculator();

		//Act
		int summe = c.Add(3, 4);

		//Assert
		Assert.Equal(7, summe);
	}

	[Theory] //Theory: Mehrere Tests mit mehreren Werten
	[InlineData(1, 2, 3)] //InlineData: Testwerte für diesen konkreten Test
	[InlineData(5, 5, 10)] //In Summe 3 Tests
	[InlineData(6, -2, 4)]
	[Trait("Category", "Add")] //Trait: Beschreibung
	[Trait("Category", "Multiple Values")]
	public void Sum_MultipleValues_MultipleResults(int x, int y, int result)
	{
		//AAA

		//Arrange
		Calculator c = new Calculator();

		//Act
		int summe = c.Add(x, y);

		//Assert
		Assert.Equal(result, summe);
	}

	[Fact]
	[Trait("Category", "Mult")]
	public void Mult_2and2_result4()
	{
		//AAA

		//Arrange
		Calculator c = new Calculator();

		//Act
		int produkt = c.Mult(2, 2);

		//Assert
		Assert.Equal(4, produkt);
	}
}
