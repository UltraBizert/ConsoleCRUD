using System.Collections.Generic;
using System.Text;
using UltraBizert.CarsCRUD.IO;

namespace UltraBizert.CarsCRUD.Commands
{
    public class ConsoleCommandsProcessor
    {
        private readonly Dictionary<string, ICommand> commandsList;

        public ConsoleCommandsProcessor()
        {
            var storage = new StorageProvider();
            commandsList = new Dictionary<string, ICommand>
            {
                {"add", new AddCommand(storage)},
                {"remove", new RemoveCommand(storage)},
                {"update", new UpdateCommand(storage)},
                {"list", new ListCommand(storage)}
            };
        }

        public bool HaveCommand(string input, out ICommand command)
        {
            command = null;

            if (!commandsList.ContainsKey(input.ToLower())) return false;

            command = commandsList[input];
            return true;
        }

        public string CommandsHelp()
        {
            var message = new StringBuilder();

            foreach (var command in commandsList)
            {
                message.AppendLine($"{command.Key} : {command.Value.DataExample}");
            }

            return message.ToString();
        }
    }
}