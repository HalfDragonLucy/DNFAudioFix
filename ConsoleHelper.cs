using System;

namespace DNFAudioFix
{
    internal static class ConsoleHelper
    {
        public enum ConsoleType
        {
            MESSAGE,
            INFORMATION,
            ERROR
        }

        public static void WriteToConsole(ConsoleType type, string text)
        {
            switch (type)
            {
                case ConsoleType.MESSAGE:
                    Console.ResetColor();
                    Console.WriteLine(text);
                    Console.WriteLine("\n");
                    break;
                case ConsoleType.INFORMATION:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Information: {text}");
                    Console.WriteLine("\n");
                    break;
                case ConsoleType.ERROR:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {text}");
                    Console.WriteLine("\n");
                    break;
            }
        }
    }
}
