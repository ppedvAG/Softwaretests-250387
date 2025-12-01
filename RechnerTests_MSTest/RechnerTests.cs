using Rechner;

namespace RechnerTests_MSTest;

[TestClass]
public sealed class RechnerTests
{
	[TestInitialize]
	public void Init() { }

	[TestCleanup]
	public void Cleanup() { }

	///////////////////////////////////////////////////////////////

	[TestMethod] //Effektiv Test
	[TestCategory("Add")]
	public void Sum_3and4_result7()
	{
		//AAA

		//Arrange
		Calculator c = new Calculator();

		//Act
		int summe = c.Add(3, 4);

		//Assert
		Assert.AreEqual(7, summe);
	}

	[TestMethod] //Theory: Mehrere Tests mit mehreren Werten
	[DataRow(1, 2, 3)] //InlineData: Testwerte für diesen konkreten Test
	[DataRow(5, 5, 10)] //In Summe 3 Tests
	[DataRow(6, -2, 4)]
	[TestCategory("Add")] //Trait: Beschreibung
	[TestCategory("Multiple Values")]
	public void Sum_MultipleValues_MultipleResults(int x, int y, int result)
	{
		//AAA

		//Arrange
		Calculator c = new Calculator();

		//Act
		int summe = c.Add(x, y);

		//Assert
		Assert.AreEqual(result, summe);
	}

	[TestMethod]
	[TestCategory("Mult")]
	public void Mult_2and2_result4()
	{
		//AAA

		//Arrange
		Calculator c = new Calculator();

		//Act
		int produkt = c.Mult(2, 2);

		//Assert
		Assert.AreEqual(4, produkt);
	}
}
