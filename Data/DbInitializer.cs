using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NutritionTrackerRazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutritionTrackerRazorPages.Data
{
    public static class DbInitializer
    {
        //public static void Initialize(ApplicationDbContext context)
        public static void Initialize(IServiceProvider serviceProvider, string pw)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {

                if (context.SimpleFood.Any()) return;

                string create_user(string name, string email)
                {
                    var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

                    var user = new IdentityUser()
                    {
                        UserName = name,
                        Email = email,
                        EmailConfirmed = true
                    };

                    var result = userManager.CreateAsync(user, "Secret123!").Result;

                    return user.Id;
                }

                var linus_id = create_user("linus", "linus@linux.org");

                var alan_id = create_user("alan", "alan@smalltalk.org");

                var admin_id = create_user("admin", "admin@nutritiontracker.test");


                //string Admin;

                //{
                //    var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

                //    var user = userManager.FindByNameAsync("admin@gnu.org").Result;

                //    if (user == null)
                //    {
                //        var newUser = new IdentityUser()
                //        {
                //            UserName = "admin@gnu.org",
                //            EmailConfirmed = true
                //        };

                //        var result = userManager.CreateAsync(newUser, pw).Result;

                //        Admin = newUser.Id;
                //    }

                //    Admin = user.Id;
                //}

                var meat = new FoodCategory() { Name = "Meat", UserId = linus_id };
                var fish = new FoodCategory() { Name = "Fish", UserId = linus_id };
                var vegetable = new FoodCategory() { Name = "Vegetable", UserId = linus_id };
                var fruit = new FoodCategory() { Name = "Fruit", UserId = linus_id };
                var legume = new FoodCategory() { Name = "Legume", UserId = linus_id };
                var grain = new FoodCategory() { Name = "Grain", UserId = linus_id };
                var sauce = new FoodCategory() { Name = "Sauce", UserId = linus_id };
                var condiment = new FoodCategory() { Name = "Condiment", UserId = linus_id };

                context.FoodCategory.AddRange(meat, fish, vegetable, fruit, legume, grain, sauce);

                context.SaveChanges();

                var beef80  = new SimpleFood() { UserId = admin_id, Name = "Ground Beef 80/20 (g)", FoodCategory = meat, ServingSize = 100, Calories = 254, Fat = 16.20m, Carbohydrates = 0, Protein = 25.30m };
                var basmati = new SimpleFood() { UserId = admin_id, Name = "Basmati Rice (g)", FoodCategory = grain, ServingSize = 45, Calories = 160, Fat = 0.5m, Carbohydrates = 36, Protein = 3 };
                var avocado = new SimpleFood() { UserId = admin_id, Name = "Avocado (g)", FoodCategory = fruit, ServingSize = 100, Calories = 167, Fat = 15.40m, Carbohydrates = 8.6m, Protein = 2 };
                var lentils = new SimpleFood() { UserId = admin_id, Name = "Lentils (g)", FoodCategory = legume, ServingSize = 35, Calories = 100, Fat = 0.5m, Carbohydrates = 23m, Protein = 8 };
                var lima    = new SimpleFood() { UserId = admin_id, Name = "Lima Beans (g)", FoodCategory = legume, ServingSize = 35, Calories = 100, Fat = 0.5m, Carbohydrates = 22m, Protein = 7 };
                var onion   = new SimpleFood() { UserId = admin_id, Name = "Onion (g)", FoodCategory = vegetable, ServingSize = 100, Calories = 40, Fat = 0.10m, Carbohydrates = 9.3m, Protein = 1.1m };
                var yam     = new SimpleFood() { UserId = admin_id, Name = "Yam (g)", FoodCategory = vegetable, ServingSize = 100, Calories = 118, Fat = 0.2m, Carbohydrates = 27.9m, Protein = 1.5m };
                var apple   = new SimpleFood() { UserId = admin_id, Name = "Apple (g)", FoodCategory = fruit, ServingSize = 100, Calories = 52, Fat = 0.2m, Carbohydrates = 13.8m, Protein = 0.3m };
                var banana  = new SimpleFood() { UserId = admin_id, Name = "Banana (g)", FoodCategory = fruit, ServingSize = 100, Calories = 89, Fat = 0.3m, Carbohydrates = 22.8m, Protein = 1.1m };
                var salmon  = new SimpleFood() { UserId = admin_id, Name = "Salmon (g)", FoodCategory = fish, ServingSize = 100, Calories = 153, Fat = 7.3m, Carbohydrates = 0, Protein = 21.9m };

                var A_beef80 = new SimpleFood() { UserId = admin_id, Name = "Ground Beef 80/20 (g)", FoodCategory = meat, ServingSize = 100, Calories = 254, Fat = 16.20m, Carbohydrates = 0, Protein = 25.30m };
                var A_basmati = new SimpleFood() { UserId = admin_id, Name = "Basmati Rice (g)", FoodCategory = grain, ServingSize = 45, Calories = 160, Fat = 0.5m, Carbohydrates = 36, Protein = 3 };
                var A_avocado = new SimpleFood() { UserId = admin_id, Name = "Avocado (g)", FoodCategory = fruit, ServingSize = 100, Calories = 167, Fat = 15.40m, Carbohydrates = 8.6m, Protein = 2 };
                var A_lentils = new SimpleFood() { UserId = admin_id, Name = "Lentils (g)", FoodCategory = legume, ServingSize = 35, Calories = 100, Fat = 0.5m, Carbohydrates = 23m, Protein = 8 };
                var A_lima = new SimpleFood() { UserId = admin_id, Name = "Lima Beans (g)", FoodCategory = legume, ServingSize = 35, Calories = 100, Fat = 0.5m, Carbohydrates = 22m, Protein = 7 };
                var A_onion = new SimpleFood() { UserId = admin_id, Name = "Onion (g)", FoodCategory = vegetable, ServingSize = 100, Calories = 40, Fat = 0.10m, Carbohydrates = 9.3m, Protein = 1.1m };
                var A_yam = new SimpleFood() { UserId = admin_id, Name = "Yam (g)", FoodCategory = vegetable, ServingSize = 100, Calories = 118, Fat = 0.2m, Carbohydrates = 27.9m, Protein = 1.5m };
                var A_apple = new SimpleFood() { UserId = admin_id, Name = "Apple (g)", FoodCategory = fruit, ServingSize = 100, Calories = 52, Fat = 0.2m, Carbohydrates = 13.8m, Protein = 0.3m };
                var A_banana = new SimpleFood() { UserId = admin_id, Name = "Banana (g)", FoodCategory = fruit, ServingSize = 100, Calories = 89, Fat = 0.3m, Carbohydrates = 22.8m, Protein = 1.1m };
                var A_salmon = new SimpleFood() { UserId = admin_id, Name = "Salmon (g)", FoodCategory = fish, ServingSize = 100, Calories = 153, Fat = 7.3m, Carbohydrates = 0, Protein = 21.9m };

                var B_beef80 = new SimpleFood() { UserId = admin_id, Name = "Ground Beef 80/20 (g)", FoodCategory = meat, ServingSize = 100, Calories = 254, Fat = 16.20m, Carbohydrates = 0, Protein = 25.30m };
                var B_basmati = new SimpleFood() { UserId = admin_id, Name = "Basmati Rice (g)", FoodCategory = grain, ServingSize = 45, Calories = 160, Fat = 0.5m, Carbohydrates = 36, Protein = 3 };
                var B_avocado = new SimpleFood() { UserId = admin_id, Name = "Avocado (g)", FoodCategory = fruit, ServingSize = 100, Calories = 167, Fat = 15.40m, Carbohydrates = 8.6m, Protein = 2 };
                var B_lentils = new SimpleFood() { UserId = admin_id, Name = "Lentils (g)", FoodCategory = legume, ServingSize = 35, Calories = 100, Fat = 0.5m, Carbohydrates = 23m, Protein = 8 };
                var B_lima = new SimpleFood() { UserId = admin_id, Name = "Lima Beans (g)", FoodCategory = legume, ServingSize = 35, Calories = 100, Fat = 0.5m, Carbohydrates = 22m, Protein = 7 };
                var B_onion = new SimpleFood() { UserId = admin_id, Name = "Onion (g)", FoodCategory = vegetable, ServingSize = 100, Calories = 40, Fat = 0.10m, Carbohydrates = 9.3m, Protein = 1.1m };
                var B_yam = new SimpleFood() { UserId = admin_id, Name = "Yam (g)", FoodCategory = vegetable, ServingSize = 100, Calories = 118, Fat = 0.2m, Carbohydrates = 27.9m, Protein = 1.5m };
                var B_apple = new SimpleFood() { UserId = admin_id, Name = "Apple (g)", FoodCategory = fruit, ServingSize = 100, Calories = 52, Fat = 0.2m, Carbohydrates = 13.8m, Protein = 0.3m };
                var B_banana = new SimpleFood() { UserId = admin_id, Name = "Banana (g)", FoodCategory = fruit, ServingSize = 100, Calories = 89, Fat = 0.3m, Carbohydrates = 22.8m, Protein = 1.1m };
                var B_salmon = new SimpleFood() { UserId = admin_id, Name = "Salmon (g)", FoodCategory = fish, ServingSize = 100, Calories = 153, Fat = 7.3m, Carbohydrates = 0, Protein = 21.9m };


                var BornierMustard = new SimpleFood() { UserId = linus_id, Name = "Organic Wholegrain Dijon Mustard [Bornier] (g)", FoodCategory = condiment, ServingSize = 5, Calories = 10, Fat = 0.5m, Sodium = 105, Carbohydrates = 0, Protein = 0 };
                var LuciniTomatoBasil = new SimpleFood() { UserId = linus_id, Name = "Rustic Tomato Basil [Lucini] (g)", FoodCategory = sauce, ServingSize = 100, Calories = 28, Fat = 1.2m, Carbohydrates = 4m, Protein = 0.8m };

                context.SimpleFood.AddRange(beef80, salmon, basmati, avocado, lentils, lima, onion, yam, apple, banana,
                    LuciniTomatoBasil,
                    BornierMustard);

                context.SimpleFood.AddRange(
                    A_beef80, 
                    A_salmon, 
                    A_basmati, 
                    A_avocado, 
                    A_lentils, 
                    A_lima, 
                    A_onion, 
                    A_yam, 
                    A_apple, 
                    A_banana,

                    B_beef80,
                    B_salmon,
                    B_basmati,
                    B_avocado,
                    B_lentils,
                    B_lima,
                    B_onion,
                    B_yam,
                    B_apple,
                    B_banana

                    );

                context.SaveChanges();

                context.FoodRecord.AddRange();

                context.SaveChanges();

                var LimaYamOnion = new ComplexFood()
                {
                    UserId = linus_id,
                    Name = "LimaYamOnion",
                    ServingSize = 3000,
                    ComplexFoodComponents = new[]
                    {
                        new ComplexFoodComponent() { UserId = linus_id, SimpleFood = lima,  Amount = 454 },
                        new ComplexFoodComponent() { UserId = linus_id, SimpleFood = yam,   Amount = 642 },
                        new ComplexFoodComponent() { UserId = linus_id, SimpleFood = onion, Amount = 330 }
                    }.ToList()
                };

                var SpaghettiMeatSauce = new ComplexFood()
                {
                    UserId = linus_id,
                    Name = "Spaghetti Meat Sauce",
                    ServingSize = 1000,
                    ComplexFoodComponents = new[]
                    {
                        new ComplexFoodComponent() { UserId = linus_id, SimpleFood = LuciniTomatoBasil, Amount = 400 },
                        new ComplexFoodComponent() { UserId = linus_id, SimpleFood = beef80, Amount = 454 },
                        new ComplexFoodComponent() { UserId = linus_id, SimpleFood = onion, Amount = 300 }
                    }.ToList()
                };

                context.ComplexFood.AddRange(
                    LimaYamOnion,
                    SpaghettiMeatSauce
                    );

                context.FoodRecord.AddRange(
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("2021-01-01 12:00"), Food = beef80, Amount = 200 },
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("2021-01-01 12:00"), Food = basmati, Amount = 300 },
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("2021-01-01 12:00"), Food = avocado, Amount = 50 },
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("2021-01-01 18:00"), Food = lentils, Amount = 250 },
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("2021-01-01 18:00"), Food = onion, Amount = 150 },
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-01-01"), Time = DateTime.Parse("2021-01-01 18:00"), Food = basmati, Amount = 350 },
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-05-29"), Time = DateTime.Parse("2021-05-29 12:00"), Food = LimaYamOnion, Amount = 300 },
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-05-29"), Time = DateTime.Parse("2021-05-29 18:00"), Food = LimaYamOnion, Amount = 500 },
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-05-31"), Time = DateTime.Parse("2021-05-31 12:00"), Food = salmon, Amount = 150 },
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-01-02"), Time = DateTime.Parse("2021-01-02 12:00"), Food = beef80, Amount = 200 },
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-01-02"), Time = DateTime.Parse("2021-01-02 12:00"), Food = basmati, Amount = 300 },
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-01-02"), Time = DateTime.Parse("2021-01-02 12:00"), Food = avocado, Amount = 50 },
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-01-02"), Time = DateTime.Parse("2021-01-02 18:00"), Food = lentils, Amount = 250 },
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-01-02"), Time = DateTime.Parse("2021-01-02 18:00"), Food = onion, Amount = 150 },
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-01-02"), Time = DateTime.Parse("2021-01-02 18:00"), Food = basmati, Amount = 350 },
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-01-03"), Time = DateTime.Parse("2021-01-03 12:00"), Food = LimaYamOnion, Amount = 300 },
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-01-03"), Time = DateTime.Parse("2021-01-03 18:00"), Food = LimaYamOnion, Amount = 500 },
                    new FoodRecord() { UserId = linus_id, Date = DateTime.Parse("2021-01-03"), Time = DateTime.Parse("2021-01-03 12:00"), Food = salmon, Amount = 150 }
                    );

                //var a = new FoodRecord() { Date = DateTime.Parse("2021-05-29"), Time = DateTime.Parse("2021-05-29 12:00"), Food = LimaYamOnion, Amount = 300 };
                //var b = new FoodRecord() { Date = DateTime.Parse("2021-05-29"), Time = DateTime.Parse("2021-05-29 18:00"), Food = LimaYamOnion, Amount = 500 };

                context.SaveChanges();

            }
        }

    }
}
