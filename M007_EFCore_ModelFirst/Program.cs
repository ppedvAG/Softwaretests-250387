using Bogus;
using Microsoft.EntityFrameworkCore;

namespace M007_EFCore_ModelFirst;

internal class Program
{
	static void Main(string[] args)
	{
		PersonDbContext db = new("Server=localhost;Database=PersonDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True");

		db.Database.Migrate();

		//Arbeiten mit EF

		//List<Person> g = GeneratePersonen(100);

		//db.Personen.AddRange(g); //Fügt die Personen in die Liste hinzu (aber noch nicht in die DB)
		//db.SaveChanges(); //Schreibt die Änderungen tatsächlich in die DB

		//Daten auslesen
		IQueryable<Person> personen = db.Personen; //Dieses Linq-Statement wird zu SQL übersetzt (SELECT * FROM Personen WHERE Vorname LIKE 'A%';)
	
		//WICHTIG: Dieses Statement wird nicht ausgeführt, bis es mit ToList() oder ToArray() oder einer foreach-Schleife angesprochen wird
		List<Person> a = personen.ToList() //Hier werden die Daten tatsächlich geladen (Lazy Loading = Erst Laden, wenn die Daten benötigt werden)
			.Where(e => e.Vorname.StartsWith('A')).ToList();

		//db.Database.ExecuteSqlRaw("SELECT * FROM Personen WHERE Vorname LIKE 'A%'"); //Alternative
	}

	static List<Person> GeneratePersonen(int anz)
	{
		Faker<Person> p = new Faker<Person>();
		//p.RuleFor(e => e.Id, e => e.IndexFaker); //Nicht Id setzen, weil die DB Auto-Increment verwendet
		p.RuleFor(e => e.Vorname, e => e.Name.FirstName());
		p.RuleFor(e => e.Nachname, e => e.Name.LastName());
		p.RuleFor(e => e.Alter, e => e.Random.Int(20, 70));
		return p.Generate(anz);
	}
}
