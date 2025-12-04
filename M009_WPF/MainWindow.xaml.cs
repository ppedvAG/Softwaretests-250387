using System.Windows;

namespace M009_WPF
{
	public partial class MainWindow : Window
	{
		private int counter;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			counter++;
			Output.Text = counter.ToString();
		}
	}
}