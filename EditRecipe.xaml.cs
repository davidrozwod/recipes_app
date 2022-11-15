using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace RecipesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditRecipe : ContentPage
    {
        public int BackCount = 2;
        public EditRecipe()
        {
            InitializeComponent();
        }

        private async void Save_Clicked(object sender, System.EventArgs e)
        {
            var personItem = (Recipes)BindingContext;
            await App.Database.SaveRecipesAsync(personItem);
            for (var counter = 1; counter < BackCount; counter++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
            await Navigation.PopAsync();
        }

        private async void Delete_Clicked(object sender, System.EventArgs e)
        {
            var personItem = (Recipes)BindingContext;
            await App.Database.DeleteEmployeeAsync(personItem);
            for (var counter = 1; counter < BackCount; counter++)
            {
                Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
            }
            await Navigation.PopAsync();
        }
    }
}