namespace Exercice4
{
    public class Produit
    {
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public int Stock { get; set; }

        public Produit(string nom, decimal prix, int stock)
        {
            Nom = nom;
            Prix = prix;
            Stock = stock;
        }

        public void AjouterStock(int quantite)
        {
            if (quantite > 0)
            {
                Stock += quantite;
                Console.WriteLine($"{quantite} unité(s) ajoutée(s) au stock de {Nom}.");
            }
        }

        public bool RetirerStock(int quantite)
        {
            if (quantite <= 0) return false;
            if (quantite > Stock) return false;

            Stock -= quantite;
            return true;
        }

        public decimal Acheter(int quantite)
        {
            if (quantite <= 0) return -1;
            if (quantite > Stock) return -1;

            decimal total = quantite * Prix;
            RetirerStock(quantite);
            return total;
        }
    }

    public class Magasin
    {
        public string Nom { get; set; }
        private List<Produit> produits = new List<Produit>();

        public Magasin(string nom)
        {
            Nom = nom;
        }

        public void AjouterProduit(Produit p)
        {
            produits.Add(p);
            Console.WriteLine($"{p.Nom} ajouté au magasin.");
        }

        public void AfficherProduits()
        {
            Console.WriteLine($"\nProduits du magasin {Nom} :");
            foreach (Produit produit in produits)
            {
                Console.WriteLine($"  - {produit.Nom} : {produit.Prix}€ (Stock : {produit.Stock})");
            }
        }

        public Produit TrouverProduit(string nom)
        {
            foreach (Produit produit in produits)
            {
                if (produit.Nom == nom)
                    return produit;
            }
            return null;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Magasin magasin = new Magasin("GameStop");

            Produit manette  = new Produit("Manette PS5",   69.99m, 15);
            Produit casque   = new Produit("Casque Gaming", 49.99m, 8);
            Produit clavier  = new Produit("Clavier Meca",  89.99m, 5);

            magasin.AjouterProduit(manette);
            magasin.AjouterProduit(casque);
            magasin.AjouterProduit(clavier);
            magasin.AfficherProduits();

            // Achat de 3 manettes
            Produit p = magasin.TrouverProduit("Manette PS5");
            decimal total = p.Acheter(3);
            Console.WriteLine($"Total achat manettes : {total}€");

            // Tentative d'achat avec stock insuffisant
            Produit p2 = magasin.TrouverProduit("Clavier Meca");
            decimal total2 = p2.Acheter(10);
            if (total2 == -1)
                Console.WriteLine("Achat impossible : stock insuffisant.");

            // Réapprovisionnement
            casque.AjouterStock(20);

            magasin.AfficherProduits();
        }
    }
}
