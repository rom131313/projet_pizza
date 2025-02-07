using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projet_pizza
{

    // PizzaPersonnalise 
    // - CLasse : hériter de Pizza 
    //:constructeur 
    // nom = "Personnalisée"
    // prix - 5
    // vegetarienne - false 
    // ingrédients ) demander à l'utilisateur 
    // Rentrez un ingrédient pour la pizza personalisée (ENTER pour terminer) : 

    class PizzaPersonnalisee : Pizza
    {
        public PizzaPersonnalisee(): base("Personnalisee", 5, false, null)
        {
            ingredients = new List<string>();

            while (true)
            {
                Console.Write("Rentrez un ingrédient pour la pizza personnalisée (ENTER pour terminer) : ");
                var ingredient = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ingredient))
                {
                    break;
                }
                ingredients.Add(ingredient);
            }

        }
    }

    class Pizza
    {
        string nom;
        public float prix { get; private set; }
        public bool vegetarienne { get; private set; }
        public List<string> ingredients { get; protected set; }

        public Pizza(string nom, float prix, bool vegetarienne, List<string> ingredients)
        {
            this.nom = nom;
            this.prix = prix;
            this.vegetarienne = vegetarienne;
            this.ingredients = ingredients;
        }

        public void Afficher()
        {
            //4 fromages (V) - 11.5€
            /*string badgeVegetarienne = " (V)";
            if (!vegetarienne)
            {
                badgeVegetarienne = "";
            }*/

            string badgeVegetarienne = vegetarienne ? " (V)" : "";

            string nomAfficher = FormatPremiereLettreMajuscules(nom);

            /*var ingredientsAfficher = new List<string>();
            foreach(var ingredient in ingredients)
            {
                ingredientsAfficher.Add(FormatPremiereLettreMajuscules(ingredient));
            }*/

            var ingredientsAfficher = ingredients.Select(i => FormatPremiereLettreMajuscules(i)).ToList();

            Console.WriteLine(nomAfficher + badgeVegetarienne + " - " + prix + "€");
            Console.WriteLine(string.Join(", ", ingredientsAfficher));
            Console.WriteLine();

        }

        private static string FormatPremiereLettreMajuscules(string s)
        {
            if (string.IsNullOrEmpty(s))
                return s;

            string minuscules = s.ToLower();
            string majuscules = s.ToUpper();

            string resultat = majuscules[0] + minuscules[1..];

            return resultat;
        }

        public bool ContientIngredient(string ingredient)
        {
            return ingredients.Where(i => i.ToLower().Contains(ingredient)).ToList().Count > 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // ingredients <- Liste string   "mozarella"    "poulet"   "oignon"
            // données
            // Afficher
            // 4 fromages (V) - 11.5€
            // cantal, mozzarella, gruyère, conté
            //
            // ...
            // join


            var pizzas = new List<Pizza>() {
                new Pizza("4 fromages", 11.5f, true, new List<string> { "cantal", "mozzarella", "fromage de chèvre", "gruyère" }),
                new Pizza("indienne", 10.5f, false, new List<string> { "curry", "mozzarella", "poulet", "poivron", "oignon", "coriandre" }),
                new Pizza("MEXICAINE", 13f, false, new List<string> {"boeuf", "mozzarella", "maïs", "tomates", "oignon", "coriandre"}),
                new Pizza("margherita", 8f, true, new List<string> { "sauce tomate", "mozzarella", "basilic" }),
                new Pizza("Calzone", 12f, false, new List<string> { "tomate", "jambon", "persil", "oignons"}),
                new Pizza("complète", 9.5f, false, new List<string> { "jambon", "oeuf", "fromage" }),
                new PizzaPersonnalisee()

            };

            //pizzas = pizzas.Where(p => p.vegetarienne).ToList();
            //pizzas = pizzas.Where(p => p.ContientIngredient("oignon")).ToList();


            foreach (var pizza in pizzas)
            {
                pizza.Afficher();
            }



        }
    }
}
