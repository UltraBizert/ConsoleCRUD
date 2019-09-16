using System;
using UltraBizert.CarsCRUD.Commands;

namespace UltraBizert.CarsCRUD.IO
{
    public class InputProvider
    {
        private readonly ConsoleCommandsProcessor commandProcessor;

        public InputProvider() => commandProcessor = new ConsoleCommandsProcessor();

        public void StartListen()
        {
            while (ProceedInput(Console.ReadLine())) { }
        }

        private bool ProceedInput(string input)
        {
            try
            {
                if (input == null || input.IsCommand(new[] {"e", "exception"}))
                    throw new Exception("Something wrong!");

                if (input.IsCommand(new[] {"q", "quit"})) return false;

                if (commandProcessor.HaveCommand(input, out var command))
                    ProceedCommand(command);
                else
                    Console.WriteLine(commandProcessor.CommandsHelp());
            }
            catch (Exception)
            {
                Console.WriteLine("Ups, bad input! \n But it's okay. Feed some more input, pls!'");
            }

            return true;
        }

        private void ProceedCommand(ICommand command)
        {
            if (!command.InputRequired())
            {
                command.Execute();
                return;
            }

            Console.WriteLine($"expect params : {command.DataExample}");

            var commandInput = Console.ReadLine();

            if (command.ValidateData(commandInput))
                command.Execute();
        }
    }
}