namespace Indexer_Null
{
    class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }
    }

    class People
    {
        public Person[] data;

        public People(int countPeople)
        {
            data = new Person[countPeople];
        }

        // Индексатор должен иметь хотя бы один параметр
        public Person this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }

        // Перегрузка индексатора
        public Person this[string name]
        {
            get
            {
                Person person = null;

                foreach(Person d in data)
                {
                    if (d?.Name == name)
                    {
                        person = d;
                        break;
                    }
                }

                return person;
            }
        }
    }
}
