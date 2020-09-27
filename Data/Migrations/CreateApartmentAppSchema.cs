using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apartment_app.Data.Migrations
{
    public class CreataApartmentSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "Properties",
               columns: table => new
               {
                   PropertyName = table.Column<string>(nullable: false),
                   PropertyLocation = table.Column<string>(nullable: false),
                   PropertyOwner = table.Column<string>(nullable: false),
                   PropertyRent = table.Column<int>(nullable: false),
                   PropertySpaces = table.Column<int>(nullable: false),
                   PropertySpacesAvailable = table.Column<int>(nullable: false),
                   PropertyDescription = table.Column<string>(nullable: true),
                   PropertyImages = table.Column<string>(nullable: true),
                   IsApproved = table.Column<bool>(defaultValue: false),
               });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
