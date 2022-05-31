﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimMovie.Infrastructure.Database.Migrations
{
    public partial class AddMessageEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CallersMessagesWithAuthorizedUsers");

            migrationBuilder.DropTable(
                name: "CallersMessagesWithUnauthorizedUsers");

            migrationBuilder.DropTable(
                name: "CurrentCommunicationsWithAuthorizedUsers");

            migrationBuilder.DropTable(
                name: "CurrentCommunicationsWithUnauthorizedUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "SupportId",
                table: "Messages",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ToUser",
                table: "Messages",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Messages",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_SupportId",
                table: "Messages",
                column: "SupportId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_SupportId",
                table: "Messages",
                column: "SupportId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_SupportId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_UserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_SupportId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_UserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "SupportId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ToUser",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Messages");

            migrationBuilder.CreateTable(
                name: "CallersMessagesWithAuthorizedUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FromUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    ToUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallersMessagesWithAuthorizedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallersMessagesWithAuthorizedUsers_AspNetUsers_FromUserId",
                        column: x => x.FromUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallersMessagesWithAuthorizedUsers_AspNetUsers_ToUserId",
                        column: x => x.ToUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallersMessagesWithAuthorizedUsers_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CallersMessagesWithUnauthorizedUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MessageId = table.Column<Guid>(type: "uuid", nullable: false),
                    SupportId = table.Column<Guid>(type: "uuid", nullable: false),
                    ToUser = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallersMessagesWithUnauthorizedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CallersMessagesWithUnauthorizedUsers_AspNetUsers_SupportId",
                        column: x => x.SupportId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallersMessagesWithUnauthorizedUsers_Messages_MessageId",
                        column: x => x.MessageId,
                        principalTable: "Messages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentCommunicationsWithAuthorizedUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SupportId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentCommunicationsWithAuthorizedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentCommunicationsWithAuthorizedUsers_AspNetUsers_Suppor~",
                        column: x => x.SupportId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CurrentCommunicationsWithAuthorizedUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentCommunicationsWithUnauthorizedUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SupportId = table.Column<Guid>(type: "uuid", nullable: false),
                    UserConnectId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentCommunicationsWithUnauthorizedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentCommunicationsWithUnauthorizedUsers_AspNetUsers_Supp~",
                        column: x => x.SupportId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CallersMessagesWithAuthorizedUsers_FromUserId",
                table: "CallersMessagesWithAuthorizedUsers",
                column: "FromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CallersMessagesWithAuthorizedUsers_MessageId",
                table: "CallersMessagesWithAuthorizedUsers",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_CallersMessagesWithAuthorizedUsers_ToUserId",
                table: "CallersMessagesWithAuthorizedUsers",
                column: "ToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CallersMessagesWithUnauthorizedUsers_MessageId",
                table: "CallersMessagesWithUnauthorizedUsers",
                column: "MessageId");

            migrationBuilder.CreateIndex(
                name: "IX_CallersMessagesWithUnauthorizedUsers_SupportId",
                table: "CallersMessagesWithUnauthorizedUsers",
                column: "SupportId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentCommunicationsWithAuthorizedUsers_SupportId",
                table: "CurrentCommunicationsWithAuthorizedUsers",
                column: "SupportId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentCommunicationsWithAuthorizedUsers_UserId",
                table: "CurrentCommunicationsWithAuthorizedUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentCommunicationsWithUnauthorizedUsers_SupportId",
                table: "CurrentCommunicationsWithUnauthorizedUsers",
                column: "SupportId");
        }
    }
}
