using System;

namespace Exceptions
{
    /// <summary>
    /// Пользовательский класс исключения.
    /// </summary>
    public class MyOwnException : ApplicationException
    {
        /// <summary>
        /// Пользовательский объект.
        /// </summary>
        object _myObject;

        /// <summary>
        /// Сообщение об ошибке. 
        /// </summary>
        string _message;

        /// <summary>
        /// Конструктор объекта исключения.
        /// </summary>
        /// <param name="obj"> Пользовательский объект.</param>
        /// <param name="message"> Текст сообщения.</param>
        public MyOwnException(object obj, string message)
        {
            _myObject = obj;
            _message = message;
        }

        /// <summary>
        /// Пользовательский объект. 
        /// </summary>
        public object MyObject
        {
            get
            {
                return _myObject;
            }
        }

        /// <summary>
        /// Перегрузка свойства "Message", 
        /// чтобы вернуть сообщение пользовательского исключения.
        /// </summary>
        public override string Message
        {
            get
            {
                return _message;
            }
        }
    }
}
