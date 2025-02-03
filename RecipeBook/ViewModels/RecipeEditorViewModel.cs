using System.Windows;
using RecipeBook.Models;
using RecipeBook.Helpers;

namespace RecipeBook.ViewModels
{
    public class RecipeEditorViewModel : BaseViewModel
    {
        public Recipe Recipe { get; set; }
        public Recipe CurrentRecipe { get; set; }
        public RelayCommand SaveCommand { get; }

        private readonly Recipe _originalRecipe;

        public RecipeEditorViewModel(Recipe recipe)
        {
            _originalRecipe = recipe;
            Recipe = new Recipe
            {
                Name = recipe.Name,
                Category = recipe.Category,
                Cuisine = recipe.Cuisine,
                Ingredients = recipe.Ingredients,
                Instructions = recipe.Instructions
            };
            CurrentRecipe = recipe;
            SaveCommand = new RelayCommand(SaveRecipe);
        }

        private void SaveRecipe()
        {
            _originalRecipe.Name = Recipe.Name;
            _originalRecipe.Category = Recipe.Category;
            _originalRecipe.Cuisine = Recipe.Cuisine;
            _originalRecipe.Ingredients = Recipe.Ingredients;
            _originalRecipe.Instructions = Recipe.Instructions;

            Application.Current.Windows[1].Close();
        }
    }
}