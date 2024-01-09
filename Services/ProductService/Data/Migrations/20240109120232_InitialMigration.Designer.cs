﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductService.Data;

#nullable disable

namespace ProductService.Data.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20240109120232_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.InboxState", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("Consumed")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ConsumerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Delivered")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpirationTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastSequenceNumber")
                        .HasColumnType("bigint");

                    b.Property<Guid>("LockId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ReceiveCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Received")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("Id");

                    b.HasAlternateKey("MessageId", "ConsumerId");

                    b.HasIndex("Delivered");

                    b.ToTable("InboxState");
                });

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.OutboxMessage", b =>
                {
                    b.Property<long>("SequenceNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SequenceNumber"));

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<Guid?>("ConversationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CorrelationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DestinationAddress")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("EnqueueTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ExpirationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FaultAddress")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Headers")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("InboxConsumerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InboxMessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("InitiatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MessageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MessageType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("OutboxId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Properties")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ResponseAddress")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime>("SentTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SourceAddress")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("SequenceNumber");

                    b.HasIndex("EnqueueTime");

                    b.HasIndex("ExpirationTime");

                    b.HasIndex("OutboxId", "SequenceNumber")
                        .IsUnique()
                        .HasFilter("[OutboxId] IS NOT NULL");

                    b.HasIndex("InboxMessageId", "InboxConsumerId", "SequenceNumber")
                        .IsUnique()
                        .HasFilter("[InboxMessageId] IS NOT NULL AND [InboxConsumerId] IS NOT NULL");

                    b.ToTable("OutboxMessage");
                });

            modelBuilder.Entity("MassTransit.EntityFrameworkCoreIntegration.OutboxState", b =>
                {
                    b.Property<Guid>("OutboxId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Delivered")
                        .HasColumnType("datetime2");

                    b.Property<long?>("LastSequenceNumber")
                        .HasColumnType("bigint");

                    b.Property<Guid>("LockId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasKey("OutboxId");

                    b.HasIndex("Created");

                    b.ToTable("OutboxState");
                });

            modelBuilder.Entity("ProductService.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("StockStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("49908c30-d4ba-3be1-d9e8-b733a839a166"),
                            Brand = "Streich and Sons",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 565, DateTimeKind.Utc).AddTicks(6208),
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            ImageUrl = "http://lorempixel.com/640/480/cats",
                            Name = "Incredible Steel Sausages",
                            Price = 506.44378639454749,
                            StockStatus = 3,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 565, DateTimeKind.Utc).AddTicks(6212)
                        },
                        new
                        {
                            Id = new Guid("808c14b8-ee33-ca1e-7411-bdac85810db2"),
                            Brand = "Von and Sons",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(3739),
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            ImageUrl = "http://lorempixel.com/640/480/business",
                            Name = "Tasty Frozen Keyboard",
                            Price = 871.2517113339909,
                            StockStatus = 1,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(3742)
                        },
                        new
                        {
                            Id = new Guid("48aa0360-3e49-b8e2-8973-99be1aa73c14"),
                            Brand = "Hessel, Rau and Hilll",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(4397),
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            ImageUrl = "http://lorempixel.com/640/480/nature",
                            Name = "Sleek Plastic Cheese",
                            Price = 891.63562177394522,
                            StockStatus = 0,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(4398)
                        },
                        new
                        {
                            Id = new Guid("a23b558d-96ea-61b3-0d6d-e4415b63d982"),
                            Brand = "Herzog and Sons",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(4996),
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            ImageUrl = "http://lorempixel.com/640/480/business",
                            Name = "Gorgeous Plastic Fish",
                            Price = 235.2584831419081,
                            StockStatus = 2,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(4997)
                        },
                        new
                        {
                            Id = new Guid("0bd7c33a-89d0-46b9-98c0-d103d59afa6f"),
                            Brand = "Schimmel, Abshire and Cummerata",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(5393),
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            ImageUrl = "http://lorempixel.com/640/480/business",
                            Name = "Gorgeous Steel Pants",
                            Price = 474.01524076126532,
                            StockStatus = 3,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(5393)
                        },
                        new
                        {
                            Id = new Guid("1bb33c5e-7ebc-ff88-8bd7-d4f69ec82386"),
                            Brand = "Dare, Hagenes and Kohler",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(5855),
                            Description = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            ImageUrl = "http://lorempixel.com/640/480/cats",
                            Name = "Ergonomic Rubber Towels",
                            Price = 369.7513851833192,
                            StockStatus = 0,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(5855)
                        },
                        new
                        {
                            Id = new Guid("ca94c92a-bb33-0d0d-577c-c7a2213913a4"),
                            Brand = "Bradtke, Gottlieb and Smith",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(6304),
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            ImageUrl = "http://lorempixel.com/640/480/city",
                            Name = "Licensed Rubber Fish",
                            Price = 515.60199273242597,
                            StockStatus = 1,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(6304)
                        },
                        new
                        {
                            Id = new Guid("6ecd5f53-59cf-ddb8-be80-ed0249043a16"),
                            Brand = "Skiles Group",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(6758),
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            ImageUrl = "http://lorempixel.com/640/480/transport",
                            Name = "Small Plastic Chicken",
                            Price = 877.81204774593334,
                            StockStatus = 2,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(6759)
                        },
                        new
                        {
                            Id = new Guid("c6f00834-09c6-1805-d34c-87a987b2b126"),
                            Brand = "Satterfield, Howell and Emard",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(7061),
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            ImageUrl = "http://lorempixel.com/640/480/sports",
                            Name = "Ergonomic Wooden Pizza",
                            Price = 116.15207880839313,
                            StockStatus = 0,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(7062)
                        },
                        new
                        {
                            Id = new Guid("a72322cf-f945-b34c-a8d7-bf0af0f22a40"),
                            Brand = "Batz - Sanford",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(7479),
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            ImageUrl = "http://lorempixel.com/640/480/abstract",
                            Name = "Ergonomic Cotton Chair",
                            Price = 781.33137793892251,
                            StockStatus = 2,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(7479)
                        },
                        new
                        {
                            Id = new Guid("efd6fd5a-c5ee-b413-17c7-953414970834"),
                            Brand = "Mraz LLC",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(7921),
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            ImageUrl = "http://lorempixel.com/640/480/technics",
                            Name = "Unbranded Soft Chair",
                            Price = 697.35670163338989,
                            StockStatus = 0,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(7921)
                        },
                        new
                        {
                            Id = new Guid("d9b8c074-b2c7-c35e-dc65-53219abcbed3"),
                            Brand = "Cormier - Emmerich",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(8327),
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            ImageUrl = "http://lorempixel.com/640/480/abstract",
                            Name = "Intelligent Cotton Bacon",
                            Price = 856.0354462173226,
                            StockStatus = 3,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(8328)
                        },
                        new
                        {
                            Id = new Guid("6829d902-c105-5e54-ea1c-56a9801de45f"),
                            Brand = "Schmidt, Kihn and Bruen",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(8626),
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            ImageUrl = "http://lorempixel.com/640/480/nightlife",
                            Name = "Fantastic Wooden Cheese",
                            Price = 318.04978716526625,
                            StockStatus = 1,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(8627)
                        },
                        new
                        {
                            Id = new Guid("354b305a-77a5-572a-e519-f41f893f7587"),
                            Brand = "Smitham, Homenick and Fritsch",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(9052),
                            Description = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            ImageUrl = "http://lorempixel.com/640/480/food",
                            Name = "Handmade Soft Pants",
                            Price = 720.72006078517643,
                            StockStatus = 2,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(9052)
                        },
                        new
                        {
                            Id = new Guid("1db1009c-c92b-c41a-86ff-560757d73e81"),
                            Brand = "Oberbrunner LLC",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(9470),
                            Description = "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality",
                            ImageUrl = "http://lorempixel.com/640/480/nature",
                            Name = "Unbranded Fresh Table",
                            Price = 642.63583578763621,
                            StockStatus = 3,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(9471)
                        },
                        new
                        {
                            Id = new Guid("cc00b3fc-17ab-8cf1-e21d-46a4d1e478bd"),
                            Brand = "Boehm, Koelpin and Klein",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(9833),
                            Description = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            ImageUrl = "http://lorempixel.com/640/480/business",
                            Name = "Practical Concrete Shoes",
                            Price = 461.39848054644472,
                            StockStatus = 2,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 566, DateTimeKind.Utc).AddTicks(9834)
                        },
                        new
                        {
                            Id = new Guid("30674319-22a7-3df2-2765-0ab9b9401126"),
                            Brand = "Wilkinson - Borer",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 567, DateTimeKind.Utc).AddTicks(269),
                            Description = "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
                            ImageUrl = "http://lorempixel.com/640/480/fashion",
                            Name = "Intelligent Steel Bike",
                            Price = 653.98435570861216,
                            StockStatus = 3,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 567, DateTimeKind.Utc).AddTicks(270)
                        },
                        new
                        {
                            Id = new Guid("e4a81004-3bb2-75f8-5448-1de2c22749b3"),
                            Brand = "Schmitt LLC",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 567, DateTimeKind.Utc).AddTicks(552),
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            ImageUrl = "http://lorempixel.com/640/480/fashion",
                            Name = "Small Soft Hat",
                            Price = 480.92072380721453,
                            StockStatus = 3,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 567, DateTimeKind.Utc).AddTicks(552)
                        },
                        new
                        {
                            Id = new Guid("4a76383d-a4fa-7a40-0794-b996181dedd2"),
                            Brand = "Gulgowski Inc",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 567, DateTimeKind.Utc).AddTicks(920),
                            Description = "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles",
                            ImageUrl = "http://lorempixel.com/640/480/business",
                            Name = "Fantastic Plastic Chicken",
                            Price = 204.70623806099064,
                            StockStatus = 0,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 567, DateTimeKind.Utc).AddTicks(921)
                        },
                        new
                        {
                            Id = new Guid("41bdae41-5b4d-ad9d-127d-42c88629bc18"),
                            Brand = "Brakus - Barton",
                            CreatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 567, DateTimeKind.Utc).AddTicks(1258),
                            Description = "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                            ImageUrl = "http://lorempixel.com/640/480/food",
                            Name = "Generic Rubber Gloves",
                            Price = 748.50380769636138,
                            StockStatus = 3,
                            UpdatedAt = new DateTime(2024, 1, 9, 12, 2, 31, 567, DateTimeKind.Utc).AddTicks(1259)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
