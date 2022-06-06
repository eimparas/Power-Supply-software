using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
using System.Media;
using System.Resources;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel;

namespace SPD3303X_E
{
    static class Program
    {


        static async Task Main()
        {
            SocketManagement management = new SocketManagement("192.168.0.106", 5025);
            management.connect();
            await test(management);


        }


        async static Task test(SocketManagement m)
        {
            await Task.Run(async () =>
            { //await m.getIDN();
               
                await m.setWaveformDisplay(CHANNELS.CH1, SWITCH.ON);
                DISPLAYS s = await m.getDisplay(CHANNELS.CH1);
                Console.WriteLine((int)s);
                await m.setChannelStatus(CHANNELS.CH1, SWITCH.OFF);
                SWITCH d = await m.getChannelStatus(CHANNELS.CH1);
                Console.WriteLine(d);
                await m.setChannelStatus(CHANNELS.CH1, SWITCH.ON);
                d = await m.getChannelStatus(CHANNELS.CH1);
                Console.WriteLine(d);

            }
            );
        } 
    }
}