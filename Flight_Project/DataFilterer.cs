
using System.ComponentModel.Design;

namespace Flight_Project
{
    internal class DataFilterer
    {
        public static void InterpretCommand(string command)
        {
            string[] commandParts = command.Split(' ');
            ICommandInterpreter interpreter;
            if(!Constants.Interpreters.TryGetValue(commandParts[0],out interpreter))
            {
                Console.WriteLine("Invalid command");
                return;
            }
            interpreter.InterpretCommand(commandParts);
        }
    }
}
