using Maui.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace Maui.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            _ = modelBuilder.Entity<ProjectModel>().HasData(
                new ProjectModel
                {
                    Id = 1,
                    Name = "Grunge Skater Jeans",
                    Description = "oi",
                    CreateAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                },
                new ProjectModel { Id = 2, Name = "Polo Shirt", },
                new ProjectModel { Id = 3, Name = "Skater Graphic T-Shirt" },
                new ProjectModel { Id = 4, Name = "Slicker Jacket" },
                new ProjectModel { Id = 5, Name = "Thermal Fleece Jacket" },
                new ProjectModel { Id = 6, Name = "Unisex Thermal Vest" },
                new ProjectModel { Id = 7, Name = "V-Neck Pullover" },
                new ProjectModel { Id = 8, Name = "V-Neck Sweater" },
                new ProjectModel { Id = 9, Name = "V-Neck T-Shirt" },
                new ProjectModel { Id = 10, Name = "Bamboo Thermal Ski Coat" },
                new ProjectModel { Id = 11, Name = "Cross-Back Training Tank" },
                new ProjectModel { Id = 13, Name = "Slicker Jacket" },
                new ProjectModel { Id = 14, Name = "Stretchy Dance Pants" },
                new ProjectModel { Id = 15, Name = "Ultra-Soft Tank Top" },
                new ProjectModel { Id = 16, Name = "Unisex Thermal Vest" },
                new ProjectModel { Id = 17, Name = "V-Next T-Shirt" },
                new ProjectModel { Id = 18, Name = "Blueberry Mineral Water" },
                new ProjectModel { Id = 19, Name = "Lemon-Lime Mineral Water" },
                new ProjectModel { Id = 20, Name = "Orange Mineral Water" },
                new ProjectModel { Id = 21, Name = "Peach Mineral Water" },
                new ProjectModel { Id = 22, Name = "Raspberry Mineral Water" },
                new ProjectModel { Id = 23, Name = "Strawberry Mineral Water" },
                new ProjectModel { Id = 24, Name = "In the Kitchen with H+ Sport" },
                new ProjectModel { Id = 25, Name = "Calcium 400 IU (150 tablets)" },
                new ProjectModel { Id = 26, Name = "Flaxseed Oil 100 mg (90 capsules)" },
                new ProjectModel { Id = 27, Name = "Iron 65 mg (150 caplets)" },
                new ProjectModel { Id = 28, Name = "Magnesium 250 mg (100 tablets)" },
                new ProjectModel { Id = 29, Name = "Multi-Vitamin (90 capsules)" },
                new ProjectModel { Id = 30, Name = "Vitamin A 10,000 IU (125 caplets)" },
                new ProjectModel { Id = 31, Name = "Vitamin B-Complex (100 caplets)" },
               new ProjectModel { Id = 32, Name = "Vitamin C 1000 mg (100 tablets)" },
               new ProjectModel { Id = 33, Name = "Vitamin D3 1000 IU (100 tablets)" });
        }
    }
}