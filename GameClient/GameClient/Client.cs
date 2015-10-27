using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace GameClient
{
    public class Client
    {
        private bool _isRunning = false;
        private Socket _socket;
        private readonly int _port;

        public Client(int port)
        {
            _port = port;
        }

        private void Run()
        {
            _isRunning = true;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), _port));
            _socket.Listen(_port);

            while (_isRunning)
            {
                //Socket connSocket = _socket.Accept();
                //Thread thread = new Thread(() => ());
                //thread.Start();
            }
        }

        private void Stop()
        {
            _isRunning = false;
            _socket.Close();
        }
    }
}