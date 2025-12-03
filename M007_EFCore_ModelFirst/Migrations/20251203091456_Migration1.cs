using Microsoft.EntityFrameworkCore.Migrations;


namespace M007_EFCore_ModelFirst.Migrations;

/// <summary>
/// Migrations bauen aufeinander auf
/// 
/// Wenn Migration2 angewandt wird, wird Migration1 auch angewandt (und umgekehrt)
/// </summary>
public partial class Migration1 : Migration
{
	protected override void Up(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.CreateTable(
			name: "Personen",
			columns: table => new
			{
				Id = table.Column<int>(type: "int", nullable: false)
					.Annotation("SqlServer:Identity", "1, 1"),
				Vorname = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Nachname = table.Column<string>(type: "nvarchar(max)", nullable: false),
				Alter = table.Column<int>(type: "int", nullable: false)
			},
			constraints: table =>
			{
				table.PrimaryKey("PK_Personen", x => x.Id);
			});
	}

	/// <inheritdoc />
	protected override void Down(MigrationBuilder migrationBuilder)
	{
		migrationBuilder.DropTable(
			name: "Personen");
	}
}
