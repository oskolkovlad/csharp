using System;

namespace AnonymMethod_Lambda
{
    class Lesson
    {
        public event EventHandler<DateTime> StartLesson;

        public string Name { get; }
        public DateTime Begin { get; private set; }

        public Lesson(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name), "name is Null or Empty...");

            }
            else
            {
                Name = name;
            }
        }

        public void Start()
        {
            Begin = DateTime.Now;
            StartLesson?.Invoke(this, Begin);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
