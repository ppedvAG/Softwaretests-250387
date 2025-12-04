using Microsoft.VisualStudio.TestTools.UnitTesting;
using FlaUI.Core;
using FlaUI.UIA3;
using FlaUI.Core.AutomationElements;

namespace M009_WPFTests
{
	[TestClass]
	public class WPFTests
	{
		/// <summary>
		/// FlaUI.Core
		/// FlaUI.UIA3
		/// </summary>
		[TestMethod]
		public void TestMethod1()
		{
			string path = "C:\\Users\\lk3\\source\\repos\\Softwaretests_2025_12_01\\M009_WPF\\bin\\Debug\\net9.0-windows\\M009_WPF.exe";
			Application app = Application.Launch(path);
			Window w = app.GetMainWindow(new UIA3Automation());

			Label l = w.FindFirstDescendant(e => e.ByText("0")).AsLabel();

			Button b = w.FindFirstDescendant(e => e.ByText("ZahlPlus1")).AsButton();

			b.Click();
			b.Click();
			b.Click();

			Assert.AreEqual("3", l.Text);

			w.Close();
		}

		[TestMethod]
		public void TestMethod2()
		{
			string path = "C:\\Program Files\\WindowsApps\\Microsoft.WindowsCalculator_11.2508.1.0_x64__8wekyb3d8bbwe\\CalculatorApp.exe";
			Application app = Application.Launch(path);
			Window w = app.GetMainWindow(new UIA3Automation());

			Label l = w.FindFirstDescendant(e => e.ByText("0")).AsLabel();

			Button b1 = w.FindFirstDescendant(e => e.ByText("1")).AsButton();
			Button bPlus = w.FindFirstDescendant(e => e.ByText("+")).AsButton();
			Button b2 = w.FindFirstDescendant(e => e.ByText("2")).AsButton();
			Button bErgebnis = w.FindFirstDescendant(e => e.ByText("=")).AsButton();

			b1.Click();
			bPlus.Click();
			b2.Click();
			bErgebnis.Click();

			Assert.AreEqual("3", l.Text);

			w.Close();
		}
	}
}
