using RST_Algoritmi_ProgVaje2024;

namespace RST_Algoritmi_ProgVaje2024
{
    /// <summary>
    /// Razred, ki nam omogoča delo z grafi.
    /// </summary>
    public class Graph
    {
        public List<int> Vertices { get; }
        public List<Edge> Edges { get; }

        public Graph(int n)
        {
            Vertices = new List<int>();
            Edges = new List<Edge>();

            // Dodamo vozlišča od 0 do n-1
            for (int i = 0; i < n; i++)
            {
                Vertices.Add(i);
            }
            // Ekvivalentno lahko zapišemo:
            // Vertices = Enumerable.Range(0, n).ToList();
        }

        public Graph(List<Edge> edges)
        {
            Vertices = new List<int>();
            Edges = new List<Edge>(edges); // Seznam edges skopiramo v novo instanco seznama

            // Iz seznama povezav preberemo vozlišč
            // in jih zapišemo v seznam vozlišč
            foreach (Edge e in edges)
            {
                if (!Vertices.Contains(e.Start))
                {
                    Vertices.Add(e.Start);
                }
                if (!Vertices.Contains(e.End))
                {
                    Vertices.Add(e.End);
                }
            }
        }

        /// <summary>
        /// Funkcija, ki preveri, če je graf povezan.
        /// Uporabimo pregled v širino in njegovo implementacijo z vrsto.
        /// </summary>
        public bool IsConnected()
        {
            Queue<int> queue = new Queue<int>();
            HashSet<int> lstVisited = new HashSet<int>();

            // Izberemo prvo vozlišče iz seznama vozlišč
            int first = this.Vertices.First();

            queue.Enqueue(first);

            while (queue.Count > 0)
            {
                int tmp = queue.Dequeue();
                lstVisited.Add(tmp);

                foreach (Edge edge in Edges)
                {
                    if (edge.Start == tmp)
                    {
                        if (!lstVisited.Contains(edge.End))
                        {
                            queue.Enqueue(edge.End);
                        }
                    }
                    else if (edge.End == tmp)
                    {
                        if (!lstVisited.Contains(edge.Start))
                        {
                            queue.Enqueue(edge.Start);
                        }
                    }

                }
            }

            if (lstVisited.Count == Vertices.Count)
            {
                return true;
            }

            return false;
        }



        /// <summary>
        /// Naredi slučajen graf na N vozliščih in M povezavah.
        /// Naključno določi tudi uteži na povezavah, 
        /// in sicer jim priredi celo število med 1 in weightUpperBound.
        /// </summary>
        public static Graph CreateRandomGraph(int n, int m, int weightUpperBound = 1, bool isConnected = false)
        {
            if (m > n * (n - 1) / 2)
            {
                throw new Exception("Too many edges!");
            }
            else if (m < n - 1 && isConnected)
            {
                throw new Exception("Not enough edges!");
            }

            Graph graph = new Graph(n);

            Random rnd = new Random();

            if (isConnected)
            {
                CreateRandomSpanningTree(graph, weightUpperBound);
            }

            while (graph.Edges.Count < m)
            {
                int start = rnd.Next(0, n);
                int end = rnd.Next(0, n);

                if (start == end)
                {
                    continue;
                }
                int weight = rnd.Next(1, weightUpperBound + 1);

                Edge tmp = new Edge(start, end, weight);

                if (graph.Edges.Contains(tmp))
                {
                    continue;
                }
                else
                {
                    graph.Edges.Add(tmp);
                }
            }
            return graph;

        }

        /// <summary>
        /// Poišče neko slučajno vpeto drevo, 
        /// ki ga lahko uporabimo za kreiranje povezanega slučajnega grafa.
        /// </summary>
        public static void CreateRandomSpanningTree(Graph graph, int weightUpperBound = 1)
        {
            List<int> lstIn = new List<int>() { graph.Vertices.First() };
            List<int> lstOut = new List<int>(graph.Vertices.Where(x => !lstIn.Contains(x)));

            Random rnd = new Random();

            for (int i = 0; i < graph.Vertices.Count - 1; i++)
            {
                int vertIn = lstIn[rnd.Next(0, lstIn.Count - 1)];
                int vertOut = lstOut[rnd.Next(0, lstOut.Count - 1)];

                Edge edge = new Edge(vertIn, vertOut, rnd.Next(1, weightUpperBound));
                graph.Edges.Add(edge);

                lstIn.Add(vertOut);
                lstOut.Remove(vertOut);
            }
        }

        /// <summary>
        /// Algoritem za iskanje minimalnega vpetega drevesa po Primovem algoritmu
        /// </summary>
        public double MinimalSpanningTreeByPrim()
        {
            List<int> lstIn = new List<int>() { this.Vertices.First() };

            while (lstIn.Count < this.Vertices.Count)
            {
                Edge? minEdge = null;
                // Poiščemo povezavo z minimalno utežjo,
                // ki ima eno krajišče v trenutnem drevesu,
                // drugega pa ne.
                foreach (Edge edge in this.Edges)
                {
                    if (lstIn.Contains(edge.Start) && !(lstIn.Contains(edge.End)
                            || 
                        lstIn.Contains(edge.End) && !(lstIn.Contains(edge.Start))))
                    {
                        if (minEdge == null)
                        {
                            minEdge = edge;
                        }
                        else if (minEdge.Value.Weight > edge.Weight)
                        {
                            minEdge = edge;
                        }
                    }
                }

            }

            return 1.0;
        }

        /// <summary>
        /// Graf predstavimo s seznamom njegovih povezav.
        /// Pozor: izoliranih vozlišč ne izpišemo.
        /// </summary>
        public override string ToString()
        {
            string output = "Edges of the graph:\n";

            foreach (var edge in Edges)
            {
                output += edge.ToString() + "\n";
            }
            return output;
        }
    }


}