using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Quantum.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    note_id = table.Column<Guid>(type: "uuid", nullable: false),
                    header = table.Column<string>(type: "text", nullable: true),
                    content = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("note_pkey", x => x.note_id);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "note_id", "content", "created", "header" },
                values: new object[,]
                {
                    { new Guid("65e36e51-b7a3-41f2-a66c-1cd1bf527944"), "Note 4 Content", new DateTime(2023, 9, 29, 23, 35, 57, 49, DateTimeKind.Local).AddTicks(6468), "Note 4 Header" },
                    { new Guid("699286ae-38c6-4857-ac76-416f7a53ca19"), "Note 1 Content", new DateTime(2023, 9, 26, 23, 35, 57, 49, DateTimeKind.Local).AddTicks(6425), "Note 1 Header" },
                    { new Guid("75712383-e4cf-4f24-bd7b-d58f8146672a"), "Note 2 Content", new DateTime(2023, 9, 27, 23, 35, 57, 49, DateTimeKind.Local).AddTicks(6463), "Note 2 Header" },
                    { new Guid("f0110bd3-5f88-4506-a588-8a8a39fa2857"), "Note 3 Content", new DateTime(2023, 9, 28, 23, 35, 57, 49, DateTimeKind.Local).AddTicks(6466), "Note 3 Header" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");
        }
    }
}
