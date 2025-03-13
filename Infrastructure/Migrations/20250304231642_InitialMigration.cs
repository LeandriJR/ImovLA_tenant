using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tenant.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "modulo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertUser = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateUser = table.Column<Guid>(type: "uuid", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    ValorSoma = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modulo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "plano",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertUser = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateUser = table.Column<Guid>(type: "uuid", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    LimiteImoveis = table.Column<int>(type: "integer", nullable: true),
                    LimiteUsuarios = table.Column<int>(type: "integer", nullable: true),
                    Valor = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plano", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "uf",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertUser = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateUser = table.Column<Guid>(type: "uuid", nullable: true),
                    UFCode = table.Column<string>(type: "text", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    Regiao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_uf", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "permissao",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertUser = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateUser = table.Column<Guid>(type: "uuid", nullable: true),
                    NomePermissao = table.Column<string>(type: "text", nullable: true),
                    Descricao = table.Column<string>(type: "text", nullable: true),
                    ModuloId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissao", x => x.ID);
                    table.ForeignKey(
                        name: "FK_permissao_modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "modulo",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "plano_modulo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertUser = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateUser = table.Column<Guid>(type: "uuid", nullable: true),
                    PlanoId = table.Column<Guid>(type: "uuid", nullable: true),
                    ModuloId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plano_modulo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_plano_modulo_modulo_ModuloId",
                        column: x => x.ModuloId,
                        principalTable: "modulo",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_plano_modulo_plano_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "plano",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tenant",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    SchemaName = table.Column<string>(type: "text", nullable: true),
                    PlanoId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertUser = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateUser = table.Column<Guid>(type: "uuid", nullable: true),
                    DataPlano = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenant", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tenant_plano_PlanoId",
                        column: x => x.PlanoId,
                        principalTable: "plano",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "municipio",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertUser = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateUser = table.Column<Guid>(type: "uuid", nullable: true),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    UFId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipio", x => x.ID);
                    table.ForeignKey(
                        name: "FK_municipio_uf_UFId",
                        column: x => x.UFId,
                        principalTable: "uf",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tenant_log",
                columns: table => new
                {
                    TenantLogId = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: true),
                    SchemaName = table.Column<string>(type: "text", nullable: true),
                    PlanoId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertUser = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateUser = table.Column<Guid>(type: "uuid", nullable: true),
                    PlanoRenovacao = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenant_log", x => x.TenantLogId);
                    table.ForeignKey(
                        name: "FK_tenant_log_tenant_TenantId",
                        column: x => x.TenantId,
                        principalTable: "tenant",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "endereco",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertUser = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateUser = table.Column<Guid>(type: "uuid", nullable: true),
                    CEP = table.Column<int>(type: "integer", nullable: true),
                    Logradouro = table.Column<string>(type: "text", nullable: true),
                    Numero = table.Column<int>(type: "integer", nullable: true),
                    Complemento = table.Column<string>(type: "text", nullable: true),
                    Bairro = table.Column<string>(type: "text", nullable: true),
                    MunicipioId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_endereco", x => x.ID);
                    table.ForeignKey(
                        name: "FK_endereco_municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "municipio",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "empresa",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    InsertUser = table.Column<Guid>(type: "uuid", nullable: true),
                    UpdateUser = table.Column<Guid>(type: "uuid", nullable: true),
                    NomeFantasia = table.Column<string>(type: "text", nullable: true),
                    RazaoSocial = table.Column<string>(type: "text", nullable: true),
                    CNPJ = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    EnderecoId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresa", x => x.ID);
                    table.ForeignKey(
                        name: "FK_empresa_endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "endereco",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_empresa_EnderecoId",
                table: "empresa",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_endereco_MunicipioId",
                table: "endereco",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_municipio_UFId",
                table: "municipio",
                column: "UFId");

            migrationBuilder.CreateIndex(
                name: "IX_permissao_ModuloId",
                table: "permissao",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_plano_modulo_ModuloId",
                table: "plano_modulo",
                column: "ModuloId");

            migrationBuilder.CreateIndex(
                name: "IX_plano_modulo_PlanoId",
                table: "plano_modulo",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_tenant_PlanoId",
                table: "tenant",
                column: "PlanoId");

            migrationBuilder.CreateIndex(
                name: "IX_tenant_log_TenantId",
                table: "tenant_log",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "empresa");

            migrationBuilder.DropTable(
                name: "permissao");

            migrationBuilder.DropTable(
                name: "plano_modulo");

            migrationBuilder.DropTable(
                name: "tenant_log");

            migrationBuilder.DropTable(
                name: "endereco");

            migrationBuilder.DropTable(
                name: "modulo");

            migrationBuilder.DropTable(
                name: "tenant");

            migrationBuilder.DropTable(
                name: "municipio");

            migrationBuilder.DropTable(
                name: "plano");

            migrationBuilder.DropTable(
                name: "uf");
        }
    }
}
