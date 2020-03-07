using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Set
{
    class ListSet<T> : IEnumerable
    {
        public ListSet()
        {
            set = new List<T>();
        }

        public ListSet(IEnumerable<T> set)
        {
            this.set = set.ToList<T>();
        }


        private List<T> set;
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;


        public void Add(T data)
        {
            if (!set.Contains(data))
            {
                set.Add(data);
                Count++;
            } 
            //else
            //   throw new ArgumentException("Нельзя добавить повторяющийся элемент!");
        }

        public void Remove(T data)
        {
            //if (Count == 0)
            //    throw new NullReferenceException("Множество пустое!");

            if (set.Contains(data))
            {
                set.Remove(data);
                Count--;
            }
            //else
            //    throw new ArgumentException("Данного элемента нет в множестве, следовательно его невозможно удалить!");
        }

        public bool Contains(T data)
        {
            if (set.Contains(data))
                return true;
            else
                return false;
        }


        public ListSet<T> Union(ListSet<T> setB)
        {
            ListSet<T> union = new ListSet<T>();

            foreach (var s in set)
            {
                union.Add(s);
            }

            foreach (var s in setB.set)
            {
                union.Add(s);
            }

            return union;

            //return new ListSet<T>(set.Union(setB.set));
        }

        public ListSet<T> Intersection(ListSet<T> setB)
        {
            var result = new ListSet<T>();

            foreach (var s1 in set)
            {
                foreach (var s2 in setB.set)
                {
                    if (s1.Equals(s2))
                    {
                        result.Add(s1);
                        break;
                    }
                }
            }

            return result;

            //return new ListSet<T>(set.Intersect(setB.set));
        }

        public ListSet<T> Difference(ListSet<T> setB)
        {
            var result = new ListSet<T>(set);

            foreach (var s in setB.set)
            {
                result.Remove(s);
            }

            return result;

            //return new ListSet<T>(set.Except(setB.set));
        }

        public ListSet<T> SymmetricDifference(ListSet<T> setB)
        {
            var result = Union(setB);
            var intersept = Intersection(setB);

            foreach (var s in intersept.set)
            {
                result.Remove(s);
            }

            return result;

            //return new ListSet<T>(set.Union(setB.set).Except(set.Intersect(setB.set)));
        }

        public bool SubSet(ListSet<T> setB)
        {
            var count = 0;

            foreach (var s1 in set)
            {
                foreach (var s2 in setB.set)
                {
                    if (s1.Equals(s2))
                    {
                        count++;
                    }
                }
            }

            if (count == setB.Count)
                return true;
            else
                return false;

            //return setB.set.All(s => set.Contains(s));
        }

        public override string ToString()
        {
            return $"В множестве следующее количество элементов: {Count}";
        }


        /*public IEnumerator GetEnumerator()
        {
            foreach(var s in set)
            {
                yield return s;
            }
        }*/

        public IEnumerator GetEnumerator() => /*((IEnumerable)this).GetEnumerator();*/ set.GetEnumerator();
    }
}