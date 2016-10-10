using System;
using System.Collections.Generic;
using ManyConsole;

namespace SendMail
{
    class Program
    {
        public static void Main(string[] args)
        {
            var commands = GetCommands();

            ConsoleCommandDispatcher.DispatchCommand(commands, args, Console.Out);
        }

        private static IEnumerable<ConsoleCommand> GetCommands()
        {
            return ConsoleCommandDispatcher.FindCommandsInSameAssemblyAs(typeof (Program));
        }
    }
}
