namespace Graphs
{
    class Edge
    {
        public Edge(Vertex fromVertex, Vertex toVertex, int weight)
        {
            FromVertex = fromVertex;
            ToVertex = toVertex;
            Weight = weight;
        }

        public Vertex FromVertex { get; private set; }
        public Vertex ToVertex { get; private set; }
        public int Weight { get; private set; }


        public override string ToString() => Weight.ToString();
    }
}
