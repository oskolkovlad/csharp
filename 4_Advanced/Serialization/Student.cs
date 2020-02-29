using System.Runtime.Serialization;

namespace Serialization
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public Group Group { get; set; }

        public Student(string name, int age)
        {
            // TODO: check params

            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return $"Name: {Name}; Age: {Age}";
        }
    }
}
