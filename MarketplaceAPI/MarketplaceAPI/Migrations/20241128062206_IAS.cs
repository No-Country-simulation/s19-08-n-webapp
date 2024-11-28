using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketplaceAPI.Migrations
{
    /// <inheritdoc />
    public partial class IAS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    idRole = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.idRole);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    linkedIn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    portfolio = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    image = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    idRole = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.idUser);
                    table.ForeignKey(
                        name: "FK_Users_Roles_idRole",
                        column: x => x.idRole,
                        principalTable: "Roles",
                        principalColumn: "idRole",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    idPublication = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    publicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    image = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    state = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.idPublication);
                    table.ForeignKey(
                        name: "FK_Publications_Users_idUser",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    idProject = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPublication = table.Column<int>(type: "int", nullable: false),
                    idUserRequester = table.Column<int>(type: "int", nullable: false),
                    nameProject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    stateProject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.idProject);
                    table.ForeignKey(
                        name: "FK_Projects_Publications_idPublication",
                        column: x => x.idPublication,
                        principalTable: "Publications",
                        principalColumn: "idPublication",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projects_Users_idUserRequester",
                        column: x => x.idUserRequester,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    idChat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idProject = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.idChat);
                    table.ForeignKey(
                        name: "FK_Chats_Projects_idProject",
                        column: x => x.idProject,
                        principalTable: "Projects",
                        principalColumn: "idProject",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chats_Users_idUser",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Evaluations",
                columns: table => new
                {
                    idEvaluation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idProject = table.Column<int>(type: "int", nullable: false),
                    idEvaluatorUser = table.Column<int>(type: "int", nullable: false),
                    idEvaluatedUser = table.Column<int>(type: "int", nullable: false),
                    nameEvaluated = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evaluations", x => x.idEvaluation);
                    table.ForeignKey(
                        name: "FK_Evaluations_Projects_idProject",
                        column: x => x.idProject,
                        principalTable: "Projects",
                        principalColumn: "idProject",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evaluations_Users_idEvaluatedUser",
                        column: x => x.idEvaluatedUser,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Evaluations_Users_idEvaluatorUser",
                        column: x => x.idEvaluatorUser,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    idNotification = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idProject = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    state = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    idUserCollaborator = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.idNotification);
                    table.ForeignKey(
                        name: "FK_Notifications_Projects_idProject",
                        column: x => x.idProject,
                        principalTable: "Projects",
                        principalColumn: "idProject",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_idUserCollaborator",
                        column: x => x.idUserCollaborator,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjectContributors",
                columns: table => new
                {
                    idProject = table.Column<int>(type: "int", nullable: false),
                    idUserContributor = table.Column<int>(type: "int", nullable: false),
                    nameContributor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    applicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectContributors", x => new { x.idProject, x.idUserContributor });
                    table.ForeignKey(
                        name: "FK_ProjectContributors_Projects_idProject",
                        column: x => x.idProject,
                        principalTable: "Projects",
                        principalColumn: "idProject",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectContributors_Users_idUserContributor",
                        column: x => x.idUserContributor,
                        principalTable: "Users",
                        principalColumn: "idUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    idMessage = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idChat = table.Column<int>(type: "int", nullable: false),
                    sender = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    message = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    dateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.idMessage);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_idChat",
                        column: x => x.idChat,
                        principalTable: "Chats",
                        principalColumn: "idChat",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_idProject",
                table: "Chats",
                column: "idProject");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_idUser",
                table: "Chats",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_idEvaluatedUser",
                table: "Evaluations",
                column: "idEvaluatedUser");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_idEvaluatorUser",
                table: "Evaluations",
                column: "idEvaluatorUser");

            migrationBuilder.CreateIndex(
                name: "IX_Evaluations_idProject",
                table: "Evaluations",
                column: "idProject");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_idChat",
                table: "Messages",
                column: "idChat");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_idProject",
                table: "Notifications",
                column: "idProject");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_idUserCollaborator",
                table: "Notifications",
                column: "idUserCollaborator");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectContributors_idUserContributor",
                table: "ProjectContributors",
                column: "idUserContributor");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_idPublication",
                table: "Projects",
                column: "idPublication");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_idUserRequester",
                table: "Projects",
                column: "idUserRequester");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_idUser",
                table: "Publications",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_idRole",
                table: "Users",
                column: "idRole");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Evaluations");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ProjectContributors");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
