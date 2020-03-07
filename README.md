## Remind and learn programming language like C#...

### Структура:
#### 1_HelloWorld:
- `Matrix` - очень простенькая консольная программа, выводящая предложения по одной букве.
- `0_HelloWorld` - Простейшая программа.
- `1_Variables` - Рассмотрение типов переменных, их методов, явное/неявное приведение/преобразование.
- `2_Array_List_Enum` - Массивы (Array), списки (List) и перечисления (enum). Сортировка массива. 
- `3_IfElse_Switch` - Условный оператор, условная конструкция switch...case...default и тернарный условный оператор (?).
- `4_Cycles` - циклы for, foreach, while, do...while. Операторы break и continue.
- `5_Methods` - методы, перегрузка методов, рекурсия.
- `6_Tuples_and_Struct` - кортежи (tuples) и структуры (struct).
- `7_WorkWith_String` - инициализация строк, операции со строками, интерполяция и форматирование строк и регулярные выражения.
- `8_WorkWith_DateTime` - операции с датами, форматирование дат.

#### 2_OOP:
- `1_OOP_Base` - наследование, инкапсуляция, модификаторы доступа, полиморфизм.
- `2_Class_Property_Constructor` - поля, свойства и автосвойства классов и конструкторы.
- `3_Method` - методы в классах.
- `4_CreateLibrary` и `MyLib` - создание библиотеки, в которую помещаем класс из проекта `2_Class_Property_Constructor`. Подключаем ее и используем в проекте `4_CreateLibrary`.
- `5_OperatorOverload_Const_ReadOnly` - перегрузка операторов (...static TYPE operator OPERATOR ()), константы (const) и поля только для чтения (readonly).
- `6_Indexer_Null` - Индексаторы (...this[...]{ get; set; }) и операторы ?/?? для опеределения null и в случае null значения совершения альтернативного действия соотвественно.
- `7_OperationCastOverload` - переопределение операций приведения типов (...static explicit/implicit operator OUT_TYPE (IN_TYPE)).
- `8_Virtual_Method_and_Property` - виртуальные методы и свойства, переопределение виртуальных методов в классах насследниках (override) и запрет наследования и переопределения методов родителей (sealed).
- `9_Abstract_Shadowing` - абстрактные классы и сокрытие методов родителя (... new ... NAME()).
- `10_Patrial_LocalMethod_PatternMatching_Deconstrucor` - частичные классы/методы, локальные функции, Pattern Matching (Manager manager when manager.IsVacation) и Деконструктор.
- `11_SwitchPattern_NullableType_VarRef` - шаблоны в конструкции switch...case (свйоств в объекте, позиционный и кортежей), Nullable тип (int?) и Переменные-ссылки (ref).

#### 3_Opportunities_Of_Language:
- `1_Operator_Overload` - перегрузка операторов (...static TYPE operator OPERATOR ()).
- `2_Generics` - рассмотрение универсальных типов для классов (class NAME<T> | class NAME1 : NAME2<int> | class NAME1<T> : NAME2<int> | class NAME1<T> : NAME2<T> where T : class| class NAME1<T, TT> : NAME2<T> where T : struct) и для методов (если в обобщенном классе - ... T NAME (T ARG1, T ARG2); если не в обобщенном кассе - ... T NAME<T> (T ARG1, T ARG2)).
- `3_Interfaces` - реализация интерфейсов (неявная и явная(void IObject.Create() - при этом для того чтобы воспользоваться данном методом, необходимо привести объект к тому интерфейсу, которым хотим воспользоваться), последовательное наследование, итерфейсы IComparable (CompareTo - return this.Name.CompareTo(p.Name)) и IComparer (public int Compare(Person p1, Person p2) {реализация сравнения}). IComparer имеет приоритет над IComparable.
- `4_Exception` - обработка исключений с  помощью конструкции try...catch...final, фильтр исключений с помощью when (catch (DivideByZeroException ex) when (a == 5)), выброс исключений с помощью throw new и создание своих исключений.
- `5_Delegate_Event` - рассмотрение делегатов и событий.
- `6_Stream_Files` - запись в файл и чтение из него:
    - using (var sw = new StreamWriter("./out.txt", false, encoding))
    - using (var sr = new StreamReader("./out.txt", encoding))
    - для чтения еще раз: sr.DiscardBufferedData(); sr.BaseStream.Seek(0, SeekOrigin.Begin);
- `7_Async_Await_Thread` - рассмотрение многопоточности и ассинхронности:
    - Thread thread1 = new Thread(new ThreadStart(NAME_of_FUNCTION)); thread1.Start(int.MaxValue - параметр функции);
    - для ассинхронности надо создать обертку для функции:
        static async Task<bool> SaveFileAsync(string path)
            var result = await Task.Run(() => SaveFile(path));
    - public static object locker = new object(); lock (locker) {}
- `8_1_Server_TCP` и `8_2_Client_TCP` - создание TCP клиент-сервера:
    - IPEndPoint(IPAddress.Parse(IP), PORT);
    - Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    - tspSocket.Bind(tcpEndPoint);
    - listner = tcpSocket.Accept().
- `8_3_Server_UDP` и `8_4_Client_UDP` -  создание UDP клиент-сервера:
    - IPEndPoint(IPAddress.Parse(IP), PORT);
    - Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
    - udpSocket.Bind(udpEndPoint);
    - EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);
    - ReceiveFrom и SendTo.
