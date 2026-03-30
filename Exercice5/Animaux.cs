namespace Exercice5
{
    public class Animal
    {
        public string Nom { get; set; }
        public int Age { get; set; }

        public Animal(string nom, int age)
        {
            Nom = nom;
            Age = age;
        }

        public virtual void FaireBruit()
        {
            Console.WriteLine($"{Nom} fait un bruit.");
        }

        public void Manger(string nourriture)
        {
            Console.WriteLine($"{Nom} mange {nourriture}.");
        }
    }

    public class Chien : Animal
    {
        public Chien(string nom, int age) : base(nom, age) { }

        public override void FaireBruit()
        {
            Console.WriteLine($"{Nom} : Woof! Woof!");
        }
    }

    public class Chat : Animal
    {
        public Chat(string nom, int age) : base(nom, age) { }

        public override void FaireBruit()
        {
            Console.WriteLine($"{Nom} : Miaou!");
        }
    }

    public class Oiseau : Animal
    {
        public string Couleur { get; set; }

        public Oiseau(string nom, int age, string couleur) : base(nom, age)
        {
            Couleur = couleur;
        }

        public override void FaireBruit()
        {
            Console.WriteLine($"{Nom} ({Couleur}) : Piou piou!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Animal[] animaux = new Animal[6];
            animaux[0] = new Chien("Buddy", 4);
            animaux[1] = new Chat("Luna", 2);
            animaux[2] = new Oiseau("Kiwi", 1, "Vert");
            animaux[3] = new Chien("Max", 7);
            animaux[4] = new Chat("Simba", 5);
            animaux[5] = new Oiseau("Sky", 3, "Bleu");

            Console.WriteLine("=== Tour de présentation ===\n");
            foreach (Animal animal in animaux)
            {
                animal.FaireBruit();
                animal.Manger("ses croquettes");
                Console.WriteLine();
            }
        }
    }
}
