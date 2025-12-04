using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace M009_ASPTests;

public class SeleniumTests
{
	[Fact]
	public void Test1()
	{
		FirefoxOptions op = new FirefoxOptions();
		op.AddArgument("--headless");

		FirefoxDriver driver = new FirefoxDriver(op);

		driver.Navigate().GoToUrl("http://localhost:5000");

		driver.FindElements(By.TagName("button"))[1].Click();
		string inhalt = driver.FindElements(By.TagName("p"))[1].Text;

		Assert.Equal("1", inhalt);

		driver.Close();
	}
}