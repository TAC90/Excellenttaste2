namespace ExcellentTaste.Migrations
{
    using ExcellentTaste.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ExcellentTaste.Models.ExcellentTasteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ExcellentTaste.Models.ExcellentTasteContext context)
        {
            context.Users.AddOrUpdate(new User() { UserId = 1, FirstName = "Al", LastName = "Capone", UserType = UserType.Admin });
            context.Users.AddOrUpdate(new User() { UserId = 2, FirstName = "Gordon", LastName = "Ramsey", UserType = UserType.Cook });
            context.Users.AddOrUpdate(new User() { UserId = 3, FirstName = "Jamie", LastName = "Oliver", UserType = UserType.Cook });
            context.Users.AddOrUpdate(new User() { UserId = 4, FirstName = "David", LastName = "Guetta", UserType = UserType.Bartender });
            context.Users.AddOrUpdate(new User() { UserId = 5, FirstName = "Eve", LastName = "Moneypenny", UserType = UserType.Receptionist });
            context.Users.AddOrUpdate(new User() { UserId = 6, FirstName = "Jean", LastName = "Philippe", UserType = UserType.Waiter });
            context.Users.AddOrUpdate(new User() { UserId = 7, FirstName = "Tijs", LastName = "Verwest", UserType = UserType.Waiter });

            var food1 = new Food { FoodId = 1, Name = "Steak", FoodType = FoodType.MainDish, Price = 12.50m, FoodOptions = new List<FoodOption>() };
            var food2 = new Food { FoodId = 2, Name = "Zalm", FoodType = FoodType.MainDish, Price = 14m};

            var foodOption1 = new FoodOption { FoodOptionId = 1, Option = "Rare" };
            var foodOption2 = new FoodOption { FoodOptionId = 2, Option = "Medium Rare" };
            var foodOption3 = new FoodOption { FoodOptionId = 3, Option = "Medium" };
            var foodOption4 = new FoodOption { FoodOptionId = 4, Option = "Well Done" };

            food1.FoodOptions.Add(foodOption1);
            food1.FoodOptions.Add(foodOption2);
            food1.FoodOptions.Add(foodOption3);
            food1.FoodOptions.Add(foodOption4);

            context.Foods.AddOrUpdate(food1);
            context.Foods.AddOrUpdate(food2);

            context.FoodOptions.AddOrUpdate(foodOption1);
            context.FoodOptions.AddOrUpdate(foodOption2);
            context.FoodOptions.AddOrUpdate(foodOption3);
            context.FoodOptions.AddOrUpdate(foodOption4);




            context.SaveChanges();
        }
    }
}
