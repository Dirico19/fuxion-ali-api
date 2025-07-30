using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fuxion.Ali.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: ["Id", "Name", "Password"],
                values: new object[,]
                {
                    { "ed12f657-91dc-4996-9c7a-3ad51779e43a", "admin", "$2a$11$HAj.uS4cwsYEkg0GF7eq2ON3pSg/0d7P31jJ2ZKxdohI4wwknh8J2" }
                }
            );

            migrationBuilder.InsertData(
                table: "Roles",
                columns: ["Id", "Name", "Description"],
                values: new object[,]
                {
                    { "91c448cd-d538-4edd-a3c0-cd2da4c8fdce", "SuperAdmin", "Super Administrador" },
                    { "d9b3740e-0d34-44d9-b73d-77e486e3f19c", "Admin", "Administrador" },
                    { "42b358d9-72a6-4914-b9ea-d5f60e87e778", "User", "Usuario" }
                }
            );

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: ["UserId", "RoleId"],
                values: new object[,]
                {
                    { "ed12f657-91dc-4996-9c7a-3ad51779e43a", "91c448cd-d538-4edd-a3c0-cd2da4c8fdce" },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: ["UserId", "RoleId"],
                keyValues: ["ed12f657-91dc-4996-9c7a-3ad51779e43a", "91c448cd-d538-4edd-a3c0-cd2da4c8fdce"]
            );

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "ed12f657-91dc-4996-9c7a-3ad51779e43a"
            );

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValues:
                [
                    "91c448cd-d538-4edd-a3c0-cd2da4c8fdce",
                    "d9b3740e-0d34-44d9-b73d-77e486e3f19c",
                    "42b358d9-72a6-4914-b9ea-d5f60e87e778"
                ]
            );
        }
    }
}

