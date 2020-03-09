using System.Collections.Generic;

namespace PrefixTree
{
    class Node<T>
    {
        public Node() { }

        public Node(T data)
        {
            Data = data;
        }

        public Node(char symbol, T data, string prefix)
            :this(data)
        {
            Symbol = symbol;
            SubTree = new Dictionary<char, Node<T>>();
            Prefix = prefix;
        }

        public char Symbol { get; set; }
        public string Prefix { get; set; }
        public T Data { get; set; }

        public bool IsWord { get; set; } = false;

        public Dictionary<char, Node<T>> SubTree { get; set; }
        

        public Node<T> TryFindSymbol(char symbol)
        { 
            if(SubTree.TryGetValue(symbol, out Node<T> value)) {
                return value;
            }
            else
            {
                return null;
            }
        }

        public override string ToString()
        {
            return $": {Data} | SC: {SubTree.Count} | P: {Prefix}";
        }
    }
}
