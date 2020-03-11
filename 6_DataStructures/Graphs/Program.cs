using System;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            var graph = new Graph();

            var v1 = new Vertex(1);
            var v2 = new Vertex(2);
            var v3 = new Vertex(3);
            var v4 = new Vertex(4);
            var v5 = new Vertex(5);
            var v6 = new Vertex(6);
            var v7 = new Vertex(7);

            var vertexes = new Vertex[] { v1, v2, v3, v4, v5, v6, v7 };

            GraphInit(graph, vertexes);
            GetMatrix(graph);
            Console.WriteLine();
            GetVettexList(graph, vertexes);
            Console.WriteLine();

            Console.WriteLine(graph.Wave(v1, v5));
            Console.WriteLine(graph.Wave(v2, v4));
            

            Console.ReadKey();
        }


        public static void GraphInit(Graph graph, params Vertex[] vertex)
        {
            

            graph.AddVertex(vertex[0]);
            graph.AddVertex(vertex[1]);
            graph.AddVertex(vertex[2]);
            graph.AddVertex(vertex[3]);
            graph.AddVertex(vertex[4]);
            graph.AddVertex(vertex[5]);
            graph.AddVertex(vertex[6]);

            graph.AddEdge(vertex[0], vertex[1]);
            graph.AddEdge(vertex[0], vertex[2]);
            graph.AddEdge(vertex[1], vertex[4]);
            graph.AddEdge(vertex[1], vertex[5]);
            graph.AddEdge(vertex[2], vertex[3]);
            graph.AddEdge(vertex[4], vertex[5]);
            graph.AddEdge(vertex[5], vertex[4]);
        }

        public static void GetMatrix(Graph graph)
        {
            var matrix = graph.GetMatrix();

            Console.WriteLine(new string('=', 5 * (graph.VertexCount + 1)));
            for (var i = -1; i < graph.VertexCount; i++)
            {
                if (i != -1)
                {
                    Console.Write($"{i + 1}\t| ");
                }
                else
                {
                    Console.Write($"\t| ");
                }

                for (var j = 0; j < graph.VertexCount; j++)
                {
                    if (i != -1 && j != -1)
                    {
                        Console.Write(matrix[i, j] + " | ");
                    }
                    else
                    {
                        Console.Write($"{j + 1} | ");
                    }
                }
                Console.WriteLine();
                Console.WriteLine(new string('=', 5 * (graph.VertexCount + 1)));
            }
        }

        public static void GetVettexList(Graph graph, params Vertex[] vertexes)
        {
            foreach(var vertex in vertexes)
            {
                Console.Write($"{vertex}:\t");
                foreach (var v in graph.GetVertexList(vertex))
                {
                    Console.Write(v + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
