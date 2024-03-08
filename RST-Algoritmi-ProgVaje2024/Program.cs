using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace RST_Algoritmi_ProgVaje2024
{
    /// <summary>
    /// V ta projekt zapisujemo programsko kodo, 
    /// ki jo razvijamo v sklopu predavanj in vaj 
    /// pri predmetu Algoritmi na magistrskem študiju
    /// Računalništva in spletnih tehnologij na 
    /// Fakulteti za informacijske študije v Novem mestu.
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            // Preverjanje izvedbe zanke po Matejevem komentarju:
            //HitrostiZank();

            // V prvem sklopu vaj pripravljamo kodo za
            // reševanje problema minimalnega vpetega drevesa v uteženih,
            // neusmerjenih grafih.

            // Začnimo s testiranjem funkcij v razredu graf
            TestiranjeGrafov();

            Console.Read();
        }

        private static void TestiranjeGrafov()
        {
            // Pripravimo primer grafa
            Graph mojGraf = new Graph(4);
            mojGraf.Edges.Add(new Edge(0, 1, 3));
            mojGraf.Edges.Add(new Edge(1, 2, 1));
            mojGraf.Edges.Add(new Edge(2, 3, 4));
            mojGraf.Edges.Add(new Edge(3, 0, 2));

            double sum = mojGraf.MinimalSpanningTreeByPrim();
            Console.WriteLine($"Minimalno vpeto drevo ima vrednost:{sum}");

            Console.WriteLine($"Naš graf je naslednji:\n{mojGraf}\n");

            // Kreiramo slučajne grafe, dokler ne dobimo povezanega:
            int n = 10000;
            int m = 15000;
            Graph rndGraf = Graph.CreateRandomGraph(n, m, isConnected: true, weightUpperBound: 20);
            Stopwatch sw = Stopwatch.StartNew();
            sum = rndGraf.MinimalSpanningTreeByPrim();
            Console.WriteLine($"Minimalno vpeto drevo ima vrednost:{sum} (Čas izvajanja: {sw.Elapsed.TotalSeconds:0.00})");


            Console.WriteLine($"Izvedba Primovega algoritma na grafu da vrednost: ");
        }

        private static void HitrostiZank()
        {
            // Test hitrosti izvajanja zanke:
            List<int> lstLongList = Enumerable.Range(0, 1_000_000_000).ToList();
            long dummy = 3;
            Stopwatch sw = Stopwatch.StartNew();
            // V tej zanki se v vsakem koraku pridobi lastnost length,
            // zato je počasnejša
            for (int i = 0; i < lstLongList.Count; i++)
            {
                dummy *= dummy;
            }
            Console.WriteLine($"{dummy}");
            Console.WriteLine($"Izvedba zanke navzgor: {sw.Elapsed.TotalSeconds:0.#####}");

            dummy = 3;
            sw = Stopwatch.StartNew();
            // V tej zanki length pridobimo le prvikrat,
            // zato je hitrejša
            for (int i = lstLongList.Count - 1; i >= 0; i--)
            {
                dummy *= dummy;
            }
            Console.WriteLine($"{dummy}");
            Console.WriteLine($"Izvedba zanke navzdol: {sw.Elapsed.TotalSeconds:0.#####}");

            dummy = 3;
            int length = lstLongList.Count; // Shranimo si lastnost v spremenljivko
            sw = Stopwatch.StartNew();
            // V tej lastnosti length ne pridobimo, ker smo si jo shranili že zgoraj.
            // Hitrost izvedbe je enaka kot v prejšnjem primeru.
            for (int i = length - 1; i >= 0; i--)
            {
                dummy *= dummy;
            }
            Console.WriteLine($"{dummy}");
            Console.WriteLine($"Izvedba zanke navzgor, vendar s shranjeno lastnostjo: {sw.Elapsed.TotalSeconds:0.#####}");

            Console.Read();
        }
    }
}