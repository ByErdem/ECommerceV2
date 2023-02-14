using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceV2.Data.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tbl_StockFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ext = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Path = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    FileType = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_StockFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_UserFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Ext = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Keywords = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FileType = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_UserFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CitizenshipId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Authority = table.Column<int>(type: "int", nullable: false),
                    UserPicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blocked = table.Column<bool>(type: "bit", nullable: false),
                    UserFileId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Tbl_UserFiles_UserFileId",
                        column: x => x.UserFileId,
                        principalTable: "Tbl_UserFiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_ReceivedMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MUserId = table.Column<int>(type: "int", nullable: true),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_ReceivedMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_ReceivedMessages_Users_MUserId",
                        column: x => x.MUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tbl_ReceivedMessages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_SentMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MUserId = table.Column<int>(type: "int", nullable: true),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_SentMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_SentMessages_Users_MUserId",
                        column: x => x.MUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tbl_SentMessages_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BuyingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Keywords = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Stocks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Wishes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DiscountRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MUserId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Wishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Wishes_Users_MUserId",
                        column: x => x.MUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tbl_Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Unit = table.Column<int>(type: "int", maxLength: 20, nullable: false),
                    BuyingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AppliedDiscount = table.Column<bool>(type: "bit", nullable: false),
                    DiscountRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ActionType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_Actions_Tbl_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Tbl_Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_Actions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tbl_CommissionRates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tbl_CommissionRates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tbl_CommissionRates_Tbl_Actions_StockId",
                        column: x => x.StockId,
                        principalTable: "Tbl_Actions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tbl_CommissionRates_Tbl_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Tbl_Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Actions_StockId",
                table: "Tbl_Actions",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Actions_UserId",
                table: "Tbl_Actions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_CommissionRates_StockId",
                table: "Tbl_CommissionRates",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ReceivedMessages_MUserId",
                table: "Tbl_ReceivedMessages",
                column: "MUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_ReceivedMessages_SenderId",
                table: "Tbl_ReceivedMessages",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SentMessages_MUserId",
                table: "Tbl_SentMessages",
                column: "MUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_SentMessages_ReceiverId",
                table: "Tbl_SentMessages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Stocks_UserId",
                table: "Tbl_Stocks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tbl_Wishes_MUserId",
                table: "Tbl_Wishes",
                column: "MUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserFileId",
                table: "Users",
                column: "UserFileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tbl_CommissionRates");

            migrationBuilder.DropTable(
                name: "Tbl_ReceivedMessages");

            migrationBuilder.DropTable(
                name: "Tbl_SentMessages");

            migrationBuilder.DropTable(
                name: "Tbl_StockFiles");

            migrationBuilder.DropTable(
                name: "Tbl_Wishes");

            migrationBuilder.DropTable(
                name: "Tbl_Actions");

            migrationBuilder.DropTable(
                name: "Tbl_Stocks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tbl_UserFiles");
        }
    }
}
