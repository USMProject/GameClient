using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;

namespace GameClient
{
    public enum directions
    {
        up,
        down,
        left,
        right
    }

    public class Cookie
    {
        public int x, y;
        public directions direction;
    }

    public class Player
    {
        public string username;
        public int x, y;
        public int cookies;
        public Player(string named, int px, int py, int ck)
        {
            username = named;
            x = px;
            y = py;
            cookies = ck;
        }
    }

    public class Data
    {
        public List<Player> players { get; set; }
        public List<Cookie> cookies { get; set; }
        public bool[,] map { get; set; }

        public int MapSizeX { get; set; }
        public int MapSizeY { get; set; }

        /*public Data(string mapin)
        {
            map = new bool 
        }*/
    }

    public class UpdateManager
    {
        public Data GameData { get; set; } = new Data();

        public void IncomingStream(Socket incomingSocket)
        {
            try
            {
                StreamReader stream = new StreamReader(new NetworkStream(incomingSocket));

                while (!stream.EndOfStream)
                {
                    // Parse the incoming data
                    string line = stream.ReadLine();

                    // Do stuff
                    if (line == "Initializing game")
                    {
                        InitializeMap(40, 40);
                    }
                    else if (line == "Update players")
                    {
                        InitializePlayers();
                    }
                    else if (line == "Update players")
                    {
                        UpdatePlayers();
                    }
                    else if (line == "Update cookies")
                    {
                        UpdateCookies();
                    }
                }
            }
            catch (Exception)
            {
                // Tell the player there's a network issue.
            }
        }

        private void InitializeMap(int sizeX, int sizeY)
        {
            // Setup the map
            GameData.MapSizeX = sizeX;
            GameData.MapSizeY = sizeY;
            GameData.map = new bool[sizeX, sizeY];
        }

        private void FillMap(string binaryMap)
        {
            int x = 0;
            int y = 0;

            foreach (char c in binaryMap)
            {
                // parse stuff in.
                GameData.map[x, y] = (c == 1);
                y++;

                if (y > GameData.MapSizeY)
                {
                    x++;
                    y = 0;
                }

                if (x > GameData.MapSizeX)
                {
                    // out of bounds
                }
            }
        }

        private void InitializePlayers()
        {
            //
        }

        private void UpdatePlayers()
        {
            //
        }

        private void UpdateCookies()
        {
            //
        }
    }
}