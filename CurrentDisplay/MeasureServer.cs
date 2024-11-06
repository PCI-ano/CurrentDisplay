using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CurrentDisplay
{
    class MeasureServer
    {
        public event EventHandler<CurrentDataReceivedArgs> CurrentDataReceived;

        public MeasureServer() {
            
        }

        public async void run()
        {
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 40000);

            Socket socket = new Socket(IPAddress.Any. AddressFamily, SocketType.Stream,
   ProtocolType.Tcp);

            socket.Bind(endpoint);
            socket.Listen();

            await Task.Run(() =>
            {
                while (true) {
                    //センサーからの接続を受け入れる（接続があるまで待つ）
                    Socket client = socket.Accept();

                    //測定値の受け取り
                    byte[] buffer = new byte[1024];
                    client.Receive(buffer);

                    // Debug.WriteLine(BitConverter.ToInt32(buffer, 0));
                    double current = BitConverter.ToInt32(buffer, 0) / 100.0;

                    CurrentDataReceivedArgs args = new CurrentDataReceivedArgs { Value = current };
                    CurrentDataReceived?.Invoke(this, args);
                }
                
            });
            

            
        }

    }

    public class CurrentDataReceivedArgs : EventArgs
    {
        public double Value { get; set; }
    }
}
