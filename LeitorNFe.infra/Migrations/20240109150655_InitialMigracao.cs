﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeitorNFe.infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    xLgr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    xCpl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    xBairro = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cMun = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    xMun = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cPais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    xPais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Ides",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nNF = table.Column<long>(type: "bigint", nullable: false),
                    dhEmi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dhSaiEnt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InfNFeID = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ides", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InfNFe",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfNFe", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dests",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    xNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    infNFeID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dests", x => x.CPF);
                    table.ForeignKey(
                        name: "FK_Dests_InfNFe_infNFeID",
                        column: x => x.infNFeID,
                        principalTable: "InfNFe",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Dests_addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "addresses",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Emits",
                columns: table => new
                {
                    CNPJ = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    xNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    xFant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    infNFeID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddressID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emits", x => x.CNPJ);
                    table.ForeignKey(
                        name: "FK_Emits_InfNFe_infNFeID",
                        column: x => x.infNFeID,
                        principalTable: "InfNFe",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Emits_addresses_AddressID",
                        column: x => x.AddressID,
                        principalTable: "addresses",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "iCMSTots",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    infNFeID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    vNF = table.Column<decimal>(type: "decimal(18,10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iCMSTots", x => x.ID);
                    table.ForeignKey(
                        name: "FK_iCMSTots_InfNFe_infNFeID",
                        column: x => x.infNFeID,
                        principalTable: "InfNFe",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "InfProt",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    infNFeID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    chNFe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfProt", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InfProt_InfNFe_infNFeID",
                        column: x => x.infNFeID,
                        principalTable: "InfNFe",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Prods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cEAN = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    xProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NCM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CEST = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CFOP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uCom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qCom = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    vUnCom = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    vProd = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    cEANTrib = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uTrib = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qTrib = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    vUnTrib = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    vDesc = table.Column<decimal>(type: "decimal(18,10)", nullable: false),
                    indTot = table.Column<int>(type: "int", nullable: false),
                    infNFeID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Prods_InfNFe_infNFeID",
                        column: x => x.infNFeID,
                        principalTable: "InfNFe",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dests_AddressID",
                table: "Dests",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Dests_infNFeID",
                table: "Dests",
                column: "infNFeID",
                unique: true,
                filter: "[infNFeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Emits_AddressID",
                table: "Emits",
                column: "AddressID");

            migrationBuilder.CreateIndex(
                name: "IX_Emits_infNFeID",
                table: "Emits",
                column: "infNFeID",
                unique: true,
                filter: "[infNFeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_iCMSTots_infNFeID",
                table: "iCMSTots",
                column: "infNFeID",
                unique: true,
                filter: "[infNFeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_InfProt_infNFeID",
                table: "InfProt",
                column: "infNFeID",
                unique: true,
                filter: "[infNFeID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Prods_infNFeID",
                table: "Prods",
                column: "infNFeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dests");

            migrationBuilder.DropTable(
                name: "Emits");

            migrationBuilder.DropTable(
                name: "iCMSTots");

            migrationBuilder.DropTable(
                name: "Ides");

            migrationBuilder.DropTable(
                name: "InfProt");

            migrationBuilder.DropTable(
                name: "Prods");

            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "InfNFe");
        }
    }
}
