using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client_TCP
{
    class Program
    {
        static void Main(string[] args)
        {
            const string IP = "127.0.0.1"; // IP-адрес
            const int PORT = 8080;        // Порт

            // Точка подключения
            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(IP), PORT);

            // Дверь, через которую будет устанавливаться соединение
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Введите сообщение:");
            var message = Console.ReadLine();

            // Кодируем наше сообщение
            var data = Encoding.UTF8.GetBytes(message);

            // Подключаемся к серверу
            tcpSocket.Connect(tcpEndPoint);

            // Отправка закодированного сообщения
            tcpSocket.Send(data);


            // Буфер для полученного сообщения
            var buffer = new byte[256];

            // Количество реально полученных байтов
            var size = 0;

            // Собирает полученные данные
            var answer = new StringBuilder();


            // Получение ответа от сервера
            do
            {
                // Получаем реальное количество байт из сообщения
                size = tcpSocket.Receive(buffer);

                // Приводим строку в нормальный вид
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            }
            while (tcpSocket.Available > 0);

            Console.WriteLine(answer.ToString());


            // Делаем двухсторонее выключение соединения
            tcpSocket.Shutdown(SocketShutdown.Both);

            // Закрываем соединение
            tcpSocket.Close();


            Console.ReadKey();
        }
    }
}
