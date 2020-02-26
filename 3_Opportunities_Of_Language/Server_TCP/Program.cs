using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server_TCP
{
    class Program
    {
        static void Main(string[] args)
        {
            const string IP = "127.0.0.1"; // IP-адрес
            const int PORT  = 8080;        // Порт

            // Точка подключения
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(IP), PORT);

            // Дверь, через которую будет устанавливаться соединение
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // Указывает какой порт нужно слушать нашему сокету (связывание с точкой подключения, вводим в режим ожидания)
            tcpSocket.Bind(tcpEndPoint);
            tcpSocket.Listen(5);

            // Процесс прослушивания
            while (true)
            {
                // Создание нового сокета для конкретного клиента (подключение клиента)
                var listner = tcpSocket.Accept();

                // Буфер для полученного сообщения
                var buffer = new byte[256];

                // Количество реально полученных байтов
                var size = 0;

                // Собирает полученные данные
                var data = new StringBuilder();

                // Получение сообщения
                do
                {
                    // Получаем реальное количество байт из сообщения
                    size = listner.Receive(buffer);

                    // Приводим строку в нормальный вид
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (listner.Available > 0);

                Console.WriteLine(data);

                // Отправляем ответ
                listner.Send(Encoding.UTF8.GetBytes("Success!"));

                // Делаем двухсторонее выключение соединения
                listner.Shutdown(SocketShutdown.Both);

                // Закрываем соединение
                listner.Close();
            }
        }
    }
}
