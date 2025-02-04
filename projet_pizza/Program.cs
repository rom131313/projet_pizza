using System;
using System.Text;

namespace MyApp
{
    class Pizza
    {
        string nom;
        float prix;
        bool vegetarienne;

        public Pizza(string nom, float prix, bool vegetarienne)
        {
            this.nom = nom;
            this.prix = prix;
            this.vegetarienne = vegetarienne;
        }

        public void Afficher()
        {
            /*string badgeVegetarienne = " (V)";
            if (!vegetarienne)
            {
                badgeVegetarienne = "";
            }
            Console.WriteLine(nom + badgeVegetarienne +  " - " + prix + "€");*/
            string badgeVegetarienne = vegetarienne ? " (V)" : "";
            Console.WriteLine(nom + badgeVegetarienne + " - " + prix + "€");
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Clas Pizza
            // nom (4 fromages)
            // prix : 11.5
            // vegetarienne (vrai ou faux)
            // Constructeur 
            // Afficher
            // 4 fromages (V) - 11.5
            // Créer une liste de pizzas
            // boucler pour afficher les pizzas

            //var pizza1 = new Pizza("4 fromages", 11.5f, true);
            //pizza1.Afficher();

            var listePizzas = new List<Pizza>()
            {
                new Pizza("4 fromages", 11.5f, true),
                new Pizza("indienne", 10.5f, false),
                new Pizza("mexicaine", 13f, false),
                new Pizza("margherita", 8f, true),
                new Pizza("calzone", 12f, false),
                new Pizza("complète", 9.5f, false),
            };

            foreach (var pizza in listePizzas)
            {
                pizza.Afficher(); 
            }
        }
    }
}