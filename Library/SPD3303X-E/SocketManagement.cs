using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace SPD3303X_E
{
    public enum CHANNELS
    {
        CH1,
        CH2,
        CH3
    }

    public enum SWITCH { ON, OFF }

    public enum CHANNEL_MODE { CV, CC }

    public enum TIMERS { TIMER1, TIMER2 }

    public enum DISPLAYS { DIGITAL, WAVEFORM }

    public enum MEMORIES { M1 = 1, M2, M3, M4, M5 }

    public enum CONNECTION_MODE { SERIES, PARALLEL, INDEPENDENT, NONE }


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
            endPoint = new IPEndPoint(this.IP_ADDRESS, IP_PORT);
        }

        ///<summary>
        /// Connection initialzation 
        ///</summary>
        public void connect()
        {
            Debug.WriteLine(endPoint);
            SCPI = new Socket(IP_ADDRESS.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            SCPI.Connect(endPoint);//connect to socket 
        }
        ///<summary>
        /// Socket termination
        ///</summary>
        public void disconnect()
        {
            if (SCPI != null)
            {
                SCPI.Close();
                SCPI.Dispose();
            }
        }
       
        //Private Function for Coms 
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
        
        //"System Status " command parser
        private async Task<int[]> getSystemStatus()
        {            
        int[] S_buffer;
        string bytes;
        int[] status = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            String receive = await telnetCommand("SYSTem:STATus?", true);
            /*
            bool[] status = new bool[10];            
            Regex regex = new Regex(@"(?<=0x)[A-Fa-f0-9]+"); //regex for hexadecimal, to discard all following invalid characters, without 0x prefix (positive lookbehind)
            string value = regex.Match(receive).Value;  //telnet bullshit, rejects 0 in the end.
            if(value.Length < 2) { value = value + "0"; };
            Debug.WriteLine("STATUS VALUE: " + value);
            int statusCode = Convert.ToInt32(value, 16);
            Debug.WriteLine("STATUS RESPONSE: " + Convert.ToString(statusCode, 2));
            int mask = 512;
            for (int i = 9; i >= 0; i--)
            {
                Debug.WriteLine(statusCode & mask);
                if (((statusCode >> (9 -i) ) & 1) == 1)
                {
                    status[i] = true;
                }
                else
                {
                    status[i] = false;
                }
            }
            */
        try
            {
                string[] inp = receive.Text.Split('x');//data recived
                for (int i = 0; i <= status.Length - 1; i++)//reset status variable
                {
                    status[i] = 0;
                }

                if (inp[1].Length <= 1)//for single digit nums in order to have a normal conversion we add a hex 0 
                {
                    inp[1] += '0'; //to the end a it will normalise the data 
                }
                Debug.WriteLine(inp[1]);
                bytes = Convert.ToString(Convert.ToInt32(inp[1], 16), 2);//hex to binary
                Debug.WriteLine(bytes);
                S_buffer = bytes.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();//split to array while casting to int
                Debug.WriteLine(bytes + " s_b_lngth " + S_buffer.Length);
                int j = status.Length - 1;
                for (int i = S_buffer.Length - 1; i >= 0; i--)//transfer values to starus array for prosessing 
                {
                    Debug.WriteLine(i + " j= " + j);
                    status[j] = S_buffer[i];
                    j--;
                }
                
                for (int k = 0; k <= 9; k++)//debuging stuff
                {
                    Debug.Write(status[k]);
                }
            }
            catch (Exception exe)
            {
                Debug.WriteLine(exe);
                return;
            }
            //Instrument(hex)=>bytes(bin)=>S_buffer(int array) =>status[](output)

            return status;
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


        private string returnSwitch(SWITCH switch1)
        {
            switch (switch1)
            {
                case SWITCH.ON:
                    return "ON";
                case SWITCH.OFF:
                    return "OFF";
                default: return "OFF";
            }
        }


        private string returnConnectionMode(CONNECTION_MODE connection)
        {
            switch (connection)
            {
                case CONNECTION_MODE.INDEPENDENT:
                    return "0";
                case CONNECTION_MODE.SERIES:
                    return "1";
                case CONNECTION_MODE.PARALLEL:
                    return "2";
                default: return "";
            }
        }


        private string returnMemory(MEMORIES memory)
        {
            switch (memory)
            {
                case MEMORIES.M1:
                    return "1";

                case MEMORIES.M2:
                    return "2";

                case MEMORIES.M3:
                    return "3";

                case MEMORIES.M4:
                    return "4";

                case MEMORIES.M5:
                    return "5";

                default: return "";
            }
        }
        ///<summary>
        /// Instrument Ididefication 
        ///</summary>
        public async Task<string> getIDN()
        {
            string ret = await telnetCommand("*IDN?", true);           
            return ret;
        }

        ///<summary>
        /// Gets the Voltage SetPoint
        ///</summary>
        public async Task<double> getVoltage(CHANNELS channel)
        {
            double value = Double.Parse(await telnetCommand(returnChannel(channel) + ":VOLTage?", true));           
            return value;
        }

        ///<summary>
        /// Gets the Current SetPoint
        ///</summary>
        public async Task<double> getCurrent(CHANNELS channel)
        {
            double value = Double.Parse(await telnetCommand(returnChannel(channel) + ":CURRent?", true));            
            return value;
        }

        ///<summary>
        /// Gets the Power reading from the ADC
        ///</summary>
        public async Task<double> getPower(CHANNELS channel)
        {
            double value = Double.Parse(await telnetCommand("MEASure:POWEr? " + returnChannel(channel), true));
            return value;
        }



        ///<summary>
        /// Gets the Mode (CV/CC) of the givven channel 
        ///</summary>
        public async Task<CHANNEL_MODE> getChannelMode(CHANNELS channel)
        {
            bool[] status = await getSystemStatus();
            switch (channel)
            {
                case CHANNELS.CH1:
                    if (status[0]) { return CHANNEL_MODE.CC; }
                    else { return CHANNEL_MODE.CV; }

                case CHANNELS.CH2:
                    if (status[1]) { return CHANNEL_MODE.CC; }
                    else { return CHANNEL_MODE.CV; }

                default: return CHANNEL_MODE.CV;
            }
        }

        ///<summary>
        /// Gets the Output Stateof the givven channel 
        ///</summary>
        public async Task<SWITCH> getChannelStatus(CHANNELS channel)
        {
            bool[] status = await getSystemStatus();
            switch (channel)
            {
                case CHANNELS.CH1:
                    if (status[4]) { return SWITCH.ON; }
                    else { return SWITCH.OFF; }

                case CHANNELS.CH2:
                    if (status[5]) { return SWITCH.ON; }
                    else { return SWITCH.OFF; }


                default: return SWITCH.ON;
            }
        }

        ///<summary>
        /// Gets the Output Stateof the givven channel 
        ///</summary>
        public async Task<SWITCH> getTimerStatus(TIMERS timer)
        {
            bool[] status = await getSystemStatus();
            switch (timer)
            {
                case TIMERS.TIMER1:
                    if (status[6]) { return SWITCH.ON; }
                    else { return SWITCH.OFF; }

                case TIMERS.TIMER2:
                    if (status[7]) { return SWITCH.ON; }
                    else { return SWITCH.OFF; }


                default: return SWITCH.ON;
            }
        }

        ///<summary>
        /// Gets the State of the waveForm display of the givven channel 
        ///</summary>
        public async Task<DISPLAYS> getDisplay(CHANNELS channel)
        {
            int[] status = await getSystemStatus();
            switch (channel)
            {
                case CHANNELS.CH1:
                    if (status[8]==1) { return DISPLAYS.WAVEFORM; }
                    else { return DISPLAYS.DIGITAL; }

                case CHANNELS.CH2:
                    if (status[9]==1) { return DISPLAYS.WAVEFORM; }
                    else { return DISPLAYS.DIGITAL; }

                default: return DISPLAYS.DIGITAL;
            }
        }

        ///<summary>
        /// Gets the Connection Mode (Serial / Parallel)
        ///</summary>
        public async Task<CONNECTION_MODE> getConnectionMode()
        {
            int[] status = await getSystemStatus();
            if (status[2]==1)
            {
                if (status[3])
                {
                    return CONNECTION_MODE.SERIES;
                }
                else { return CONNECTION_MODE.PARALLEL; }
            }
            else
            {
                if (status[3]) { return CONNECTION_MODE.INDEPENDENT; }
                else { return CONNECTION_MODE.NONE; }
            }
        }

        public async Task<bool> getInstrumentDHCP()
        {
            string response = await telnetCommand("DHCP?", true);
            
            bool dhcpStatus = false;
            if (response.Contains("DHCP:ON"))
            {
                dhcpStatus = true;
            }
            if(response.Contains("DHCP:OFF"))
            {
                dhcpStatus= false;
            }
            return dhcpStatus;           
        }

        public async Task<string> getInstrumentIP()
        {
            string response = await telnetCommand("IPaddr?", true);
            return response;
        }

        public async Task<string> getInstrumentMask()
        {
            string response = await telnetCommand("MASKaddr?", true);
            return response;
        }

        public async Task<string> getInstrumentGateway()
        {
            string response = await telnetCommand("GATEaddr?", true);
            return response;
        }

        public async Task setCurrent(CHANNELS channel, double value)
        {
            await telnetCommand(returnChannel(channel) + ":CURRent " + value, false);
        }

        //OUTPut:WAVE CH1,ON
        public async Task setVoltage(CHANNELS channel, double value)
        {
            await telnetCommand(returnChannel(channel) + ":VOLTage " + value, false);
        }


        public async Task setChannelStatus(CHANNELS channel, SWITCH status)
        {
            await telnetCommand("OUTPut " + returnChannel(channel) + "," + returnSwitch(status), false);
        }


        public async Task setChannelConnection(CONNECTION_MODE mode)
        {
            await telnetCommand("OUTPut:TRACK " + returnConnectionMode(mode), false);
        }


        public async Task setWaveformDisplay(CHANNELS channel, SWITCH sWITCH)
        {
            await telnetCommand("OUTPut:WAVE " + returnChannel(channel) + "," + returnSwitch(sWITCH), false);
        }


        public async Task setInstrumentDHCP(SWITCH dhcp)
        {
            await telnetCommand("DHCP " + returnSwitch(dhcp), false);
        }


        public async Task setInstrumentIP(string IP)
        {
            await telnetCommand("IPaddr " + IP, false);
        }


        public async Task setInstrumentMask(string address)
        {
            await telnetCommand("MASKaddr " + address, false);
        }


        public async Task setInstrumentGateway(string gateway)
        {
            await telnetCommand("GATEaddr " + gateway, false);
        }


        public async Task saveCurrentState(MEMORIES memory)
        {
            await telnetCommand("*SAV " + returnMemory(memory), false);
        }


        public async Task recallState(MEMORIES memory)
        {
            await telnetCommand("*RCL " + returnMemory(memory), false);
        }

    }
}