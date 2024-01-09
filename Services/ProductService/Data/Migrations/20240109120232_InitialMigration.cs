using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductService.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InboxState",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsumerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Received = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceiveCount = table.Column<int>(type: "int", nullable: false),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Consumed = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Delivered = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastSequenceNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboxState", x => x.Id);
                    table.UniqueConstraint("AK_InboxState_MessageId_ConsumerId", x => new { x.MessageId, x.ConsumerId });
                });

            migrationBuilder.CreateTable(
                name: "OutboxMessage",
                columns: table => new
                {
                    SequenceNumber = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnqueueTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Headers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Properties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InboxMessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InboxConsumerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OutboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MessageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    MessageType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConversationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CorrelationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InitiatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SourceAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    DestinationAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ResponseAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FaultAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ExpirationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxMessage", x => x.SequenceNumber);
                });

            migrationBuilder.CreateTable(
                name: "OutboxState",
                columns: table => new
                {
                    OutboxId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Delivered = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastSequenceNumber = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboxState", x => x.OutboxId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StockStatus = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "CreatedAt", "Description", "ImageUrl", "Name", "Price", "StockStatus", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0bd7c33a-89d0-46b9-98c0-d103d59afa6f"), "Schimmel, Abshire and Cummerata", new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(5393), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "http://lorempixel.com/640/480/business", "Gorgeous Steel Pants", 474.01524076126532, 3, new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(5393) },
                    { new Guid("1bb33c5e-7ebc-ff88-8bd7-d4f69ec82386"), "Dare, Hagenes and Kohler", new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(5855), "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", "http://lorempixel.com/640/480/cats", "Ergonomic Rubber Towels", 369.7513851833192, 0, new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(5855) },
                    { new Guid("1db1009c-c92b-c41a-86ff-560757d73e81"), "Oberbrunner LLC", new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(9470), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "http://lorempixel.com/640/480/nature", "Unbranded Fresh Table", 642.63583578763621, 3, new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(9471) },
                    { new Guid("30674319-22a7-3df2-2765-0ab9b9401126"), "Wilkinson - Borer", new DateTime(2024, 1, 9, 12, 2, 31, 567, DateTimeKind.Utc).AddTicks(269), "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", "http://lorempixel.com/640/480/fashion", "Intelligent Steel Bike", 653.98435570861216, 3, new DateTime(2024, 1, 9, 12, 2, 31, 567, DateTimeKind.Utc).AddTicks(270) },
                    { new Guid("354b305a-77a5-572a-e519-f41f893f7587"), "Smitham, Homenick and Fritsch", new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(9052), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "http://lorempixel.com/640/480/food", "Handmade Soft Pants", 720.72006078517643, 2, new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(9052) },
                    { new Guid("41bdae41-5b4d-ad9d-127d-42c88629bc18"), "Brakus - Barton", new DateTime(2024, 1, 9, 12, 2, 31, 567, DateTimeKind.Utc).AddTicks(1258), "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", "http://lorempixel.com/640/480/food", "Generic Rubber Gloves", 748.50380769636138, 3, new DateTime(2024, 1, 9, 12, 2, 31, 567, DateTimeKind.Utc).AddTicks(1259) },
                    { new Guid("48aa0360-3e49-b8e2-8973-99be1aa73c14"), "Hessel, Rau and Hilll", new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(4397), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "http://lorempixel.com/640/480/nature", "Sleek Plastic Cheese", 891.63562177394522, 0, new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(4398) },
                    { new Guid("49908c30-d4ba-3be1-d9e8-b733a839a166"), "Streich and Sons", new DateTime(2024, 1, 9, 12, 2, 31, 565, DateTimeKind.Utc).AddTicks(6208), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "http://lorempixel.com/640/480/cats", "Incredible Steel Sausages", 506.44378639454749, 3, new DateTime(2024, 1, 9, 12, 2, 31, 565, DateTimeKind.Utc).AddTicks(6212) },
                    { new Guid("4a76383d-a4fa-7a40-0794-b996181dedd2"), "Gulgowski Inc", new DateTime(2024, 1, 9, 12, 2, 31, 567, DateTimeKind.Utc).AddTicks(920), "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", "http://lorempixel.com/640/480/business", "Fantastic Plastic Chicken", 204.70623806099064, 0, new DateTime(2024, 1, 9, 12, 2, 31, 567, DateTimeKind.Utc).AddTicks(921) },
                    { new Guid("6829d902-c105-5e54-ea1c-56a9801de45f"), "Schmidt, Kihn and Bruen", new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(8626), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "http://lorempixel.com/640/480/nightlife", "Fantastic Wooden Cheese", 318.04978716526625, 1, new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(8627) },
                    { new Guid("6ecd5f53-59cf-ddb8-be80-ed0249043a16"), "Skiles Group", new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(6758), "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", "http://lorempixel.com/640/480/transport", "Small Plastic Chicken", 877.81204774593334, 2, new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(6759) },
                    { new Guid("808c14b8-ee33-ca1e-7411-bdac85810db2"), "Von and Sons", new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(3739), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "http://lorempixel.com/640/480/business", "Tasty Frozen Keyboard", 871.2517113339909, 1, new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(3742) },
                    { new Guid("a23b558d-96ea-61b3-0d6d-e4415b63d982"), "Herzog and Sons", new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(4996), "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", "http://lorempixel.com/640/480/business", "Gorgeous Plastic Fish", 235.2584831419081, 2, new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(4997) },
                    { new Guid("a72322cf-f945-b34c-a8d7-bf0af0f22a40"), "Batz - Sanford", new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(7479), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "http://lorempixel.com/640/480/abstract", "Ergonomic Cotton Chair", 781.33137793892251, 2, new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(7479) },
                    { new Guid("c6f00834-09c6-1805-d34c-87a987b2b126"), "Satterfield, Howell and Emard", new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(7061), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "http://lorempixel.com/640/480/sports", "Ergonomic Wooden Pizza", 116.15207880839313, 0, new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(7062) },
                    { new Guid("ca94c92a-bb33-0d0d-577c-c7a2213913a4"), "Bradtke, Gottlieb and Smith", new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(6304), "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", "http://lorempixel.com/640/480/city", "Licensed Rubber Fish", 515.60199273242597, 1, new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(6304) },
                    { new Guid("cc00b3fc-17ab-8cf1-e21d-46a4d1e478bd"), "Boehm, Koelpin and Klein", new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(9833), "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", "http://lorempixel.com/640/480/business", "Practical Concrete Shoes", 461.39848054644472, 2, new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(9834) },
                    { new Guid("d9b8c074-b2c7-c35e-dc65-53219abcbed3"), "Cormier - Emmerich", new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(8327), "The Football Is Good For Training And Recreational Purposes", "http://lorempixel.com/640/480/abstract", "Intelligent Cotton Bacon", 856.0354462173226, 3, new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(8328) },
                    { new Guid("e4a81004-3bb2-75f8-5448-1de2c22749b3"), "Schmitt LLC", new DateTime(2024, 1, 9, 12, 2, 31, 567, DateTimeKind.Utc).AddTicks(552), "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", "http://lorempixel.com/640/480/fashion", "Small Soft Hat", 480.92072380721453, 3, new DateTime(2024, 1, 9, 12, 2, 31, 567, DateTimeKind.Utc).AddTicks(552) },
                    { new Guid("efd6fd5a-c5ee-b413-17c7-953414970834"), "Mraz LLC", new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(7921), "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", "http://lorempixel.com/640/480/technics", "Unbranded Soft Chair", 697.35670163338989, 0, new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(7921) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InboxState_Delivered",
                table: "InboxState",
                column: "Delivered");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_EnqueueTime",
                table: "OutboxMessage",
                column: "EnqueueTime");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_ExpirationTime",
                table: "OutboxMessage",
                column: "ExpirationTime");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_InboxMessageId_InboxConsumerId_SequenceNumber",
                table: "OutboxMessage",
                columns: new[] { "InboxMessageId", "InboxConsumerId", "SequenceNumber" },
                unique: true,
                filter: "[InboxMessageId] IS NOT NULL AND [InboxConsumerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxMessage_OutboxId_SequenceNumber",
                table: "OutboxMessage",
                columns: new[] { "OutboxId", "SequenceNumber" },
                unique: true,
                filter: "[OutboxId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OutboxState_Created",
                table: "OutboxState",
                column: "Created");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InboxState");

            migrationBuilder.DropTable(
                name: "OutboxMessage");

            migrationBuilder.DropTable(
                name: "OutboxState");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
