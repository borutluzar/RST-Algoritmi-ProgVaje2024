namespace RST_Algoritmi_ProgVaje2024
{
    /// <summary>
    /// Uporabimo struct, da poenostavimo primerjanje dveh povezav,
    /// pa tudi ker gre za enostavno strukturo.
    /// </summary>
    public struct Edge
    {
        public int Start { get; set; }
        public int End { get; set; }
        public double Weight { get; set; }

        /// <summary>
        /// Kadar delamo neutežene povezave, 
        /// privzeto uporabimo utež 1.
        /// </summary>
        public Edge(int start, int end) : this(start, end, 1.0) { }
        
        public Edge(int start, int end, double weight)
        {
            Start = Math.Min(start, end);
            End = Math.Max(start, end);
            Weight = weight;
        }

        public override string ToString()
        {
            return $"({this.Start}, {this.End}; {this.Weight:0.##})";
        }
    }
}