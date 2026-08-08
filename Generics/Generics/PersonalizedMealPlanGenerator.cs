using System;

namespace Generics
{
    interface IMealPlan
    {
        void Display();
    }

    class VegetarianMeal : IMealPlan
    {
        public void Display()
        {
            Console.WriteLine(
                "Vegetarian: Paneer, Rice, Vegetables");
        }
    }

    class VeganMeal : IMealPlan
    {
        public void Display()
        {
            Console.WriteLine(
                "Vegan: Tofu, Rice, Salad");
        }
    }

    class KetoMeal : IMealPlan
    {
        public void Display()
        {
            Console.WriteLine(
                "Keto: Eggs, Chicken, Avocado");
        }
    }

    class Meal<T> where T : IMealPlan
    {
        private T meal;

        public Meal(T meal)
        {
            this.meal = meal;
        }

        public void Display()
        {
            meal.Display();
        }
    }

    class MealGenerator
    {
        public T Generate<T>()
            where T : IMealPlan, new()
        {
            return new T();
        }
    }

    public class PersonalizedMealPlanGenerator
    {
        public static void Run()
        {
            MealGenerator generator =
                new MealGenerator();

            VegetarianMeal vegetarian =
                generator.Generate<VegetarianMeal>();

            VeganMeal vegan =
                generator.Generate<VeganMeal>();

            KetoMeal keto =
                generator.Generate<KetoMeal>();

            Meal<VegetarianMeal> meal1 =
                new Meal<VegetarianMeal>(vegetarian);

            Meal<VeganMeal> meal2 =
                new Meal<VeganMeal>(vegan);

            Meal<KetoMeal> meal3 =
                new Meal<KetoMeal>(keto);

            meal1.Display();
            meal2.Display();
            meal3.Display();
        }
    }
}