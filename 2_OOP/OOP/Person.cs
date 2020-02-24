namespace OOP_Base
{
    public class Person
    {
        //*** Инкапсуляция ***//


        //* Модификаторы доступа:

        // public       - открытый для всех
        // internal     - внутренний, открыт внутри одного проекта
        // protected    - защищенный, доступен между наследниками
        // private      - доступен только классу, где объявлен


        // Это для примера, так делать неправильно (правильно использовать свойства и модификаторы "private" и "ptotected")
        public string   firstName;
        public string   lastName;
        public byte     age;

        //private decimal money; // доступ к полю "money" только у класса "Person"
        protected decimal money;
    }
}
