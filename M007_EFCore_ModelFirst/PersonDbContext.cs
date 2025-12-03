using Microsoft.EntityFrameworkCore;

namespace M007_EFCore_ModelFirst;

/// <summary>
/// NuGet:
/// - Microsoft.EntityFrameworkCore
/// - Microsoft.EntityFrameworkCore.SqlServer
/// </summary>
public class PersonDbContext : DbContext
{
	/// <summary>
	/// Für jeden Typen ein DbSet anlegen
	/// </summary>
	public DbSet<Person> Personen { get; set; }

	/// <summary>
	/// Hier muss der ConnectionString angegeben werden
	/// </summary>
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
		optionsBuilder.UseSqlServer(_connString);

	////////////////////////////////////////////////////////////////////////

	//Siehe M007_DBTests
	private readonly string _connString;

	public PersonDbContext() { }

	public PersonDbContext(string connString)
	{
		_connString = connString;
	}
}