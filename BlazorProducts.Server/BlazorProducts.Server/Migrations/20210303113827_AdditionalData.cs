using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlazorProducts.Server.Migrations
{
    public partial class AdditionalData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "QA",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Declaration",
                columns: new[] { "Id", "CustomerRights", "Model", "Origin", "ProductId" },
                values: new object[] { new Guid("13feebbc-ab65-4e37-aa39-fcc2ed5e5015"), "All customer rights guaranteed under consumer protection law.", "Case & Skin for Samsung Galaxy G324 149 x 70.4 x 7.8 mm", "USA", new Guid("4e693871-788d-4db4-89e5-dd7678db975e") });

            migrationBuilder.InsertData(
                table: "QA",
                columns: new[] { "Id", "Answer", "ProductId", "Question", "User" },
                values: new object[,]
                {
                    { new Guid("94402f9d-f280-4a7d-9c95-13e430065cee"), "Hello Mick. Yes, there is a two year guarantee for it.", new Guid("4e693871-788d-4db4-89e5-dd7678db975e"), "Is there a guarantee for this product", "Mick Simons" },
                    { new Guid("06579037-943b-4ce5-8dd6-39f34ad49329"), "Hello Brigit. You can order it online on our web shop.", new Guid("4e693871-788d-4db4-89e5-dd7678db975e"), "How can I get this product", "Brigit Fansey" }
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "Comment", "ProductId", "Rate", "User" },
                values: new object[,]
                {
                    { new Guid("b4031733-83a6-4d7c-b995-a3a0c0a35c39"), "Great product. Fits my phone perfectly.", new Guid("4e693871-788d-4db4-89e5-dd7678db975e"), 5, "Tim Malock" },
                    { new Guid("f43017fd-1a65-4ad1-8610-ec4154a21c87"), "I use it all the time. Excellent stuff.", new Guid("4e693871-788d-4db4-89e5-dd7678db975e"), 4, "Ana Swan" },
                    { new Guid("b88bc5c2-660d-4604-ba92-69abf546e881"), "It could be better, I am not that satisfied.", new Guid("4e693871-788d-4db4-89e5-dd7678db975e"), 3, "John Mining" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Declaration",
                keyColumn: "Id",
                keyValue: new Guid("13feebbc-ab65-4e37-aa39-fcc2ed5e5015"));

            migrationBuilder.DeleteData(
                table: "QA",
                keyColumn: "Id",
                keyValue: new Guid("06579037-943b-4ce5-8dd6-39f34ad49329"));

            migrationBuilder.DeleteData(
                table: "QA",
                keyColumn: "Id",
                keyValue: new Guid("94402f9d-f280-4a7d-9c95-13e430065cee"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("b4031733-83a6-4d7c-b995-a3a0c0a35c39"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("b88bc5c2-660d-4604-ba92-69abf546e881"));

            migrationBuilder.DeleteData(
                table: "Review",
                keyColumn: "Id",
                keyValue: new Guid("f43017fd-1a65-4ad1-8610-ec4154a21c87"));

            migrationBuilder.DropColumn(
                name: "User",
                table: "QA");
        }
    }
}
