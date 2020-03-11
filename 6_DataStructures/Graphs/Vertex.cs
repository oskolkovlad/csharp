namespace Graphs
{
    class Vertex
    {
        public Vertex(int number)
        {
            Number = number;
        }

        public int Number { get; private set; }
        public bool isVisited = false;


        public override string ToString() => Number.ToString();
    }
}
