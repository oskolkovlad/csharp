using System;
using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    class Graph
    {
        List<Vertex> Vertexes;
        List<Edge> Edges;

        public int VertexCount => Vertexes.Count;

        public Graph()
        {
            Vertexes = new List<Vertex>();
            Edges    = new List<Edge>();
        }


        public int[,] GetMatrix()
        {
            var matrix = new int[Vertexes.Count, Vertexes.Count];

            foreach(var edge in Edges)
            {
                var row = edge.FromVertex.Number;
                var column = edge.ToVertex.Number;
                matrix[row - 1, column - 1] = edge.Weight;
            }

            return matrix;
        }

        public void AddVertex(Vertex vertex)
        {
            Vertexes.Add(vertex);
        }

        public void AddEdge(Vertex fromVertex, Vertex toVertex, int weight = 1)
        {
            Edges.Add(new Edge(fromVertex, toVertex, weight));
        }

        public List<Vertex> GetVertexList(Vertex vertex)
        {
            var result = new List<Vertex>();

            foreach(var e in Edges)
            {
                if(e.FromVertex == vertex)
                {
                    result.Add(e.ToVertex);
                }
            }

            return result;
        }

        public bool Wave(Vertex start, Vertex finish)
        {
            var list = new List<Vertex>
            {
                start
            };

            for (var i = 0; i < list.Count; i++)
            {
                var vertex = list[i];

                foreach (var v in GetVertexList(vertex))
                {
                    if (!v.isVisited)
                    {
                        list.Add(v);
                        v.isVisited = true;
                    }  
                }
            }

            return list.Contains(finish);
        }
    }
}
