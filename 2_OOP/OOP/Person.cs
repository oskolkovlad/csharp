﻿namespace OOP_Base
{
    public class Person
    {
        //*** Инкапсуляция ***//


        //* Модификаторы доступа:

        // public       - открытый для всех
        // internal     - внутренний, открыт внутри одного проекта
        // protected    - защищенный, доступен между наследниками
        // private      - доступен только классу, где объявлен

        // Более подробно:
        /*
           В C# применяются следующие модификаторы доступа:

           - public: публичный, общедоступный класс или член класса.Такой член класса доступен из любого места в коде,
           а также из других программ и сборок.
           - private: закрытый класс или член класса.Представляет полную противоположность модификатору public. Такой
           закрытый класс или член класса доступен только из кода в том же классе или контексте.
           - protected: такой член класса доступен из любого места в текущем классе или в производных классах.При этом
           производные классы могут располагаться в других сборках.
           - internal: класс и члены класса с подобным модификатором доступны из любого места кода в той же сборке, однако
           он недоступен для других программ и сборок(как в случае с модификатором public).
           - protected internal: совмещает функционал двух модификаторов.Классы и члены класса с таким модификатором
           доступны из текущей сборки и из производных классов.
           - private protected: такой член класса доступен из любого места в текущем классе или в производных классах,
           которые определены в той же сборке.
        */

        // Это для примера, так делать неправильно (правильно использовать свойства и модификаторы "private" и "ptotected")
        public string   firstName;
        public string   lastName;
        public byte     age;

        //private decimal money; // доступ к полю "money" только у класса "Person"
        protected decimal money;
    }
}