using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotossimoV9.Utils
{
    internal class Utils
    {
        // Entrée : Une chaîne de la forme "1, 2, 3, 4" qui provient de la BDD.
        // Sortie : Une liste de int qui réprésente l'id de chaque tags dans la BDD.
        public static List<int> ParseNumbers(string input)
        {
            // On découpe la chaîne en se basant sur la virgule,
            // on retire les espaces inutiles et on convertit chaque élément en entier.
            List<int> numbers = input
                .Split(',')
                .Select(s => int.Parse(s.Trim()))
                .ToList();

            return numbers;

        }

        // Entrée : Une liste de int qui réprésente l'id de chaque tags dans la BDD.
        // Sortie : Une chaîne de la forme "1, 2, 3, 4" qui sera envoyé dans la BDD.
        public static string ParseListToString(List<int> numbers)
        {
            return string.Join(", ", numbers);
        }
    }
}
