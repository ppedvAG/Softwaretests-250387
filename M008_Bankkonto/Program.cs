using Newtonsoft.Json;

namespace M008_Bankkonto;

internal class Program
{
	static void Main(string[] args)
	{
		int[] zahlen = [1, 2, 3, 4, 5];
		string json = JsonConvert.SerializeObject(zahlen);
		File.WriteAllText("Zahlen.json", json);

	}
}