- `9_SQL_Entity_Framework` - простенька ораганизация БД с помощью Entity Framework (DB First):
    - DbContext;
    - `<connectionStrings>`
        `<add name="DBConnectionString" connectionString="data source=(localdb)\MSSQLLocalDB;Initial Catalog=Musics;Integrated Security=True;" providerName="System.Data.SqlClient"/>`
    `</connectionStrings>`
- `10_LINQ` - стандартная форма записи (как запрос SQL), методы расширений.

#### 4_Advanced:
- `1_Extension_Method` - методы расширения (... static OUT_TYPE NAME(this TYPE PARAM ...)).
- `2_Indexer_Yield_IEnumerable` - рассмотрены итераторы. Оператор yield для перебора набора значений (yield return и yield break).
- `3_Anonymous_type_and_Tuples` - рассмотрены анонимные типы - как классы, но без реализации и только для чтения (var product = new { Name = "Apple", Energy = 100};) - и кортежи (Tuples (readonly) and ValueTuples).
- `4_AnonymMethod_Lambda` - рассмотрены анонимные методы (delegate(...){}) и лямбда-выражения((a, b) => a + b).
- `5_Attribute_Reflection` - рассмотрены атрибуты ([AttributeUsage(AttributeTargets.MODE | AttributeTargets.MODE)]. Нужно отнаследоваться созданному атрибуту от класса Attribute. В программе к типу класса (typeof(CLASS)) методы GetCustomAttributes(...) или GetProperties() в зависимости от того, применен атрибут ко всему классу или отдельным свойствам.
- `6_Serialization` - рассмотрены 4 вида сериализации ([Serializable] для сериализуемого класса, а если мы не хотим сериализовать какое-то св-во, то ставим около него [NonSerializable]):
    - бинарная (BinaryFormatter());
    - SOAP (SoapFormatter() - нужно скачать в NuGet);
    - XML (XmlSerializer(typeof(List<CLASS>)));
    - JSON (DataContractJsonSerializer(typeof(List<CLASS>)) - вместо [Serializable] ставим [DataContract] и применять данный атрибут надо не к классу, а к св-ам которые сериализуем) - но есть и другие классы, реализующие сериализацию в JSON.
- `7_GarbageCollectror` - рассмотрен сборщик мусора (GC.Collect()), деструктор класса (~MyClass() { }) и интерфейс IDisposable.
- `8_TypeObject` - рассмотрены основные методы, возможность их переопределения, boxing/unboxing, поверхностное или неглубокое (MemberwiseClone()) и глубокое копирование.
- `9_UnsafeCode` - рассмотрение неуправляемого кода (операция разыменования - * и адрес - &).

#### 5_Collections:
- `1_ArrayListCollection` - ArrayList представляет коллекцию объектов (разнотипные объекты).
- `2_ListCollection` - простейший список однотипных объектов.
- `3_LinkedListCollection` - двухсвязный список, в котором каждый элемент хранит ссылку одновременно на следующий и на предыдущий элемент.
- `4_QueueCollection` - обычная очередь, работающую по алгоритму FIFO ("первый вошел - первый вышел").
- `5_StackCollection` - коллекция, которая использует алгоритм LIFO ("последний вошел - первый вышел").
- `6_DictionaryCollection` - хранит объекты, которые представляют пару ключ-значение.
- `7_Observable_Collection` - ObservableCollection по функциональности похож на список List за тем исключением, что позволяет известить внешние объекты о том, что коллекция была изменена.
- `8_IEnumerableIEnumerator` - итератор.
- `9_Yield` - итератор. Оператор yield для перебора набора значений.
- `10_LazyCollection` - Lazy<T> гарантирует нам, что объект будет создан только тогда, когда в нем есть необходимость.
- `11_Span_IndexRange` - Span позволяет избежать дополнительных выделений памяти при операции с наборами данных. Также рассмотрены индексы и диапозоны (^1 и 1..5).

#### 6_DataStructures:
- `1_Linked_List_1` - реализация односвязного списка с помощью узлов.
- `2_Stack` - реализация стека на основе списка (List), массива и односвязного списка. 
- `3_Linked_List_2` - реализация двусвязного списка.
- `4_Circular_Linked_List` - реализация кольцевых списков, односвязного и двухсвязного.
- `5_Queue` - реализация очереди на основе списка (List), массива и односвязного списка. 
- `6_Deque` - реализация двусторонней очереди на основе двусвязного списка.
- `7_Set` - рассмотрение встроенной коллеции множества HashSet<T> и реализация множество Set на основе списка List<T>.

### Полезные ресурсы:

#### C#:

- Полное руководство по C# 8 и .NET Core:   https://metanit.com/sharp/tutorial/
- Паттерны проектирования в C# и .NET:      https://metanit.com/sharp/patterns/
- Сетевое программирование в С# и .NET:     https://metanit.com/sharp/net/
- Алгоритмы и структуры данных в C#:        https://metanit.com/sharp/algoritm/

#### ASP.NET:

- Руководство по ASP.NET Core 3:             https://metanit.com/sharp/aspnet5/
- Руководство по ASP.NET MVC 5:              https://metanit.com/sharp/mvc5/
- Руководство по ASP.NET Web API 2:          https://metanit.com/sharp/aspnet_webapi/