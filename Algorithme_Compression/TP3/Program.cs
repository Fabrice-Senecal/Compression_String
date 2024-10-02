// <copyright file="Program.cs" company="cstjean.qc.ca">
// Fabrice Senecal
// </copyright>
namespace TP3
{
    /// <summary>
    /// Classe exécutant le programme. Elle contiens
    /// donc les tests du code de l'algorithme 1.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Algorithme 1

            // Tout les strings utilisé pour faire les tests.
            string ex1 = "AAAABBBCCD";
            string ex2 = "AAAABBBCCCCD";
            string ex3 = "ABBBCDDDE";
            string ex4 = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod " +
                "tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, " +
                "quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in " +
                "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur." +
                " Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt" +
                " mollit anim id est laborum.";

            // Tests effectué sur la première string.
            Console.WriteLine(ex1);

            var algoCompression1 = new Algorithme_1();

            string ex1Compresse = algoCompression1.CompressionComplete(ex1);

            Console.WriteLine(ex1Compresse);
            Console.WriteLine(ex1Compresse.Count());
            Console.WriteLine(algoCompression1.DecompresseMessage(ex1Compresse) + "\n");

            // Tests effectué sur la deuxième string.
            Console.WriteLine(ex2);

            var algoCompression2 = new Algorithme_1();

            string ex2Compresse = algoCompression2.CompressionComplete(ex2);

            Console.WriteLine(ex2Compresse);
            Console.WriteLine(ex2Compresse.Count());
            Console.WriteLine(algoCompression2.DecompresseMessage(ex2Compresse) + "\n");

            // Tests effectué sur la troisième string.
            Console.WriteLine(ex3);

            var algoCompression3 = new Algorithme_1();

            string ex3Compresse = algoCompression3.CompressionComplete(ex3);

            Console.WriteLine(ex3Compresse);
            Console.WriteLine(ex3Compresse.Count());
            Console.WriteLine(algoCompression3.DecompresseMessage(ex3Compresse) + "\n");

            // Tests effectué sur la quatrième string.
            Console.WriteLine(ex4);

            var algoCompression4 = new Algorithme_1();

            string ex4Compresse = algoCompression4.CompressionComplete(ex4);

            Console.WriteLine(ex4Compresse);
            Console.WriteLine(ex4Compresse.Count());
            Console.WriteLine(algoCompression4.DecompresseMessage(ex4Compresse) + "\n");

            // Algorithme 2

            /* Let us create the example graph discussed above */
            int[,] graph = new int[,]
            {
                { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                { 0, 0, 4, 14, 10, 0, 2, 0, 0 },
                { 0, 0, 0, 0, 0, 2, 0, 1, 6 },
                { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                { 0, 0, 2, 0, 0, 0, 6, 7, 0 },
            };
            Algorithme_2 t = new Algorithme_2();
            t.Dijkstra(graph, 0);
        }
    }
}
