using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentHari
{
    class Program
    {
        static void Main(string[] args)
        {
            string registry_key = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey key = Registry.LocalMachine.OpenSubKey(registry_key);
            string MachineName4 = System.Environment.GetEnvironmentVariable("COMPUTERNAME");
            //Console.WriteLine("COMPUTER NAME: "+MachineName4);
            foreach (string subkey_name in key.GetSubKeyNames())
            {
                RegistryKey subkey = key.OpenSubKey(subkey_name);
                //Console.WriteLine(subkey.GetValue("DisplayName"));
                //Console.WriteLine(subkey.GetValue("DisplayVersion"));
                //Console.WriteLine(subkey.GetValue("Publisher"));
                //Console.WriteLine(subkey.GetValue("InstallDate"));
                Console.WriteLine($"{MachineName4}|{subkey.GetValue("DisplayName")}| {subkey.GetValue("DisplayVersion")}|{subkey.GetValue("Publisher")}|{subkey.GetValue("InstallDate")}|");

            }
            Console.ReadKey();
        }
    }
}
