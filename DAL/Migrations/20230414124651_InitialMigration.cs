using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserProduct",
                columns: table => new
                {
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserProduct", x => new { x.ProductsId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserProduct_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserProduct_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPromotion",
                columns: table => new
                {
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromotionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPromotion", x => new { x.ProductsId, x.PromotionsId });
                    table.ForeignKey(
                        name: "FK_ProductPromotion_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPromotion_Promotions_PromotionsId",
                        column: x => x.PromotionsId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductPromotions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromotionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPromotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPromotions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductPromotions_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProducts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1a7fed9f-63a6-4f1c-96a0-73e0de797887"), "Meat and Poultry", "Meat and Poultry" },
                    { new Guid("1d0e49b1-7f90-4c55-b689-6654a7177476"), "Bakery", "Bakery" },
                    { new Guid("49e70c8c-902b-4f23-8dc6-fdaba3d3fded"), "Dairy", "Dairy" },
                    { new Guid("941d1dbf-3da0-4fb0-bba9-abbdc9d836b7"), "Seafood", "Seafood" },
                    { new Guid("990638f8-f1e5-49dd-b73d-86b24eefcf9f"), "Beverage", "Beverage" },
                    { new Guid("b6aa08b8-a381-4c52-98d7-f7a18b2f839c"), "Dental", "Dental" },
                    { new Guid("bc9f2bec-70d8-4655-899e-da988b29697f"), "Fruit", "Fruit" },
                    { new Guid("d64ac173-84b5-4ab2-b7e1-93e06e9f3a31"), "Snack", "Snack" },
                    { new Guid("ead27726-c61f-405b-9415-45592a9aaaad"), "Personal Care", "Personal Care" }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "Id", "Discount", "End", "Start" },
                values: new object[,]
                {
                    { new Guid("2cf96105-34d3-4808-931c-18e2f400d267"), 25.0, new DateTime(2023, 4, 20, 0, 46, 51, 238, DateTimeKind.Local).AddTicks(1882), new DateTime(2023, 4, 15, 0, 46, 51, 238, DateTimeKind.Local).AddTicks(1878) },
                    { new Guid("42b5df48-713e-400c-ba4a-6865db344cb0"), 12.0, new DateTime(2023, 4, 17, 0, 46, 51, 238, DateTimeKind.Local).AddTicks(1860), new DateTime(2023, 4, 15, 0, 46, 51, 238, DateTimeKind.Local).AddTicks(1768) },
                    { new Guid("9f0d4385-03f1-4cd9-91f9-b198caa90d84"), 50.0, new DateTime(2023, 4, 30, 0, 46, 51, 238, DateTimeKind.Local).AddTicks(1892), new DateTime(2023, 4, 15, 0, 46, 51, 238, DateTimeKind.Local).AddTicks(1888) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageURL", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("19b0449d-58d5-4ee1-96d5-ab5f22e3d3c5"), new Guid("ead27726-c61f-405b-9415-45592a9aaaad"), "Conditioner", "https://assets.woolworths.com.au/images/2010/486564.jpg?impolicy=wowcdxwbjbx&w=900&h=900", "Conditioner", 5.29 },
                    { new Guid("3008f59b-9926-4476-a27f-a16294044bc4"), new Guid("ead27726-c61f-405b-9415-45592a9aaaad"), "Deodorant", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQfd1I1jKbThIGhMOYOUyMqxdFiXopcdNeMgw&usqp=CAU", "Deodorant", 6.4900000000000002 },
                    { new Guid("3505780f-4511-42c4-b7a1-18809a0bb14a"), new Guid("bc9f2bec-70d8-4655-899e-da988b29697f"), "Pear", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQbOprtVHqqGoOtlUpVmtfSkcz3pQNeucvmnQ&usqp=CAU", "Pear", 5.6900000000000004 },
                    { new Guid("6841cf9c-35b3-40d4-bb09-6da813d29a0b"), new Guid("bc9f2bec-70d8-4655-899e-da988b29697f"), "Orange", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTAMzbzLWOy4yprdYfG_LC6H7NtD3AbAv3UWw&usqp=CAU", "Orange", 9.4900000000000002 },
                    { new Guid("730d9530-9913-40f1-a7b2-2a96ba7d9940"), new Guid("bc9f2bec-70d8-4655-899e-da988b29697f"), "Peach", "https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/71TIMGiDE9L._AC_SL1200_.jpg", "Peach", 10.789999999999999 },
                    { new Guid("7afa6882-7f50-4ef7-8198-18c0faf20c47"), new Guid("941d1dbf-3da0-4fb0-bba9-abbdc9d836b7"), "Shrimp", "https://www.dhhenderson.co.nz/wp-content/uploads/2020/04/381.png", "Shrimp", 21.989999999999998 },
                    { new Guid("838b6c72-adee-450e-87f5-56df8e86994d"), new Guid("990638f8-f1e5-49dd-b73d-86b24eefcf9f"), "Monster Energy Drink", "https://assets.woolworths.com.au/images/2010/329812.jpg?impolicy=wowcdxwbjbx&w=900&h=900", "Monster Energy Drink", 3.9900000000000002 },
                    { new Guid("84415975-4a18-4762-9e3b-8cc7e6c7e7b1"), new Guid("bc9f2bec-70d8-4655-899e-da988b29697f"), "Banana", "https://www.supermarketperimeter.com/ext/resources/bananas-sp.jpg?height=667&t=1550787674&width=1080", "Banana", 6.9900000000000002 },
                    { new Guid("8ce0fd1e-e29f-4039-a44e-66dbbe1a6d4f"), new Guid("bc9f2bec-70d8-4655-899e-da988b29697f"), "Avocado", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQHxBWZ-d1QmXgXd14ot7ySXecYecJOEUhgiQ&usqp=CAU", "Avocado", 6.9900000000000002 },
                    { new Guid("907624f9-07dc-4164-936c-88efc0454b37"), new Guid("bc9f2bec-70d8-4655-899e-da988b29697f"), "Lemon", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQbjqwOLzK0kH4i9Xyy75OV21ShL8VWRqDHtA&usqp=CAU", "Lemon", 16.989999999999998 },
                    { new Guid("9b84906f-4ec9-42a2-8269-22daaaca56c7"), new Guid("49e70c8c-902b-4f23-8dc6-fdaba3d3fded"), "Almond Milk", "https://assets.woolworths.com.au/images/2010/901450.jpg?impolicy=wowcdxwbjbx&w=900&h=900", "Almond Milk", 6.9900000000000002 },
                    { new Guid("9dbdaaff-ca16-4405-af5c-30f842d48e27"), new Guid("ead27726-c61f-405b-9415-45592a9aaaad"), "Soap", "https://www.tastenature.co.nz/wp-content/uploads/2021/10/Farmers-Pumice-Soap-2x100g-900-1.jpg", "Soap", 2.4900000000000002 },
                    { new Guid("b9ea3a02-6e5a-4f43-b2e8-c5a9a5895416"), new Guid("1d0e49b1-7f90-4c55-b689-6654a7177476"), "Banana Bread", "https://loshusansupermarket.com/product_images/d/597/KISS_BANANA_BREAD_72G_tagged__00890_zoom.jpg", "Banana Bread", 5.4900000000000002 },
                    { new Guid("bb4b35a1-d7b4-4196-b85a-afa478a086d5"), new Guid("d64ac173-84b5-4ab2-b7e1-93e06e9f3a31"), "Doritos", "https://www.doritos.com/sites/doritos.com/files/2018-08/new-nacho-cheese.png", "Doritos", 3.4900000000000002 },
                    { new Guid("d3ed8dd4-61d3-45df-8f5b-656da8e66b49"), new Guid("ead27726-c61f-405b-9415-45592a9aaaad"), "Shampoo", "https://www.beautyheaven.com.au/wp-content/uploads/2021/11/10-2.png", "Shampoo", 3.4900000000000002 },
                    { new Guid("efb8cc35-0e2e-4f64-91e8-2e1fe19fb7a0"), new Guid("bc9f2bec-70d8-4655-899e-da988b29697f"), "JackFruit", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTONI8-aZErJ6p5lTZpU4_TpENpjhjUmFzLrg&usqp=CAU", "JackFruit", 7.4900000000000002 },
                    { new Guid("fb8e13c5-e4e5-4565-b56e-c2a1ab880324"), new Guid("bc9f2bec-70d8-4655-899e-da988b29697f"), "Apple", "https://www.dhhenderson.co.nz/wp-content/uploads/2020/04/1381781721.jpg", "Apple", 7.8899999999999997 },
                    { new Guid("fc41ff1d-e663-4cd9-83ce-18be3db3121e"), new Guid("1a7fed9f-63a6-4f1c-96a0-73e0de797887"), "Minced Meat", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR-FYbNOJNwTrorlSQ6Q8r3qhrIzlW-PAPHrg&usqp=CAU", "Minced Meat", 17.75 },
                    { new Guid("fd21993c-9137-4065-a67b-a44b5fc86466"), new Guid("b6aa08b8-a381-4c52-98d7-f7a18b2f839c"), "Tooth Brush", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTpAnFUVxkzfJcP3mQO8_TTwJ65Qnw82dMUOg&usqp=CAU", "Tooth Brush", 8.9900000000000002 }
                });

            migrationBuilder.InsertData(
                table: "ProductPromotions",
                columns: new[] { "Id", "ProductId", "PromotionId" },
                values: new object[,]
                {
                    { new Guid("778db360-3aec-4a56-8832-44a12dc08ca3"), new Guid("838b6c72-adee-450e-87f5-56df8e86994d"), new Guid("42b5df48-713e-400c-ba4a-6865db344cb0") },
                    { new Guid("a805c322-8736-44ce-a1ba-e59dd553b57a"), new Guid("fd21993c-9137-4065-a67b-a44b5fc86466"), new Guid("9f0d4385-03f1-4cd9-91f9-b198caa90d84") },
                    { new Guid("e558441f-e774-448d-9781-66780851a370"), new Guid("fc41ff1d-e663-4cd9-83ce-18be3db3121e"), new Guid("2cf96105-34d3-4808-931c-18e2f400d267") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserProduct_UsersId",
                table: "ApplicationUserProduct",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromotion_PromotionsId",
                table: "ProductPromotion",
                column: "PromotionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromotions_ProductId",
                table: "ProductPromotions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromotions_PromotionId",
                table: "ProductPromotions",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_ProductId",
                table: "UserProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProducts_UserId",
                table: "UserProducts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserProduct");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ProductPromotion");

            migrationBuilder.DropTable(
                name: "ProductPromotions");

            migrationBuilder.DropTable(
                name: "UserProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
