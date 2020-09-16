using DataAccessLayer.Contexts;
using DataAccessLayer.DbModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradePlatformTestApp.Data
{
    public static class DbInitializer
    {
        public static void InitializeApplicationDbContext(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var users = new IdentityUser[]
            {     
                new IdentityUser  {
                    Id = "3cf89f8b-5064-4d76-bbdc-64f8a4e85e4a",  UserName = "Test1@test.ru",   
                    NormalizedUserName = "TEST1@TEST.RU",  Email = "Test1@test.ru",   
                    NormalizedEmail = "TEST1@TEST.RU", EmailConfirmed = true,  
                    PasswordHash = "AQAAAAEAACcQAAAAEMT9E2Ov5QjEa5m/9d+2vHurB1OPkOhiT5FezquJ7xO+KWMArlvMIpxJiQTSorFaTQ==", SecurityStamp = "IUVDCJCG7JQFVR35YDNB3UCCBZQGBTN5",   
                    ConcurrencyStamp = "b8771eda-808b-42e6-9ab4-a42d652a027c", LockoutEnabled = true
                },
                new IdentityUser  
                {
                    Id = "2bc052f2-802b-4f7d-885d-29f340824e9f",  UserName = "Test2@test.ru",    
                    NormalizedUserName = "TEST2@TEST.RU",  Email = "Test2@test.ru",  
                    NormalizedEmail = "TEST2@TEST.RU", EmailConfirmed = true,  
                    PasswordHash = "AQAAAAEAACcQAAAAEG+BTVInKP4RDkVOGSH925XOJ6ewYfOPYypGVRefqcvihiU27n78ArpiNewPhjA6Dw==", SecurityStamp = "E3ZPMJFUU6WGCUKXA4A2OHH44AFNYYXP",   
                    ConcurrencyStamp = "65ecd28d-72c6-4c26-b038-14dc8ceaee0a", LockoutEnabled = true
                },              
                new IdentityUser  {
                    Id = "4bd61928-77b2-4c8a-a410-6c7d109fbdd2", UserName = "Test3@test.ru",
                    NormalizedUserName = "TEST3@TEST.RU", Email = "Test3@test.ru",
                    NormalizedEmail = "TEST3@TEST.RU", EmailConfirmed = true,  
                    PasswordHash = "AQAAAAEAACcQAAAAEOB9p//bLi3Q2bRwDBfErKodT/VRU8QgSZNZqZVPJgKwtW+xSpGHnEkxhUzoB+BQ3A==", SecurityStamp = "3TKE6R446Z2JBAQBZZAD5RBLB6ABMK34",
                    ConcurrencyStamp = "c5cf5dd3-4c3a-47b1-bbfa-ae0271865f6a", LockoutEnabled = true
                }                
            };

            foreach (var u in users)
            {
                context.Users.Add(u);
            }

            context.SaveChanges();
        }

        public static void InitializeTestDbContext(TestDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.ProductCategories.Any())
            {                
                var productCategories = new ProductCategory[]
                {
                    new ProductCategory() { Name = "Category1" },
                    new ProductCategory() { Name = "Category2" },
                    new ProductCategory() { Name = "Category3" }
                };

                foreach (var p in productCategories)
                {
                    context.ProductCategories.Add(p);
                }

                context.SaveChanges();
            }

            if (!context.ProductStatuses.Any())
            { 
                var productStatus = new ProductStatus[]
                {
                    new ProductStatus() { Name = "LowPriority", PriorityLevel = PriorityLevel.Low },
                    new ProductStatus() { Name = "MiddlePriority", PriorityLevel = PriorityLevel.Middle },
                    new ProductStatus() { Name = "HighPriority", PriorityLevel = PriorityLevel.Max }
                };

                foreach (var p in productStatus)
                {
                    context.ProductStatuses.Add(p);
                }

                context.SaveChanges();
            }

            if (context.Products.Any())
            {
                return;
            }
            
            var products = new Product[]
            {
                new Product
                {
                    Name = "TestProduct1", 
                    Description = "Description1",  
                    Cost = 123, Phone = "(123) 456-7890", 
                    ProductCategoryId = 1, 
                    ProductStatusId = 3, 
                    CreatorId = "3cf89f8b-5064-4d76-bbdc-64f8a4e85e4a"
                },
               new Product
               {
                   Name = "TestProduct2", 
                   Description = "Description2",  
                   Cost = 123, Phone = "(123) 456-7890", 
                   ProductCategoryId = 2, 
                   ProductStatusId = 2, 
                   CreatorId = "3cf89f8b-5064-4d76-bbdc-64f8a4e85e4a"
               },
               new Product
               {
                   Name = "TestProduct3", 
                   Description = "Description3",  
                   Cost = 123, Phone = "(123) 456-7890", 
                   ProductCategoryId = 3, 
                   ProductStatusId = 1, 
                   CreatorId = "3cf89f8b-5064-4d76-bbdc-64f8a4e85e4a"
               },
               
               new Product
               {
                   Name = "TestProduct4", 
                   Description = "Description4",  
                   Cost = 123, Phone = "(123) 123-4567", 
                   ProductCategoryId = 1, 
                   ProductStatusId = 3, 
                   CreatorId = "2bc052f2-802b-4f7d-885d-29f340824e9f"
               },
               new Product
               {
                   Name = "TestProduct5", 
                   Description = "Description5",  
                   Cost = 123, Phone = "(123) 123-4567", 
                   ProductCategoryId = 2, 
                   ProductStatusId = 2, 
                   CreatorId = "2bc052f2-802b-4f7d-885d-29f340824e9f"
               },
               new Product
               {
                   Name = "TestProduct6", 
                   Description = "Description6",  
                   Cost = 123, Phone = "(123) 123-4567", 
                   ProductCategoryId = 3, 
                   ProductStatusId = 1, 
                   CreatorId = "2bc052f2-802b-4f7d-885d-29f340824e9f"
               },
               
               new Product
               {
                   Name = "TestProduct7", 
                   Description = "Description7",  
                   Cost = 123, Phone = "(123) 987-6543", 
                   ProductCategoryId = 1, 
                   ProductStatusId = 3, 
                   CreatorId = "4bd61928-77b2-4c8a-a410-6c7d109fbdd2"
               },
               new Product
               {
                   Name = "TestProduct8", 
                   Description = "Description8",  
                   Cost = 123, Phone = "(123) 987-6543",
                   ProductCategoryId = 2, 
                   ProductStatusId = 2, 
                   CreatorId = "4bd61928-77b2-4c8a-a410-6c7d109fbdd2"
               },
               new Product
               {
                   Name = "TestProduct8", 
                   Description = "Description8",  
                   Cost = 123, Phone = "(123) 987-6543", 
                   ProductCategoryId = 3,
                   ProductStatusId = 1, 
                   CreatorId = "4bd61928-77b2-4c8a-a410-6c7d109fbdd2"
               },
               
               new Product
               {
                   Name = "TestProduct9", 
                   Description = "Description9",  
                   Cost = 123, Phone = "(123) 456-7890", 
                   ProductCategoryId = 1, 
                   ProductStatusId = 3, 
                   CreatorId = "3cf89f8b-5064-4d76-bbdc-64f8a4e85e4a"
               },
               new Product
               {
                   Name = "TestProduct10", 
                   Description = "Description10", 
                   Cost = 123, Phone = "(123) 456-7890", 
                   ProductCategoryId = 2, 
                   ProductStatusId = 2, 
                   CreatorId = "3cf89f8b-5064-4d76-bbdc-64f8a4e85e4a"
               },
               new Product
               {
                   Name = "TestProduct1", 
                   Description = "Description1",  
                   Cost = 123, Phone = "(123) 456-7890", 
                   ProductCategoryId = 3, 
                   ProductStatusId = 1, 
                   CreatorId = "3cf89f8b-5064-4d76-bbdc-64f8a4e85e4a"
               },

               new Product
               {
                   Name = "TestProduct12", 
                   Description = "Description12",  
                   Cost = 123, Phone = "(123) 123-4567", 
                   ProductCategoryId = 1, 
                   ProductStatusId = 3, 
                   CreatorId = "2bc052f2-802b-4f7d-885d-29f340824e9f"
               },
               new Product
               {
                   Name = "TestProduct13", 
                   Description = "Description13",  
                   Cost = 123, Phone = "(123) 123-4567", 
                   ProductCategoryId = 2, 
                   ProductStatusId = 2, 
                   CreatorId = "2bc052f2-802b-4f7d-885d-29f340824e9f"
               },
               new Product
               {
                   Name = "TestProduct14", 
                   Description = "Description14",  
                   Cost = 123, Phone = "(123) 123-4567", 
                   ProductCategoryId = 3, 
                   ProductStatusId = 1, 
                   CreatorId = "2bc052f2-802b-4f7d-885d-29f340824e9f"
               },

               new Product
               {
                   Name = "TestProduct15", 
                   Description = "Description15",  
                   Cost = 123, Phone = "(123) 987-6543", 
                   ProductCategoryId = 1, 
                   ProductStatusId = 3, 
                   CreatorId = "4bd61928-77b2-4c8a-a410-6c7d109fbdd2"
               },
               new Product
               {
                   Name = "TestProduct16", 
                   Description = "Description16",  
                   Cost = 123, Phone = "(123) 987-6543", 
                   ProductCategoryId = 2, 
                   ProductStatusId = 2, 
                   CreatorId = "4bd61928-77b2-4c8a-a410-6c7d109fbdd2"
               },
               new Product
               {
                   Name = "TestProduct17", 
                   Description = "Description17",  
                   Cost = 123, Phone = "(123) 987-6543", 
                   ProductCategoryId = 3, 
                   ProductStatusId = 1, 
                   CreatorId = "4bd61928-77b2-4c8a-a410-6c7d109fbdd2"
               }
            };
            
            foreach (var p in products)
            {
                context.Products.Add(p);
            }

            context.SaveChanges();
        }
    }
}
