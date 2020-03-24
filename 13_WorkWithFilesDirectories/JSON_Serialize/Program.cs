using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JSON_Serialize
{
    // Объект, который подвергается десериализации, должен иметь конструктор без параметров.
    // Например, в примере выше этот конструктор по умолчанию. Но можно также явным образом определить подобный конструктор в классе.

    //Сериализации подлежат только публичные свойства объекта(с модификатором public).

    class Program
    {
        async static Task Main(string[] args)
        {

            // По умолчанию JsonSerializer сериализует объекты в минимифицированный код. С помощью дополнительного параметра
            // типа JsonSerializerOptions можно настроить механизм сериализации/десериализации, используя свойства JsonSerializerOptions.
            
            // Некоторые из его свойств:

            // - AllowTrailingCommas: устанавливает, надо ли добавлять после последнего элемента в json запятую.Если равно true, запятая добавляется
            // - IgnoreNullValues: устанавливает, будут ли сериализоваться / десериализоваться в json объекты и их свойства со значением null
            // - IgnoreReadOnlyProperties: аналогично устанавливает, будут ли сериализоваться свойства, предназначенные только для чтения
            // - WriteIndented: устанавливает, будут ли добавляться в json пробелы(условно говоря, для красоты). Если равно true устанавливаются дополнительные пробелы

           JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            Person person1 = new Person()
            {
                Name = "TOM",
                Age = 23
            };

            Person person2 = new Person()
            {
                Name = "MOT",
                Age = 32
            };

            string json = JsonSerializer.Serialize(person1, options);
            Console.WriteLine(json);

            Person person = JsonSerializer.Deserialize<Person>(json);
            Console.WriteLine($"{person.Name} | {person.Age}");

            using(var fs = new FileStream("person.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, person2);
                Console.WriteLine("Data has been saved to file");
            }

            using (FileStream fs = File.OpenRead("person.json"))
            {
                person = await JsonSerializer.DeserializeAsync<Person>(fs);
                Console.WriteLine($"Name: {person.Name}  Age: {person.Age}");
            }



            Console.ReadKey();
        }
    }

    class Person
    {
        // Атрибут JsonIgnore позволяет исключить из сериализации определенное свойство.
        // А JsonPropertyName позволяет замещать оригинальное название свойства.

        [JsonPropertyName("firstname")]
        public string Name { get; set; }

        [JsonIgnore]
        public int Age { get; set; }
    }
}
