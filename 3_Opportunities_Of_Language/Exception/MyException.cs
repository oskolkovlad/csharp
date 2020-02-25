using System;

namespace Exceptions
{
    class MyException : Exception
    {
        public MyException() : base("Это мое исключение...") { }

        public MyException(string message) : base(message) { }
    }
}
