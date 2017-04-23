using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace KlientCSharp
{
    public class Polaczenie
    {
        private Socket socket;
        private string server;
        private int port;

        public void ConnectSocket(string server, int port)
        {
            try {
                Socket s = null;
                this.server = server;
                this.port = port;
                IPEndPoint ipe = new IPEndPoint(IPAddress.Parse(server), port);
                s = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                s.Connect(IPAddress.Parse(server), port);

                this.socket = s;
            } catch
            {
                MessageBox.Show("Serwer nie odpowiada", "Blad");
            }
        }

        public void DisconnectSocket()
        {
            socket.Close();
        }

        public string SocketReceive()
        {
            Byte[] bytesReceived = new Byte[256];

            int bytes = 0;
            string page;

            bytes = this.socket.Receive(bytesReceived, bytesReceived.Length, 0);
            page = Encoding.ASCII.GetString(bytesReceived, 0, bytes);

            return page;
        }

        public void SocketSend(string request)
        {
            Byte[] bytesSent = Encoding.ASCII.GetBytes(request);

            this.socket.Send(bytesSent, bytesSent.Length, 0);
        }
    }
}
