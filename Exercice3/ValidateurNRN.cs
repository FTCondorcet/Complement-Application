namespace Exercice3
{
    public class ValidateurNRN
    {
        public static bool Valider(string nrn)
        {
            // 1. Vérifier la longueur
            if (nrn == null || nrn.Length != 11)
            {
                Console.WriteLine("Invalide : le NRN doit contenir 11 chiffres.");
                return false;
            }

            // 2. Vérifier que tous les caractères sont des chiffres
            for (int i = 0; i < 11; i++)
            {
                if (!char.IsDigit(nrn[i]))
                {
                    Console.WriteLine("Invalide : le NRN doit contenir uniquement des chiffres.");
                    return false;
                }
            }

            // 3. Extraire les parties
            string mois     = nrn.Substring(2, 2);
            string jour     = nrn.Substring(4, 2);
            string checksum = nrn.Substring(9, 2);

            int moisInt = int.Parse(mois);
            int jourInt = int.Parse(jour);

            // 4. Vérifier le mois
            if (moisInt < 1 || moisInt > 12)
            {
                Console.WriteLine($"Invalide : le mois ({moisInt}) doit être entre 01 et 12.");
                return false;
            }

            // 5. Vérifier le jour
            if (jourInt < 1 || jourInt > 31)
            {
                Console.WriteLine($"Invalide : le jour ({jourInt}) doit être entre 01 et 31.");
                return false;
            }

            // 6. Vérifier le checksum
            long nrnSansChecksum    = long.Parse(nrn.Substring(0, 9));
            int checksumCalcule     = (int)(97 - (nrnSansChecksum % 97));
            int checksumFourni      = int.Parse(checksum);

            if (checksumCalcule != checksumFourni)
            {
                Console.WriteLine($"Invalide : checksum incorrect (attendu {checksumCalcule}, reçu {checksumFourni}).");
                return false;
            }

            Console.WriteLine("NRN valide !");
            return true;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ValidateurNRN.Valider("85051822361"); // Valide
            ValidateurNRN.Valider("85131822361"); // Invalide : mois 13
            ValidateurNRN.Valider("85053222361"); // Invalide : jour 32
            ValidateurNRN.Valider("8505182236");  // Invalide : 10 chiffres
        }
    }
}
