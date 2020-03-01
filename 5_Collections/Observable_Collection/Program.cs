using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Observable_Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            // ObservableCollection по функциональности похож на список List за тем исключением, что позволяет
            // известить внешние объекты о том, что коллекция была изменена.

            ObservableCollection<Person> persons = new ObservableCollection<Person>()
            {
                new Person(){ Name = "Tom"},
                new Person(){ Name = "John"},
                new Person(){ Name = "Bob"}
            };
            
            persons.CollectionChanged += Person_CollectionChanged;

            persons.Add(new Person() { Name = "Alex" });
            persons.RemoveAt(0);
            persons[1].Name = "Mike";

            foreach (var p in persons)
            {
                Console.WriteLine(p.Name);
            }


            Console.ReadKey();
        }

        static void Person_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Person p1 = e.NewItems[0] as Person;
                    Console.WriteLine($"Добавлен новый объект: {p1.Name}\n");
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Person p2 = e.OldItems[0] as Person;
                    Console.WriteLine($"Удален объект: {p2.Name}\n");
                    break;
                case NotifyCollectionChangedAction.Replace:
                    Person p3 = e.NewItems[0] as Person;
                    Person p4 = e.OldItems[0] as Person;
                    Console.WriteLine($"Объект {p4.Name} был заменен на новый объект {p3.Name}\n");
                    break;
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
    }
}
