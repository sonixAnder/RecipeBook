using RecipeBook.Models;
using RecipeBook.Helpers;
using System.Windows;

namespace RecipeBook.ViewModels
{
    public class AddRecipeViewModel : BaseViewModel
    {
        public Recipe NewRecipe { get; set; }
        public RelayCommand SaveCommand { get; }

        public AddRecipeViewModel()
        {
            NewRecipe = new Recipe();
            SaveCommand = new RelayCommand(SaveRecipe);
        }

        private void SaveRecipe()
        {
            // Добавляем новый рецепт в коллекцию в MainViewModel
            if (Application.Current.Windows[0].DataContext is MainViewModel mainViewModel)
            {
                mainViewModel.Recipes.Add(NewRecipe);
            }

            // Закрываем окно добавления рецепта
            Application.Current.Windows[1].Close();
        }
    }
}