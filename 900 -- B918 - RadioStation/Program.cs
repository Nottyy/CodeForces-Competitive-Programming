using System;
using System.Collections.Generic;
using System.Text;

namespace _900____B918___RadioStation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');

            int numberOfServers = int.Parse(input[0]);
            int numberOfCommands = int.Parse(input[1]);

            var dictionary = new Dictionary<string, string>();

            for (int i = 0; i < numberOfServers; i++)
            {
                var command = Console.ReadLine().Split(' ');
                var serverIp = command[1];
                var serverName = command[0];
                dictionary.Add(serverIp, serverName);
            }

            var sb = new StringBuilder();

            for (int i = 0; i < numberOfCommands; i++)
            {
                var commandLine = Console.ReadLine().Split(new[] { ' ', ';' });
                var serverIp = commandLine[1];
                var commandName = commandLine[0];
                sb.AppendLine($"{commandName} {serverIp}; #{dictionary[serverIp]}");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
