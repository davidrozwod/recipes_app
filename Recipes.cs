using SQLite;

namespace RecipesApp
{
    public class Recipes
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set;}
        public string Title { get; set; }
        public string Creator { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
        public string Notes {get; set; }
    }
}
