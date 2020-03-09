using System;
using System.Collections.Generic;
using System.Text;

namespace PrefixTree
{
    class Tree<T>
    {
        public Tree()
        {
            root = new Node<T>('\0', default, "");
            Count = 0; 
        }

        private Node<T> root;
        public int Count { get; private set; } = 0;

        public void Add(string key, T data) => AddNode(key.ToLower(), data, root);

        private void AddNode(string key, T data, Node<T> node)
        {
            if (string.IsNullOrEmpty(key))
            {
                if (!node.IsWord)
                {
                    node.Data = data;
                    node.IsWord = true;
                    Count++;
                } 
            }
            else
            {
                var symbol = key[0];
                var subnode = node.TryFindSymbol(symbol);

                if(subnode is null)
                {
                    var newNode = new Node<T>(symbol, data, node.Prefix + symbol);
                    node.SubTree.Add(symbol, newNode);
                    AddNode(key.Substring(1), data, newNode);
                }
                else
                {
                    AddNode(key.Substring(1), data, subnode);
                }
            } 
        }

        public void Remove(string key) => RemoveNode(key.ToLower(), root);

        private void RemoveNode(string key, Node<T> node)
        {
            if (string.IsNullOrEmpty(key))
            {
                if (node.IsWord)
                {
                    node.IsWord = false;
                    Count--;
                    //
                }
            }
            else
            {
                var subnode = node.TryFindSymbol(key[0]);
                if(subnode != null)
                {
                    RemoveNode(key.Substring(1), subnode);
                }
            }
        }

        public bool TrySearch(string key, out T data) => TrySearchNode(key.ToLower(), root, out data);

        private bool TrySearchNode(string key, Node<T> node, out T data)
        {
            data = default;
            var result = false;

            if (string.IsNullOrEmpty(key))
            {
                if (node.IsWord)
                {
                    data = node.Data;
                    result = true;
                }
            }
            else
            {
                var subnode = node.TryFindSymbol(key[0]);
                if (subnode != null)
                {
                    result = TrySearchNode(key.Substring(1), subnode, out data);
                }
            }

            return result;
        }
    }
}
