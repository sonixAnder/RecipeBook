using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using RecipeBook.Models;
using RecipeBook.Helpers;
using RecipeBook.Views;

namespace RecipeBook.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Recipe> Recipes { get; set; }
        public Recipe SelectedRecipe { get; set; }

        public RelayCommand EditRecipeCommand { get; }
        public RelayCommand DeleteRecipeCommand { get; }
        public RelayCommand AddRecipeCommand { get; }
        public RelayCommand ExportToWordCommand { get; }
        public RelayCommand ExportToPdfCommand { get; }

        public MainViewModel()
        {
            Recipes = new ObservableCollection<Recipe>
            {
                new Recipe { Name = "Суп", Category = "Первые блюда", Cuisine = "Русская" },
                new Recipe { Name = "Салат Цезарь", Category = "Салаты", Cuisine = "Итальянская" }
            };

            EditRecipeCommand = new RelayCommand(EditRecipe);
            DeleteRecipeCommand = new RelayCommand(DeleteRecipe);
            AddRecipeCommand = new RelayCommand(AddRecipe);
            ExportToWordCommand = new RelayCommand(ExportToWord);
            //ExportToPdfCommand = new RelayCommand(ExportToPdf);
        }

        private void EditRecipe()
        {
            if (SelectedRecipe != null)
            {
                var editorWindow = new RecipeEditor
                {
                    DataContext = new RecipeEditorViewModel(SelectedRecipe)
                };
                editorWindow.ShowDialog();

                UpdateRecipe(SelectedRecipe);
            }
        }

        private void DeleteRecipe()
        {
            if (SelectedRecipe != null)
            {
                Recipes.Remove(SelectedRecipe);
            }
        }

        private void AddRecipe()
        {
            var addRecipeWindow = new AddRecipe();
            addRecipeWindow.ShowDialog();
        }

        private void UpdateRecipe(Recipe updatedRecipe)
        {
            var recipe = Recipes.FirstOrDefault(r => r.Name == updatedRecipe.Name);
            if (recipe != null)
            {
                recipe.Name = updatedRecipe.Name;
                recipe.Category = updatedRecipe.Category;
                recipe.Cuisine = updatedRecipe.Cuisine;
                recipe.Ingredients = updatedRecipe.Ingredients;
                recipe.Instructions = updatedRecipe.Instructions;
            }
        }

        private void ExportToWord()
        {
            if (SelectedRecipe != null)
            {
                string filePath = "C:\\path\\to\\recipe.docx";
                ExportHelper.ExportToWord(SelectedRecipe, filePath);
                MessageBox.Show($"Рецепт экспортирован в {filePath}");
            }
        }

        //private void ExportToPdf()
        //{
            //if (SelectedRecipe != null)
            //{
                //string filePath = "C:\\path\\to\\recipe.pdf";
                //ExportHelper.ExportToPdf(SelectedRecipe, filePath);
                //MessageBox.Show($"Рецепт экспортирован в {filePath}");
            //}
        //}
    }
}