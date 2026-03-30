namespace Exercice6
{
    public class Etudiant
    {
        public string Nom { get; set; }
        public string Matricule { get; set; }
        private List<decimal> notes = new List<decimal>();

        public Etudiant(string nom, string matricule)
        {
            Nom = nom;
            Matricule = matricule;
        }

        public void AjouterNote(decimal note)
        {
            if (note >= 0 && note <= 20)
            {
                notes.Add(note);
                Console.WriteLine($"Note {note} ajoutée à {Nom}.");
            }
            else
            {
                Console.WriteLine("La note doit être entre 0 et 20.");
            }
        }

        public decimal CalculerMoyenne()
        {
            if (notes.Count == 0) return 0;

            decimal somme = 0;
            foreach (decimal note in notes)
            {
                somme += note;
            }
            return somme / notes.Count;
        }

        public bool Reussi()
        {
            return CalculerMoyenne() >= 12;
        }

        public void Afficher()
        {
            decimal moyenne = CalculerMoyenne();
            string statut = Reussi() ? "Réussi" : "Échoué";
            Console.WriteLine($"{Nom} ({Matricule}) - Moyenne : {moyenne:F2} - {statut}");
        }
    }

    public class Classe
    {
        public string Nom { get; set; }
        private List<Etudiant> etudiants = new List<Etudiant>();

        public Classe(string nom)
        {
            Nom = nom;
        }

        public void AjouterEtudiant(Etudiant e)
        {
            etudiants.Add(e);
        }

        public decimal MoyenneClasse()
        {
            if (etudiants.Count == 0) return 0;

            decimal sommeMoyennes = 0;
            foreach (Etudiant etudiant in etudiants)
            {
                sommeMoyennes += etudiant.CalculerMoyenne();
            }
            return sommeMoyennes / etudiants.Count;
        }

        public Etudiant MeilleurEtudiant()
        {
            if (etudiants.Count == 0) return null;

            Etudiant meilleur = etudiants[0];
            foreach (Etudiant etudiant in etudiants)
            {
                if (etudiant.CalculerMoyenne() > meilleur.CalculerMoyenne())
                    meilleur = etudiant;
            }
            return meilleur;
        }

        public int NbReussis()
        {
            int compte = 0;
            foreach (Etudiant etudiant in etudiants)
            {
                if (etudiant.Reussi())
                    compte++;
            }
            return compte;
        }

        public void AfficherTous()
        {
            Console.WriteLine($"\nClasse : {Nom}");
            Console.WriteLine("=== Étudiants ===");
            foreach (Etudiant etudiant in etudiants)
            {
                etudiant.Afficher();
            }
            Console.WriteLine($"\nMoyenne de classe : {MoyenneClasse():F2}");
            Console.WriteLine($"Réussis : {NbReussis()}/{etudiants.Count}");
            Console.WriteLine($"Meilleur étudiant : {MeilleurEtudiant().Nom}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Classe classe = new Classe("Bloc 1 - Informatique");

            Etudiant e1 = new Etudiant("Emma Leroy", "INF001");
            e1.AjouterNote(14);
            e1.AjouterNote(17);
            e1.AjouterNote(12);

            Etudiant e2 = new Etudiant("Nathan Petit", "INF002");
            e2.AjouterNote(9);
            e2.AjouterNote(11);
            e2.AjouterNote(8);

            Etudiant e3 = new Etudiant("Léa Bernard", "INF003");
            e3.AjouterNote(15);
            e3.AjouterNote(13);
            e3.AjouterNote(16);

            Etudiant e4 = new Etudiant("Hugo Simon", "INF004");
            e4.AjouterNote(25);   // note invalide
            e4.AjouterNote(12);
            e4.AjouterNote(10);

            classe.AjouterEtudiant(e1);
            classe.AjouterEtudiant(e2);
            classe.AjouterEtudiant(e3);
            classe.AjouterEtudiant(e4);

            classe.AfficherTous();
        }
    }
}
