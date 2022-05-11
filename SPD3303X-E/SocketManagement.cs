using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;

namespace SPD3303X_E
{
    public enum CHANNELS
    {
        CH1,
        CH2,
        CH3
    }
    internal class SocketManagement
    {
        private IPAddress IP_ADDRESS = null;
        private int IP_PORT;
        private IPEndPoint endPoint = null;
        private Socket SCPI = null;

        public SocketManagement(string IP_ADDRESS, int PORT)
        {
            this.IP_ADDRESS = IPAddress.Parse(IP_ADDRESS);
            this.IP_PORT = PORT;
            endPoint= new IPEndPoint(this.IP_ADDRESS, IP_PORT);
        }

        public void connect() {
            Debug.WriteLine(endPoint);
            SCPI = new Socket(IP_ADDRESS.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            SCPI.Connect(endPoint);//connect to socket 
        }
        public void disconnect() {
            if (SCPI != null) {
                SCPI.Close();
            }
        }
        public async Task<string> getIDN()
        {
            string ret = await telnetCommand("*IDN?", true);
            Console.WriteLine(ret);
            return ret;
        }
        
        public async Task<double> getVoltage(CHANNELS channel)
        {
            double value = Double.Parse(await telnetCommand(returnChannel(channel)+":VOLTage?", true));
            Console.WriteLine(value);
            return value;
        }

        public async Task<double> getCurrent(CHANNELS channel)
        {
            double value = Double.Parse(await telnetCommand(returnChannel(channel) + ":CURRent?", true));
            Console.WriteLine(value);
            return value;
        }

        public async Task<double> getPower(CHANNELS channel)
        {
            double value = Double.Parse(await telnetCommand("MEASure:POWEr? " + returnChannel(channel), true));

            Console.WriteLine(value);
            return value;
        }

        public async Task setCurrent(CHANNELS channel, double value)
        {
            await telnetCommand(returnChannel(channel) + ":CURRent " + value, false);
        }

        public async Task setVoltage(CHANNELS channel, double value)
        {
            await telnetCommand(returnChannel(channel) + ":VOLTage " + value, false);
        }



        private async Task<string> telnetCommand(string cmd, bool wait)
        {
            byte[] command = Encoding.ASCII.GetBytes(cmd);
            await SCPI.SendAsync(command, SocketFlags.None);
            await Task.Delay(100);//DataRace reasons
            if (wait)
            {
                byte[] buffer = new byte[1024];
                await SCPI.ReceiveAsync(buffer, SocketFlags.None);
                string response = Encoding.ASCII.GetString(buffer);
                return response;
            }
            return "";
           
        }

        private string returnChannel(CHANNELS channel)
        {
            switch (channel)
            {
                case CHANNELS.CH1:
                    return "CH1";
                case CHANNELS.CH2:
                    return "CH2";
                case CHANNELS.CH3:
                    return "CH3";
                default:
                    return "";
            }
        }
    }
}
