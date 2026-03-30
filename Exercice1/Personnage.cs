namespace Exercice1
{
    public class Personnage
    {
        public string Nom { get; set; }
        public string Classe { get; set; }
        public int PointsDeVie { get; set; }
        public int Niveau { get; set; }
        private int experience = 0;

        public Personnage(string nom, string classe, int pointsDeVie, int niveau)
        {
            Nom = nom;
            Classe = classe;
            PointsDeVie = pointsDeVie;
            Niveau = niveau;
        }

        public void Presenter()
        {
            Console.WriteLine($"--- {Nom} ---");
            Console.WriteLine($"Classe : {Classe}");
            Console.WriteLine($"Niveau : {Niveau}");
            Console.WriteLine($"PV : {PointsDeVie}");
            Console.WriteLine($"Expérience : {experience}");
        }

        public void PrendreExp(int exp)
        {
            experience += exp;
            Console.WriteLine($"{Nom} gagne {exp} exp");

            while (experience >= 100)
            {
                experience -= 100;
                Niveau++;
                Console.WriteLine($"{Nom} passe au niveau {Niveau} !");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Personnage p1 = new Personnage("Zara", "Magicienne", 80, 1);
            p1.Presenter();
            p1.PrendreExp(80);
            p1.PrendreExp(60);
            p1.Presenter();

            Console.WriteLine();

            Personnage p2 = new Personnage("Thorin", "Guerrier", 120, 3);
            p2.Presenter();
            p2.PrendreExp(250);
            p2.Presenter();
        }
    }
}
