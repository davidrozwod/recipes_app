using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RecipesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddRecipe : ContentPage
    {
        public AddRecipe()
        {
            InitializeComponent();
        }
        private async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(titleEntry.Text) && !string.IsNullOrWhiteSpace(creatorEntry.Text) && !string.IsNullOrWhiteSpace(ingredientsEntry.Text) && !string.IsNullOrWhiteSpace(stepsEntry.Text))
            {
                await App.Database.SaveRecipesAsync(new Recipes
                {
                    Title = titleEntry.Text,
                    Creator = creatorEntry.Text,
                    Ingredients = ingredientsEntry.Text,
                    Steps = stepsEntry.Text,
                    Notes = notesEntry.Text,
                });

                titleEntry.Text = creatorEntry.Text = ingredientsEntry.Text = stepsEntry.Text = notesEntry.Text = string.Empty;
                await Navigation.PopAsync();
            }
        }
    }
}