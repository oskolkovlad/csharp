using System;

namespace Class_Property_Constructor
{

    public class Person
    {
        // Конструктор по умолчанию
        public Person() { }

        // Конструктор пользовательский
        public Person(string name, string sName)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(sName))
            {
                throw new ArgumentNullException("Имя не может быть пустым");
            }

            Name = name;
            SecondName = sName;
        }


        //******************************************************************************************//


        // Поле класса
        private string name;

        // Свои getter и setter
        public string GetName() => name;
        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым");
            }

            this.name = name;
        }

        // Свойство
        public string _Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new ArgumentNullException("Имя не может быть пустым");
                }

                name = value;
            }
        }


        //******************************************************************************************//


        // Но можно представить в коротком виде - авто-свойство
        public string Name { get; set; }

        public string SecondName { get; set; }

        public string FullName
        {
            get => $"{SecondName} {Name}";
        }
    }
}
