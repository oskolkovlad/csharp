using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server_UDP
{
    class Program
    {
        static void Main(string[] args)
        {
            const string IP = "127.0.0.1"; // IP-адрес
            const int PORT = 8081;        // Порт

            // Точка подключения
            var udpEndPoint = new IPEndPoint(IPAddress.Parse(IP), PORT);

            // Дверь, через которую будет устанавливаться соединение
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            // Указывает какой порт нужно слушать нашему сокету (связывание с точкой подключения, вводим в режим ожидания)
            udpSocket.Bind(udpEndPoint);
            //udpSocket.Listen(5);

            while (true)
            {
                // Сохраняем адрес подключения (клиента)
                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);

                // Буфер для полученного сообщения
                var buffer = new byte[256];
                // Количество реально полученных байтов
                var size = 0;
                // Собирает полученные данные
                var data = new StringBuilder();

                do
                {
                    // Получаем реальное количество байт из сообщения
                    size = udpSocket.ReceiveFrom(buffer, ref senderEndPoint);
                    // Приводим строку в нормальный вид
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                }
                while (udpSocket.Available > 0);

                Console.WriteLine(data);

                // Отправляем ответ
                udpSocket.SendTo(Encoding.UTF8.GetBytes("Success!"), senderEndPoint);

                //// Делаем двухстороннее выключение соединения
                //udpSocket.Shutdown(SocketShutdown.Both);

                //// Закрываем соединение
                //udpSocket.Close();
            }
        }
    }
}
