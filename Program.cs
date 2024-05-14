using System;
using System.Collections.Generic;

class Recipe
{
    private List<Tuple<string, double, string>> _ingredients = new List<Tuple<string, double, string>>();
    private List<string> _steps = new List<string>();
    private string _name;
    private double _calories;

    public Recipe(string name, double calories)
    {
        _name = name;
        _calories = calories;
    }

    public List<Tuple<string, double, string>> GetIngredients()
    {
        return _ingredients;
    }

    public void SetIngredients(List<Tuple<string, double, string>> newIngredients)
    {
        _ingredients = newIngredients;
    }

    public List<string> GetSteps()
    {
        return _steps;
    }

    public void SetSteps(List<string> newSteps)
    {
        _steps = newSteps;
    }

    public void AddIngredient(string name, double quantity, string unit)
    {
        _ingredients.Add(new Tuple<string, double, string>(name, quantity, unit));
    }

    public void AddStep(string description)
    {
        _steps.Add(description);
    }

    public void DisplayRecipe()
    {
        Console.WriteLine("Recipe Name: " + _name);
        Console.WriteLine("Calories: " + _calories);
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in _ingredients)
        {
            Console.WriteLine($"{ingredient.Item2} {ingredient.Item3} of {ingredient.Item1}");
        }
        Console.WriteLine("\nSteps:");
        for (int i = 0; i < _steps.Count; i++)
        {
            Console.WriteLine($"Step {i + 1}: {_steps[i]}");
        }
    }

    public void ScaleRecipe(double factor)
    {
        for (int i = 0; i < _ingredients.Count; i++)
        {
            _ingredients[i] = new Tuple<string, double, string>(_ingredients[i].Item1, _ingredients[i].Item2 * factor, _ingredients[i].Item3);
        }
    }

    public void ResetQuantities()
    {
        // Not implemented
    }

    public void ClearRecipe()
    {
        _ingredients.Clear();
        _steps.Clear();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter recipe name: ");
        string recipeName = Console.ReadLine();
        Console.Write("Enter recipe calories: ");
        double recipeCalories = Convert.ToDouble(Console.ReadLine());
        Recipe recipe = new Recipe(recipeName, recipeCalories);

        while (true)
        {
            Console.WriteLine("Recipe Manager");
            Console.WriteLine("---------------");
            Console.WriteLine("1. Add ingredient");
            Console.WriteLine("2. Add step");
            Console.WriteLine("3. Display recipe");
            Console.WriteLine("4. Scale recipe");
            Console.WriteLine("5. Reset quantities");
            Console.WriteLine("6. Clear recipe");
            Console.WriteLine("7. Exit");

            Console.Write("Choose an option: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddIngredient(recipe);
                    break;
                case "2":
                    AddStep(recipe);
                    break;
                case "3":
                    DisplayRecipe(recipe);
                    break;
                case "4":
                    ScaleRecipe(recipe);
                    break;
                case "5":
                    ResetQuantities(recipe);
                    break;
                case "6":
                    ClearRecipe(recipe);
                    break;
                case "7":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
        }
    }

    static void AddIngredient(Recipe recipe)
    {
        Console.Write("Enter ingredient name: ");
        string name = Console.ReadLine();
        Console.Write("Enter quantity: ");
        double quantity = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter unit (e.g. cup, gram, etc.): ");
        string unit = Console.ReadLine();
        recipe.AddIngredient(name, quantity, unit);
    }

    static void AddStep(Recipe recipe)
    {
        Console.Write("Enter step description: ");
        string description = Console.ReadLine();
        recipe.AddStep(description);
    }

    static void DisplayRecipe(Recipe recipe)
    {
        recipe.DisplayRecipe();
    }

    static void ScaleRecipe(Recipe recipe)
    {
        Console.Write("Enter scaling factor: ");
        double factor = Convert.ToDouble(Console.ReadLine());
        recipe.ScaleRecipe(factor);
    }

    static void ResetQuantities(Recipe recipe)
    {
        // Not implemented
    }

    static void ClearRecipe(Recipe recipe)
    {
        recipe.ClearRecipe();
    }
}