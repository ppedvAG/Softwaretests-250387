using FakeItEasy;
using Moq;
using NSubstitute;
using OpeningHours;

namespace ShopTests;

public class ShopTests
{
	[Fact]
	public void TestMoq()
	{
		//Arrange
		Mock<IShop> m = new Mock<IShop>(); //Mocking prüft nicht was das Objekt zurückgibt, sondern was das Objekt tut
		m.Setup(m => m.IsWeekend()).Returns(false);

		//Act
		bool b = m.Object.IsOpen();

		//Assert
		m.Verify(m => m.IsWeekend(), Moq.Times.AtLeastOnce);
	}

	[Fact]
	public void TestNSubstitute()
	{
		//Arrange
		Shop m = Substitute.For<Shop>(); //Mocking prüft nicht was das Objekt zurückgibt, sondern was das Objekt tut
		m.IsWeekend().Returns(false);

		//Act
		bool b = m.IsOpen();

		//Assert
		m.Received(1);
	}

	[Fact]
	public void TestFakeItEasy()
	{
		//Arrange
		Shop m = A.Fake<Shop>(); //Mocking prüft nicht was das Objekt zurückgibt, sondern was das Objekt tut
		A.CallTo(() => m.IsWeekend()).Returns(false);

		//Act
		bool b = m.IsOpen();

		//Assert
		A.CallTo(() => m.IsWeekend()).MustHaveHappenedOnceOrMore();
	}
}