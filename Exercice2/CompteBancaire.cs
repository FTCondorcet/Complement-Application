namespace Exercice2
{
    public class CompteBancaire
    {
        public string Titulaire { get; set; }
        public string NumeroCompte { get; set; }
        private decimal solde;

        public decimal Solde
        {
            get { return solde; }
        }

        public CompteBancaire(string titulaire, string numeroCompte, decimal soldeInitial)
        {
            Titulaire = titulaire;
            NumeroCompte = numeroCompte;
            solde = soldeInitial;
        }

        public void Deposer(decimal montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("Montant invalide.");
                return;
            }

            solde += montant;
            Console.WriteLine($"Dépôt de {montant}€ effectué.");
        }

        public void Retirer(decimal montant)
        {
            if (montant <= 0)
            {
                Console.WriteLine("Montant invalide.");
                return;
            }

            if (montant > solde)
            {
                Console.WriteLine("Solde insuffisant.");
                return;
            }

            solde -= montant;
            Console.WriteLine($"Retrait de {montant}€ effectué.");
        }

        public void AfficherSolde()
        {
            Console.WriteLine($"Compte {NumeroCompte} - {Titulaire}");
            Console.WriteLine($"Solde : {solde}€");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            CompteBancaire c1 = new CompteBancaire("Sophie Martin", "BE78-4521", 350);
            c1.AfficherSolde();
            c1.Deposer(200);
            c1.Retirer(80);
            c1.Retirer(1000);   // solde insuffisant
            c1.Retirer(-50);    // montant invalide
            c1.AfficherSolde();

            Console.WriteLine();

            CompteBancaire c2 = new CompteBancaire("Lucas Dubois", "BE12-9874", 0);
            c2.AfficherSolde();
            c2.Deposer(500);
            c2.Retirer(500);
            c2.AfficherSolde();
        }
    }
}
