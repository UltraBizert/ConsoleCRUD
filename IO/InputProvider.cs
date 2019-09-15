using System;
using UltraBizert.CarsCRUD.Commands;

namespace UltraBizert.CarsCRUD.IO
{
    public class InputProvider
    {
        private readonly ConsoleCommandsProcessor commandProcessor;

        public InputProvider()
        {
            commandProcessor = new ConsoleCommandsProcessor();
        }

        public void StartListen()
        {
            var listen = true;
            do try
                {
                    var input = Console.ReadLine();
                    if (input == null || input.Equals("e"))
                        throw new Exception("Something wrong!");

                    if (input.Equals("q"))
                    {
                        listen = false;
                        Console.WriteLine("Stop listen");
                    }
                    else if (commandProcessor.HaveCommand(input, out var command))
                    {
                        Console.WriteLine($"expect params : {command.DataExample}");

                        var commandInput = Console.ReadLine();

                        if (command.ValidateData(commandInput))
                            command.Execute();
                        else
                            Console.WriteLine($"wrong params, expect : {command.DataExample}");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Ups, bad input! \n But it's okay. Feed some more input, pls!'");
                }
            while (listen);
        }
    }
}