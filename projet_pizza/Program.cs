using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace projet_pizza
{
    class Pizza
    {
        string nom;
        public float prix { get; private set; }
        bool vegetarienne;
        List<string> ingredients;

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
            };

            //pizzas = pizzas.OrderByDescending(p => p.prix).ToList();

            float prixMin, prixMax;
            Pizza pizzaPrixMin = null;
            Pizza pizzaPrixMax = null;


            pizzaPrixMin = pizzas[0];
            pizzaPrixMax = pizzas[0];

            foreach (var pizza in pizzas)
            {
                if (pizza.prix < pizzaPrixMin.prix)
                {
                    pizzaPrixMin = pizza;
                }
                if (pizza.prix > pizzaPrixMax.prix)
                {
                    pizzaPrixMax = pizza;
                }
            }

            foreach (var pizza in pizzas)
            {
                pizza.Afficher();
            }

            Console.WriteLine();
            Console.WriteLine("La pizza la moins chere est :");
            pizzaPrixMin.Afficher();
            Console.WriteLine();
            Console.WriteLine("La pizza la plus chere est : ");
            pizzaPrixMax.Afficher();

        }
    }
}
