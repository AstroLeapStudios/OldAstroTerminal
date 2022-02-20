using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Net;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace ASTRO_Programming_Language
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Title = "ASTRO Terminal";

            string info = "ASTRO Programming Terminal Language - Written by AstroLeap Games; Version 1.01; Use -help for prompts and commands";
            string help = "#Commands and Prompts#\n-help - Displays all commands and prompts\n-version - Displays current version of ASTRO\n-pinger - Pings the website or IP address you put in.\n-cmd - Opens command prompt\n-ip - Finds local IP Addresses.\n-windows - Gives you information about your Windows Operating System";
            string version = "Current version: 1.01";

            Console.WriteLine(info);

            while(true)
            {
                string currentCommand = null;
                Console.Write("\n>>> ");
                currentCommand = Console.ReadLine();

                if (currentCommand == "-help")
                {
                    Console.WriteLine(help);
                }
                if (currentCommand == "-version")
                {
                    Console.WriteLine(version);
                }
                if (currentCommand.Contains("-new program"))
                {
                    Console.WriteLine(" \nCreating new program...");
                    help = "#Programming Commands#\nsay [string]; - Prints out the string you entered\nrepeat [string/integer] [number] - Repeats the same thing a certain number of times";
                    Console.WriteLine("Done! To open the program, use -open and it will run.");
                    Console.WriteLine(" \n" + help);
                }
                if (currentCommand == "-pinger")
                {
                    var pingSender = new Ping();
                    Console.WriteLine("Type IP Address or URL below");
                    var hostNameOrAddress = Console.ReadLine();
                    Console.WriteLine($"PING {hostNameOrAddress}");
                    for (int i = 0; i < 1000000; i++)
                    {
                        var reply = await pingSender.SendPingAsync(hostNameOrAddress);
                        Console.WriteLine($"{reply.Buffer.Length} bytes from {reply.Address}:" +
                                  $" icmp_seq={i} status={reply.Status} time={reply.RoundtripTime}ms");
                    }
                }
                if (currentCommand == "-cmd")
                {
                    Console.WriteLine(" \n#Windows Command Prompt#\n ");
                    System.Diagnostics.Process.Start("cmd.exe");
                }
                if (currentCommand == "-ip")
                {
                    String strHostName = string.Empty;
                    strHostName = Dns.GetHostName();
                    Console.WriteLine("Local Machine's Host Name: " + strHostName);
                    IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
                    IPAddress[] addr = ipEntry.AddressList;
                    for (int i = 0; i < addr.Length; i++)
                    {
                        Console.WriteLine("IP Address {0}: {1} ", i, addr[i].ToString());
                    }
                }   
                if (currentCommand == "-windows")
                {
                    Console.WriteLine(" \n#Windows OS Information#\n ");
                    Console.WriteLine("Windows version: {0}", Environment.OSVersion);
                    Console.WriteLine("64 Bit operating system?: {0}", Environment.Is64BitOperatingSystem ? "Yes" : "No");
                    Console.WriteLine("PC Name: {0}", Environment.MachineName);
                    Console.WriteLine("Number of CPU Cores: {0}", Environment.ProcessorCount);
                    Console.WriteLine("Windows folder directory: {0}", Environment.SystemDirectory);
                    Console.WriteLine("Logical Drives Available: {0}", String.Join(", ", Environment.GetLogicalDrives()).TrimEnd(',', ' ').Replace("\\", String.Empty));
                    Console.WriteLine("User Domain Name: {0}", Environment.UserDomainName);
                    Console.WriteLine("Tick Count: {0}", Environment.TickCount64);
                }
            }
        }
    }
}