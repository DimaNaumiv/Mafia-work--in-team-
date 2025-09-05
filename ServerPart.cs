using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MafiaVisual;

namespace Server
{
    class GameServer
    {
        private static MafiaVisual.Form1 form = new MafiaVisual.Form1();
        private static TcpListener listener;
        public  void SendMessage(Stream stream, string message)
        {
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
        }

        public  async Task<string> ReceiveMessage(Stream stream)
        {
                byte[] buffer = new byte[256];
                int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                return Encoding.UTF8.GetString(buffer, 0, bytesRead);
        }
    }
}