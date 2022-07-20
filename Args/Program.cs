using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.IO;

namespace PingHosts001
{
    class Program
    {
        static void Main(string[] args)
        {
            Ping myPing = new Ping();
            PingOptions myPingOptions = new PingOptions();
            string data = "icmp_send_request";
            string myPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string myLogFile = @"\Accesslog.txt";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int myLength = args.Length;
            DateTime CurrentTime;
            Console.WriteLine("Путь к папке \"Мои документы\" текущего пользователя {0}", myPath);
            StreamWriter myStream = new StreamWriter(myPath + myLogFile);
            for (int i = 0; i < myLength; i++)
            {
                // ping args[0]
                // ...
                // ping args[myLength - 1]
                myPingOptions.DontFragment = false;
                CurrentTime = DateTime.Now;
                PingReply reply = myPing.Send(args[i], 120, buffer, myPingOptions);
                if (reply.Status.ToString() == "Success")
                {
                    Console.WriteLine("{0} yзел {1} доступен ip = {2}", CurrentTime,  args[i], reply.Address.ToString());
                    myStream.WriteLine("{0} yзел {1} доступен ip = {2}", CurrentTime, args[i], reply.Address.ToString());
                }
                else
                {
                    Console.WriteLine("{0} yзел {1} доступен ", CurrentTime, args[i]);
                    myStream.WriteLine("{0} yзел {1} доступен ", CurrentTime, args[i]);
                }                
            }
            myStream.Close();
        }
    }
}
