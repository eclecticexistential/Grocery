using CSharpProjectWAccounts.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace CSharpProjectWAccounts
{
    internal class DatabaseInitializer :
        CreateDatabaseIfNotExists<GroceryContext>
    {
        //seeds inventory
        protected override void Seed(GroceryContext context)
        {
            context.ListOfRecipes.AddOrUpdate(p => p.Id,
            new RecipeItems { Id = 0, RecipeName = "Potato Soup", Description = "Hearty comfort food. Use four large potatoes, 3 cups milk, three stalks of celery, half an onion, fry bacon and add. Season to taste."},
            new RecipeItems { Id = 1, RecipeName = "Chicken Broccoli Rice", Description = "Tasty rice dish. Boil rice until soft. Bake chicken until done. Add together in baking dish with broccoli. Cook until lightly brown."}
            );
            context.GroceryItems.AddOrUpdate(p => p.Id,
            new Items { Id = 0, ItemName = "Bacon", Type = "Pig", Price = 2, Description = "Tasty pork product. Price per lbs.", Quantity = 20 },
            new Items { Id = 1, ItemName = "Baloney", Type = "Pig", Price = 1, Description = "Eat fried or straight out of the package. Price per unit.", Quantity = 20 },
            new Items
            {
                Id = 2,
                ItemName = "Beef Ribs",
                Type = "Cow",
                Price = 13,
                Description = "Ribs are finger licking good. Price per slab.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 3,
                ItemName = "Beef Tbone Steak",
                Type = "Cow",
                Price = 4,
                Description = "Great grilled or baked. Price per lbs.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 4,
                ItemName = "Brisket",
                Type = "Cow",
                Price = 11,
                Description = "Slow cook to perfection. Price per unit.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 5,
                ItemName = "Chicken Breast",
                Type = "Chicken",
                Price = 3,
                Description = "Grill or bake for best results. Price per lbs.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 6,
                ItemName = "Chicken Strips",
                Type = "Chicken",
                Price = 2,
                Description = "Great pan fried. Price per lbs.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 7,
                ItemName = "Chicken Whole",
                Type = "Chicken",
                Price = 15,
                Description = "Better than getting a bucket's worth. Price per unit.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 8,
                ItemName = "Chicken Wings",
                Type = "Chicken",
                Price = 2,
                Description = "All the spice combinations. Price per lbs.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 9,
                ItemName = "Ham",
                Type = "Pig",
                Price = 18,
                Description = "Bake in oven for supreme deliciousness. Price per unit.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 10,
                ItemName = "Hamburger",
                Type = "Cow",
                Price = 3,
                Description = "80/20. Price per lbs.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 11,
                ItemName = "Hot Dogs",
                Type = "Pig",
                Price = 1,
                Description = "Grill or boil to enhance meal. Price per unit.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 12,
                ItemName = "Pork Chops",
                Type = "Pig",
                Price = 2,
                Description = "Bake to enhance flavor. Price per lbs.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 13,
                ItemName = "Pork Tenderloin",
                Type = "Pig",
                Price = 9,
                Description = "Scrumptious. Price per unit.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 14,
                ItemName = "Rib Eye Steak",
                Type = "Cow",
                Price = 4,
                Description = "Marbled beef. Price per lbs.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 15,
                ItemName = "Salmon Can",
                Type = "Fish",
                Price = 2,
                Description = "Great for salmon croquet. Price per unit.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 16,
                ItemName = "Salmon Raw",
                Type = "Fish",
                Price = 2,
                Description = "Best pan fried or baked. Price per lbs.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 17,
                ItemName = "Top Sirloin Steak",
                Type = "Cow",
                Price = 4,
                Description = "Awesome treat yo' self food. Price per lbs.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 18,
                ItemName = "Tuna Can",
                Type = "Fish",
                Price = 1,
                Description = "Great for sandwiches or dip. Price per unit.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 19,
                ItemName = "Turkey Sliced",
                Type = "Turkey",
                Price = 2,
                Description = "Don't let this dry out. Price per unit.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 20,
                ItemName = "Turkey Whole",
                Type = "Turkey",
                Price = 18,
                Description = "Do not under cook. Price per unit.",
                Quantity = 20,
                Food = "Meat"
            },
            new Items
            {
                Id = 21,
                ItemName = "Banana",
                Type = "Fruit",
                Price = 2,
                Description = "Open from either side. Price per unit.",
                Quantity = 20,
                Food = "Plant"
            },
            new Items
            {
                Id = 22,
                ItemName = "Blackberry",
                Type = "Fruit",
                Price = 2,
                Description = "Fresh from the bush. Price per unit.",
                Quantity = 20,
                Food = "Plant"
            },
                new Items
                {
                    Id = 23,
                    ItemName = "Broccoli",
                    Type = "Vegetable",
                    Price = 2,
                    Description = "Best eaten before bloom. Price per unit.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 24,
                    ItemName = "Brown Rice",
                    Type = "Grain",
                    Price = 3,
                    Description = "Great for many meals. Price per lbs.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 25,
                    ItemName = "Carrot",
                    Type = "Vegetable",
                    Price = 1,
                    Description = "Tasty in stews or raw. Price per bunch.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 26,
                    ItemName = "Celery",
                    Type = "Vegetable",
                    Price = 2,
                    Description = "Stringy. Burns a lot of calories. Price per unit.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 27,
                    ItemName = "Cucumber",
                    Type = "Vegetable",
                    Price = 1,
                    Description = "Tasty on salads. Price per unit.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 28,
                    ItemName = "Edamame Beans",
                    Type = "Vegetable",
                    Price = 3,
                    Description = "Great source of protein. Price per unit.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 29,
                    ItemName = "Ginger",
                    Type = "Vegetable",
                    Price = 2,
                    Description = "Great spice or soup addition. Price per unit.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 30,
                    ItemName = "Green Apple",
                    Type = "Fruit",
                    Price = 5,
                    Description = "Granny Smith. Crisp Price per bag.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 31,
                    ItemName = "Green Bean Can",
                    Type = "Vegetable",
                    Price = 1,
                    Description = "Freshness sealed in. Price per unit.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 32,
                    ItemName = "Green Pepper",
                    Type = "Vegetable",
                    Price = 1,
                    Description = "Stuff with rice or slice up for salad. Price per unit.",
                    Quantity = 20,
                    Food = "Plant"
                }, new Items
                {
                    Id = 33,
                    ItemName = "Kidney Beans Can",
                    Type = "Vegetable",
                    Price = 1,
                    Description = "Good with rice. Price per unit.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 34,
                    ItemName = "Onion",
                    Type = "Vegetable",
                    Price = 1,
                    Description = "Add to soup, stew, or salsa. Price per unit.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 35,
                    ItemName = "Pineapple Can",
                    Type = "Fruit",
                    Price = 1,
                    Description = "Pairs well with cottage cheese. Price per unit.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 36,
                    ItemName = "Potato",
                    Type = "Vegetable",
                    Price = 4,
                    Description = "Pleasant source of potassium. Price per bag.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 37,
                    ItemName = "Pumpkin Can",
                    Type = "Fruit",
                    Price = 2,
                    Description = "Pumpkin muffins or pie is great year round. Price per unit.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 38,
                    ItemName = "Red Apple",
                    Type = "Fruit",
                    Price = 4,
                    Description = "Tastes almost as great as the green kind. Price per bag.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 39,
                    ItemName = "Rye Bread",
                    Type = "Grain",
                    Price = 1,
                    Description = "Chaulked full of fiber. Price per unit.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 40,
                    ItemName = "Salsa",
                    Type = "Vegetable",
                    Price = 2,
                    Description = "Goes great with rice and sour cream. Price per unit.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 41,
                    ItemName = "Sphaghetti Squash",
                    Type = "Vegetable",
                    Price = 2,
                    Description = "Meal in itself. Price per lbs.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 42,
                    ItemName = "Strawberry",
                    Type = "Fruit",
                    Price = 2,
                    Description = "Slice up in tea or water. Price per unit.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 43,
                    ItemName = "Sweet Potato",
                    Type = "Vegetable",
                    Price = 1,
                    Description = "One of the best spuds around. Price per lbs.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 44,
                    ItemName = "Tortilla",
                    Type = "Grain",
                    Price = 2,
                    Description = "Make burritos at any time. Price per unit.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 45,
                    ItemName = "Wheat Bread",
                    Type = "Grain",
                    Price = 1,
                    Description = "Healthy source of fiber. Price per unit.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 46,
                    ItemName = "White Bread",
                    Type = "Grain",
                    Price = 1,
                    Description = "Bleached grain. Price per unit.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 47,
                    ItemName = "White Rice",
                    Type = "Grain",
                    Price = 2,
                    Description = "Add to any soup or stew to feel full. Price per lbs.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 48,
                    ItemName = "Yellow Squash",
                    Type = "Vegetable",
                    Price = 1,
                    Description = "Best fried. Price per lbs.",
                    Quantity = 20,
                    Food = "Plant"
                },
                new Items
                {
                    Id = 49,
                    ItemName = "Butter",
                    Type = "Ingredient",
                    Price = 1,
                    Description = "Used in lots of recipes. Price per lbs.",
                    Quantity = 20,
                    Food = "Ingredient"
                },
                new Items
                {
                    Id = 50,
                    ItemName = "Chicken Eggs",
                    Type = "Ingredient",
                    Price = 3,
                    Description = "Binding agent. Price per dozen.",
                    Quantity = 20,
                    Food = "Ingredient"
                },
                new Items
                {
                    Id = 51,
                    ItemName = "Cottage Cheese",
                    Type = "Ingredient",
                    Price = 3,
                    Description = "Great in lasanga or with fruit. Price per unit.",
                    Quantity = 20,
                    Food = "Ingredient"
                },
                new Items
                {
                    Id = 52,
                    ItemName = "Cream Cheese",
                    Type = "Ingredient",
                    Price = 2,
                    Description = "Use to make things creamy. Price per unit.",
                    Quantity = 20,
                    Food = "Ingredient"
                },
                new Items
                {
                    Id = 53,
                    ItemName = "Flour",
                    Type = "Ingredient",
                    Price = 4,
                    Description = "Base of making baking goods. Price per unit.",
                    Quantity = 20,
                    Food = "Ingredient"
                },
                new Items
                {
                    Id = 54,
                    ItemName = "Milk",
                    Type = "Ingredient",
                    Price = 3,
                    Description = "Great source of calcium. Price per gallon.",
                    Quantity = 20,
                    Food = "Ingredient"
                },
                new Items
                {
                    Id = 55,
                    ItemName = "Olive Oil",
                    Type = "Ingredient",
                    Price = 4,
                    Description = "Perfect for frying or salads. Price per unit.",
                    Quantity = 20,
                    Food = "Ingredient"
                },
                new Items
                {
                    Id = 56,
                    ItemName = "Pepper",
                    Type = "Spice",
                    Price = 1,
                    Description = "Great on cottage cheese and potatoes. Price per unit.",
                    Quantity = 20,
                    Food = "Ingredient"
                },
                new Items
                {
                    Id = 57,
                    ItemName = "Red Pepper",
                    Type = "Spice",
                    Price = 1,
                    Description = "Very Spicy. Price per unit.",
                    Quantity = 20,
                    Food = "Ingredient"
                },
                new Items
                {
                    Id = 58,
                    ItemName = "Salt",
                    Type = "Spice",
                    Price = 1,
                    Description = "Sodium tastes great on most things. Price per unit.",
                    Quantity = 20,
                    Food = "Ingredient"
                },
                new Items
                {
                    Id = 59,
                    ItemName = "Sour Cream",
                    Type = "Ingredient",
                    Price = 3,
                    Description = "Tastes great on potatoes, with tuna, or as dip. Price per unit.",
                    Quantity = 20,
                    Food = "Ingredient"
                },
            new Items
            {
                Id = 60,
                ItemName = "Vegetable Broth",
                Type = "Ingredient",
                Price = 3,
                Description = "Base of many different recipes. Price per unit.",
                Quantity = 20,
                Food = "Ingredient"
            });
            context.SaveChanges();
        }
    }
}