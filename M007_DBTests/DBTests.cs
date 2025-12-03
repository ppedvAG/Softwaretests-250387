using M007_EFCore_ModelFirst;
using Microsoft.EntityFrameworkCore;
using Testcontainers.MsSql;

namespace M007_DBTests;

public class DBTests : IAsyncLifetime //Stellt eine Startmethode und eine Endmethode bereit
{
	public static MsSqlContainer Container;

	public static PersonDbContext ContainerContext;

	public async Task InitializeAsync()
	{
		//NuGet: TestContainers.MsSql
		Container = new MsSqlBuilder()
			.WithImage("mcr.microsoft.com/mssql/server:2022-latest")
			.WithReuse(true)
			.Build();
		await Container.StartAsync();

		////////////////////////////////////////////////////////

		//Im DBAccess Projekt kann jetzt eine Migration angelegt werden
		//Diese Migration kann weiters im Container angewandt werden
		string conn = Container.GetConnectionString();

		ContainerContext = new PersonDbContext(conn);

		//ContainerContext.Database.ExecuteSqlRaw("DROP TABLE IF EXISTS Personen");
		ContainerContext.Database.Migrate();

		////////////////////////////////////////////////////////

		string sqlConn = "Server=localhost;Database=PersonDB;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True";

		PersonDbContext sqlContext = new PersonDbContext(sqlConn);

		IQueryable<Person> sqlPersonen = sqlContext.Personen;
		ContainerContext.Personen.AddRange(sqlPersonen);
		ContainerContext.SaveChanges();
	}

	public async Task DisposeAsync()
	{
		await Container.StopAsync();
	}

	////////////////////////////////////////////////////////////////////

	[Fact]
	public void Test1()
	{
		int anz = ContainerContext.Personen.Count();

		Assert.Equal(0, anz);
	}
}
