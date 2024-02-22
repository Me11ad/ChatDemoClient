using System.Net.Sockets;
using System.Text;
using static System.Net.Mime.MediaTypeNames;


using var tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

try
{
    // Подключение к серверу
    await tcpClient.ConnectAsync("127.0.0.1", 1235);
    while (true)
    {

        // Создание сообщения 
        System.Console.WriteLine("Введите команду для сервера");
        string command = Console.ReadLine() + '\n';

        // Первод запроса из строкового типа данных в массив байт
        byte[] requestData = Encoding.UTF8.GetBytes(command);
        await tcpClient.SendAsync(requestData, new SocketFlags());

    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}