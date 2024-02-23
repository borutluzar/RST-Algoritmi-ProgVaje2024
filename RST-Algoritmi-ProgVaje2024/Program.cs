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
            // V prvem sklopu pripravljamo kodo za
            // reševanje problema minimalnega vpetega drevesa v uteženih,
            // neusmerjenih grafih.


            // Pripravimo primer grafa
            Graph mojGraf = new Graph(4);
            mojGraf.Edges.Add(new Edge(0, 1, 3));
            mojGraf.Edges.Add(new Edge(1, 2, 1));
            mojGraf.Edges.Add(new Edge(2, 3, 4));
            mojGraf.Edges.Add(new Edge(3, 0, 2));

            Console.WriteLine($"Naš graf je naslednji:\n{mojGraf}\n");

            // Kreiramo slučajne grafe, dokler ne dobimo povezanega:
            int n = 100;
            int m = 140;
            Graph rndGraf = Graph.CreateRandomGraph(n, m);

            int stevecPoskusov = 0;
            while (!rndGraf.IsConnected())
            {
                rndGraf = Graph.CreateRandomGraph(n, m);
                stevecPoskusov++;
            }

            Console.WriteLine($"Po {stevecPoskusov} poskusih smo našli povezav slučajni graf na {n} vozliščih " +
                $"in {m} povezavah!");
            Console.Read();
        }
    }
}