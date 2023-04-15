using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Seed default Data to Category Table
            builder.Entity<Category>().HasData(
                new { Id = Guid.Parse("1d0e49b1-7f90-4c55-b689-6654a7177476"), Name = "Bakery", Description = "Bakery" },
                new { Id = Guid.Parse("990638f8-f1e5-49dd-b73d-86b24eefcf9f"), Name = "Beverage", Description = "Beverage" },
                new { Id = Guid.Parse("ead27726-c61f-405b-9415-45592a9aaaad"), Name = "Personal Care", Description = "Personal Care" },
                new { Id = Guid.Parse("b6aa08b8-a381-4c52-98d7-f7a18b2f839c"), Name = "Dental", Description = "Dental" },
                new { Id = Guid.Parse("1a7fed9f-63a6-4f1c-96a0-73e0de797887"), Name = "Meat and Poultry", Description = "Meat and Poultry" },
                new { Id = Guid.Parse("941d1dbf-3da0-4fb0-bba9-abbdc9d836b7"), Name = "Seafood", Description = "Seafood" },
                new { Id = Guid.Parse("49e70c8c-902b-4f23-8dc6-fdaba3d3fded"), Name = "Dairy", Description = "Dairy" },
                new { Id = Guid.Parse("d64ac173-84b5-4ab2-b7e1-93e06e9f3a31"), Name = "Snack", Description = "Snack" },
                new { Id = Guid.Parse("bc9f2bec-70d8-4655-899e-da988b29697f"), Name = "Fruit", Description = "Fruit" }
            );

            //Seed default Data to Product Table
            builder.Entity<Product>().HasData(
                new { Id = Guid.Parse("838b6c72-adee-450e-87f5-56df8e86994d"), Name = "Monster Energy Drink", Description = "Monster Energy Drink", Price = 3.99, CategoryId = Guid.Parse("990638f8-f1e5-49dd-b73d-86b24eefcf9f"), ImageURL = "https://assets.woolworths.com.au/images/2010/329812.jpg?impolicy=wowcdxwbjbx&w=900&h=900" },
                new { Id = Guid.Parse("fc41ff1d-e663-4cd9-83ce-18be3db3121e"), Name = "Minced Meat", Description = "Minced Meat", Price = 17.75, CategoryId = Guid.Parse("1a7fed9f-63a6-4f1c-96a0-73e0de797887"), ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR-FYbNOJNwTrorlSQ6Q8r3qhrIzlW-PAPHrg&usqp=CAU" },
                new { Id = Guid.Parse("9b84906f-4ec9-42a2-8269-22daaaca56c7"), Name = "Almond Milk", Description = "Almond Milk", Price = 6.99, CategoryId = Guid.Parse("49e70c8c-902b-4f23-8dc6-fdaba3d3fded"), ImageURL = "https://assets.woolworths.com.au/images/2010/901450.jpg?impolicy=wowcdxwbjbx&w=900&h=900" },
                new { Id = Guid.Parse("bb4b35a1-d7b4-4196-b85a-afa478a086d5"), Name = "Doritos", Description = "Doritos", Price = 3.49, CategoryId = Guid.Parse("d64ac173-84b5-4ab2-b7e1-93e06e9f3a31"), ImageURL = "https://www.doritos.com/sites/doritos.com/files/2018-08/new-nacho-cheese.png" },
                new { Id = Guid.Parse("7afa6882-7f50-4ef7-8198-18c0faf20c47"), Name = "Shrimp", Description = "Shrimp", Price = 21.99, CategoryId = Guid.Parse("941d1dbf-3da0-4fb0-bba9-abbdc9d836b7"), ImageURL = "https://www.dhhenderson.co.nz/wp-content/uploads/2020/04/381.png" },
                new { Id = Guid.Parse("fd21993c-9137-4065-a67b-a44b5fc86466"), Name = "Tooth Brush", Description = "Tooth Brush", Price = 8.99, CategoryId = Guid.Parse("b6aa08b8-a381-4c52-98d7-f7a18b2f839c"), ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTpAnFUVxkzfJcP3mQO8_TTwJ65Qnw82dMUOg&usqp=CAU" },
                new { Id = Guid.Parse("b9ea3a02-6e5a-4f43-b2e8-c5a9a5895416"), Name = "Banana Bread", Description = "Banana Bread", Price = 5.49, CategoryId = Guid.Parse("1d0e49b1-7f90-4c55-b689-6654a7177476"), ImageURL = "https://loshusansupermarket.com/product_images/d/597/KISS_BANANA_BREAD_72G_tagged__00890_zoom.jpg" },
                new { Id = Guid.Parse("3008f59b-9926-4476-a27f-a16294044bc4"), Name = "Deodorant", Description = "Deodorant", Price = 6.49, CategoryId = Guid.Parse("ead27726-c61f-405b-9415-45592a9aaaad"), ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQfd1I1jKbThIGhMOYOUyMqxdFiXopcdNeMgw&usqp=CAU" },
                new { Id = Guid.Parse("84415975-4a18-4762-9e3b-8cc7e6c7e7b1"), Name = "Banana", Description = "Banana", Price = 6.99, CategoryId = Guid.Parse("bc9f2bec-70d8-4655-899e-da988b29697f"), ImageURL = "https://www.supermarketperimeter.com/ext/resources/bananas-sp.jpg?height=667&t=1550787674&width=1080" },
                new { Id = Guid.Parse("fb8e13c5-e4e5-4565-b56e-c2a1ab880324"), Name = "Apple", Description = "Apple", Price = 7.89, CategoryId = Guid.Parse("bc9f2bec-70d8-4655-899e-da988b29697f"), ImageURL = "https://www.dhhenderson.co.nz/wp-content/uploads/2020/04/1381781721.jpg" },
                new { Id = Guid.Parse("730d9530-9913-40f1-a7b2-2a96ba7d9940"), Name = "Peach", Description = "Peach", Price = 10.79, CategoryId = Guid.Parse("bc9f2bec-70d8-4655-899e-da988b29697f"), ImageURL = "https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/71TIMGiDE9L._AC_SL1200_.jpg" },
                new { Id = Guid.Parse("3505780f-4511-42c4-b7a1-18809a0bb14a"), Name = "Pear", Description = "Pear", Price = 5.69, CategoryId = Guid.Parse("bc9f2bec-70d8-4655-899e-da988b29697f"), ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQbOprtVHqqGoOtlUpVmtfSkcz3pQNeucvmnQ&usqp=CAU" },
                new { Id = Guid.Parse("907624f9-07dc-4164-936c-88efc0454b37"), Name = "Lemon", Description = "Lemon", Price = 16.99, CategoryId = Guid.Parse("bc9f2bec-70d8-4655-899e-da988b29697f"), ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQbjqwOLzK0kH4i9Xyy75OV21ShL8VWRqDHtA&usqp=CAU" },
                new { Id = Guid.Parse("6841cf9c-35b3-40d4-bb09-6da813d29a0b"), Name = "Orange", Description = "Orange", Price = 9.49, CategoryId = Guid.Parse("bc9f2bec-70d8-4655-899e-da988b29697f"), ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTAMzbzLWOy4yprdYfG_LC6H7NtD3AbAv3UWw&usqp=CAU" },
                new { Id = Guid.Parse("8ce0fd1e-e29f-4039-a44e-66dbbe1a6d4f"), Name = "Avocado", Description = "Avocado", Price = 6.99, CategoryId = Guid.Parse("bc9f2bec-70d8-4655-899e-da988b29697f"), ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQHxBWZ-d1QmXgXd14ot7ySXecYecJOEUhgiQ&usqp=CAU" },
                new { Id = Guid.Parse("efb8cc35-0e2e-4f64-91e8-2e1fe19fb7a0"), Name = "JackFruit", Description = "JackFruit", Price = 7.49, CategoryId = Guid.Parse("bc9f2bec-70d8-4655-899e-da988b29697f"), ImageURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTONI8-aZErJ6p5lTZpU4_TpENpjhjUmFzLrg&usqp=CAU" },
                new { Id = Guid.Parse("9dbdaaff-ca16-4405-af5c-30f842d48e27"), Name = "Soap", Description = "Soap", Price = 2.49, CategoryId = Guid.Parse("ead27726-c61f-405b-9415-45592a9aaaad"), ImageURL = "https://www.tastenature.co.nz/wp-content/uploads/2021/10/Farmers-Pumice-Soap-2x100g-900-1.jpg" },
                new { Id = Guid.Parse("d3ed8dd4-61d3-45df-8f5b-656da8e66b49"), Name = "Shampoo", Description = "Shampoo", Price = 3.49, CategoryId = Guid.Parse("ead27726-c61f-405b-9415-45592a9aaaad"), ImageURL = "https://www.beautyheaven.com.au/wp-content/uploads/2021/11/10-2.png" },
                new { Id = Guid.Parse("19b0449d-58d5-4ee1-96d5-ab5f22e3d3c5"), Name = "Conditioner", Description = "Conditioner", Price = 5.29, CategoryId = Guid.Parse("ead27726-c61f-405b-9415-45592a9aaaad"), ImageURL = "https://assets.woolworths.com.au/images/2010/486564.jpg?impolicy=wowcdxwbjbx&w=900&h=900" }
            );

            //Seed default Data to Promotion Table
            builder.Entity<Promotion>().HasData(
               new { Id = Guid.Parse("42b5df48-713e-400c-ba4a-6865db344cb0"), Discount = 12.00, Start = DateTime.Now, End = DateTime.Now.AddDays(2) },
               new { Id = Guid.Parse("2cf96105-34d3-4808-931c-18e2f400d267"), Discount = 25.00, Start = DateTime.Now, End = DateTime.Now.AddDays(5) },
               new { Id = Guid.Parse("9f0d4385-03f1-4cd9-91f9-b198caa90d84"), Discount = 50.00, Start = DateTime.Now, End = DateTime.Now.AddDays(15) }
            );

            //Seed default Data to ProductPromotion Table
            builder.Entity<ProductPromotion>().HasData(
               new { Id = Guid.NewGuid(), ProductId = Guid.Parse("838b6c72-adee-450e-87f5-56df8e86994d"), PromotionId = Guid.Parse("42b5df48-713e-400c-ba4a-6865db344cb0") },
               new { Id = Guid.NewGuid(), ProductId = Guid.Parse("fc41ff1d-e663-4cd9-83ce-18be3db3121e"), PromotionId = Guid.Parse("2cf96105-34d3-4808-931c-18e2f400d267") },
               new { Id = Guid.NewGuid(), ProductId = Guid.Parse("fd21993c-9137-4065-a67b-a44b5fc86466"), PromotionId = Guid.Parse("9f0d4385-03f1-4cd9-91f9-b198caa90d84") }
            );



        }

        public DbSet<Product> Products { get; set; } = default!;
        public DbSet<Cart> Carts { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!;
        public DbSet<Promotion> Promotions { get; set; } = default!;
        public DbSet<ProductPromotion> ProductPromotions { get; set; } = default!;
        public DbSet<UserProduct> UserProducts { get; set; } = default!;   
    }
}