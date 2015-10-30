using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace GameClient
{
    public class Client
    {
        private bool _isRunning = false;
        private Socket _socket;
        private int _port;
        private UpdateManager _updateManager;

        public Client()
        {
            _port = 80;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), _port));
            _updateManager = new UpdateManager();
        }

        private void Run()
        {
            _isRunning = true;
            _socket.Listen(_port);

            while (_isRunning)
            {
                // As soon as something is heard from the socket, send to the update manager as a thread.
                Thread thread = new Thread(() => _updateManager.IncomingStream(_socket.Accept()));
                thread.Start();
            }
        }

        private void Stop()
        {
            _isRunning = false;
            _socket.Close();
        }

        public bool[,] GetMap()
        {
            return _updateManager.GameData.map;
        }
    }
}