using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client_UDP
{
    class Program
    {
        static void Main(string[] args)
        {
            const string IP       = "127.0.0.1"; // IP-адрес
            const int PORT        = 8082;        // Порт
            const int PORT_SERVER = 8081;        // Порт

            // Точка подключения
            var udpEndPoint = new IPEndPoint(IPAddress.Parse(IP), PORT);

            // Дверь, через которую будет устанавливаться соединение
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpSocket.Bind(udpEndPoint);

            while (true)
            {
                Console.WriteLine("Введите сообщение:");
                var message = Console.ReadLine();

                var serverEndPoint  = new IPEndPoint(IPAddress.Parse(IP), PORT_SERVER);

                // Отправка закодированного сообщения
                udpSocket.SendTo(Encoding.UTF8.GetBytes(message), serverEndPoint);


                // Буфер для полученного сообщения
                var buffer = new byte[256];
                // Количество реально полученных байтов
                var size = 0;
                // Собирает полученные данные
                var answer = new StringBuilder();

                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Parse(IP), PORT_SERVER);

                // Получение ответа от сервера
                do
                {
                    // Получаем реальное количество байт из сообщения
                    size = udpSocket.ReceiveFrom(buffer, ref senderEndPoint);

                    // Приводим строку в нормальный вид
                    answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (udpSocket.Available > 0);

                Console.WriteLine(answer);
            }
        }
    }
}
