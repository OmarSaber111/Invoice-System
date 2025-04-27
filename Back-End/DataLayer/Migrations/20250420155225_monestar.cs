using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class monestar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupRoleAuth_Forms_FormId",
                table: "GroupRoleAuth");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupRoleAuth_Groups_GroupId1",
                table: "GroupRoleAuth");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupRoleAuth_RequestRoleForms_RequestRoleFormId",
                table: "GroupRoleAuth");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupRoleAuth_RequestRoleForms_RequestRoleFormId1",
                table: "GroupRoleAuth");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupRoleAuth_Requests_RequestId",
                table: "GroupRoleAuth");

            migrationBuilder.DropForeignKey(
                name: "FK_GroupRoleAuth_Roles_RoleId",
                table: "GroupRoleAuth");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestRoleForms_Forms_FormId",
                table: "RequestRoleForms");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestRoleForms_Forms_FormId1",
                table: "RequestRoleForms");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestRoleForms_Requests_RequestId",
                table: "RequestRoleForms");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestRoleForms_Requests_RequestId1",
                table: "RequestRoleForms");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestRoleForms_Roles_RoleId",
                table: "RequestRoleForms");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestRoleForms_Roles_RoleId1",
                table: "RequestRoleForms");

            migrationBuilder.DropIndex(
                name: "IX_GroupRoleAuth_FormId",
                table: "GroupRoleAuth");

            migrationBuilder.DropIndex(
                name: "IX_GroupRoleAuth_GroupId1",
                table: "GroupRoleAuth");

            migrationBuilder.DropIndex(
                name: "IX_GroupRoleAuth_RequestId",
                table: "GroupRoleAuth");

            migrationBuilder.DropIndex(
                name: "IX_GroupRoleAuth_RequestRoleFormId1",
                table: "GroupRoleAuth");

            migrationBuilder.DropIndex(
                name: "IX_GroupRoleAuth_RoleId",
                table: "GroupRoleAuth");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestRoleForms",
                table: "RequestRoleForms");

            migrationBuilder.DropIndex(
                name: "IX_RequestRoleForms_FormId1",
                table: "RequestRoleForms");

            migrationBuilder.DropIndex(
                name: "IX_RequestRoleForms_RequestId1",
                table: "RequestRoleForms");

            migrationBuilder.DropIndex(
                name: "IX_RequestRoleForms_RoleId1",
                table: "RequestRoleForms");

            migrationBuilder.DropColumn(
                name: "FormId",
                table: "GroupRoleAuth");

            migrationBuilder.DropColumn(
                name: "GroupId1",
                table: "GroupRoleAuth");

            migrationBuilder.DropColumn(
                name: "RequestId",
                table: "GroupRoleAuth");

            migrationBuilder.DropColumn(
                name: "RequestRoleFormId1",
                table: "GroupRoleAuth");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "GroupRoleAuth");

            migrationBuilder.DropColumn(
                name: "FormId1",
                table: "RequestRoleForms");

            migrationBuilder.DropColumn(
                name: "RequestId1",
                table: "RequestRoleForms");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "RequestRoleForms");

            migrationBuilder.RenameTable(
                name: "RequestRoleForms",
                newName: "RequestRoleForm");

            migrationBuilder.RenameIndex(
                name: "IX_RequestRoleForms_RoleId",
                table: "RequestRoleForm",
                newName: "IX_RequestRoleForm_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestRoleForms_RequestId",
                table: "RequestRoleForm",
                newName: "IX_RequestRoleForm_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestRoleForms_FormId",
                table: "RequestRoleForm",
                newName: "IX_RequestRoleForm_FormId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "GroupRoleAuth",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestRoleForm",
                table: "RequestRoleForm",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupRoleAuth_RequestRoleForm_RequestRoleFormId",
                table: "GroupRoleAuth",
                column: "RequestRoleFormId",
                principalTable: "RequestRoleForm",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestRoleForm_Forms_FormId",
                table: "RequestRoleForm",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "form_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestRoleForm_Requests_RequestId",
                table: "RequestRoleForm",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "request_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestRoleForm_Roles_RoleId",
                table: "RequestRoleForm",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "role_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupRoleAuth_RequestRoleForm_RequestRoleFormId",
                table: "GroupRoleAuth");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestRoleForm_Forms_FormId",
                table: "RequestRoleForm");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestRoleForm_Requests_RequestId",
                table: "RequestRoleForm");

            migrationBuilder.DropForeignKey(
                name: "FK_RequestRoleForm_Roles_RoleId",
                table: "RequestRoleForm");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RequestRoleForm",
                table: "RequestRoleForm");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "RequestRoleForm",
                newName: "RequestRoleForms");

            migrationBuilder.RenameIndex(
                name: "IX_RequestRoleForm_RoleId",
                table: "RequestRoleForms",
                newName: "IX_RequestRoleForms_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestRoleForm_RequestId",
                table: "RequestRoleForms",
                newName: "IX_RequestRoleForms_RequestId");

            migrationBuilder.RenameIndex(
                name: "IX_RequestRoleForm_FormId",
                table: "RequestRoleForms",
                newName: "IX_RequestRoleForms_FormId");

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "GroupRoleAuth",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "FormId",
                table: "GroupRoleAuth",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId1",
                table: "GroupRoleAuth",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId",
                table: "GroupRoleAuth",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestRoleFormId1",
                table: "GroupRoleAuth",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "GroupRoleAuth",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FormId1",
                table: "RequestRoleForms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId1",
                table: "RequestRoleForms",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId1",
                table: "RequestRoleForms",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RequestRoleForms",
                table: "RequestRoleForms",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRoleAuth_FormId",
                table: "GroupRoleAuth",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRoleAuth_GroupId1",
                table: "GroupRoleAuth",
                column: "GroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRoleAuth_RequestId",
                table: "GroupRoleAuth",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRoleAuth_RequestRoleFormId1",
                table: "GroupRoleAuth",
                column: "RequestRoleFormId1");

            migrationBuilder.CreateIndex(
                name: "IX_GroupRoleAuth_RoleId",
                table: "GroupRoleAuth",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestRoleForms_FormId1",
                table: "RequestRoleForms",
                column: "FormId1");

            migrationBuilder.CreateIndex(
                name: "IX_RequestRoleForms_RequestId1",
                table: "RequestRoleForms",
                column: "RequestId1");

            migrationBuilder.CreateIndex(
                name: "IX_RequestRoleForms_RoleId1",
                table: "RequestRoleForms",
                column: "RoleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupRoleAuth_Forms_FormId",
                table: "GroupRoleAuth",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "form_id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupRoleAuth_Groups_GroupId1",
                table: "GroupRoleAuth",
                column: "GroupId1",
                principalTable: "Groups",
                principalColumn: "group_id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupRoleAuth_RequestRoleForms_RequestRoleFormId",
                table: "GroupRoleAuth",
                column: "RequestRoleFormId",
                principalTable: "RequestRoleForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GroupRoleAuth_RequestRoleForms_RequestRoleFormId1",
                table: "GroupRoleAuth",
                column: "RequestRoleFormId1",
                principalTable: "RequestRoleForms",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupRoleAuth_Requests_RequestId",
                table: "GroupRoleAuth",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "request_id");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupRoleAuth_Roles_RoleId",
                table: "GroupRoleAuth",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "role_id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestRoleForms_Forms_FormId",
                table: "RequestRoleForms",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "form_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestRoleForms_Forms_FormId1",
                table: "RequestRoleForms",
                column: "FormId1",
                principalTable: "Forms",
                principalColumn: "form_id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestRoleForms_Requests_RequestId",
                table: "RequestRoleForms",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "request_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestRoleForms_Requests_RequestId1",
                table: "RequestRoleForms",
                column: "RequestId1",
                principalTable: "Requests",
                principalColumn: "request_id");

            migrationBuilder.AddForeignKey(
                name: "FK_RequestRoleForms_Roles_RoleId",
                table: "RequestRoleForms",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "role_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RequestRoleForms_Roles_RoleId1",
                table: "RequestRoleForms",
                column: "RoleId1",
                principalTable: "Roles",
                principalColumn: "role_id");
        }
    }
}
