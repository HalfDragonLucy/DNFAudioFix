using System;
using System.IO;
using static DNFAudioFix.ConsoleHelper;

namespace DNFAudioFix
{
    internal static class Program
    {
        private static readonly string enginePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\DNFDUEL\Saved\Config\WindowsNoEditor\Engine.ini";

        private static void Main()
        {
            if (File.Exists(enginePath))
            {
                WriteToConsole(ConsoleType.INFORMATION, $"Found Engine.ini at {enginePath}");

                var audio = new Ini
                {
                    Section = "Audio",
                    Key = "UnfocusedVolumeMultiplier",
                    Value = "1.0"
                };

                if (Ini.Exists(audio, enginePath))
                {
                    WriteToConsole(ConsoleType.ERROR, "Key already exists in the Engine.ini");
                    ExitConsole();
                }
                else
                {
                    WriteToConsole(ConsoleType.INFORMATION, "Applying key...");

                    Ini.AppendToFile(audio, enginePath);

                    WriteToConsole(ConsoleType.INFORMATION, "Key succesfully applied!");
                    ExitConsole();
                }
            }
            else
            {
                WriteToConsole(ConsoleType.ERROR, "Could not find Engine.ini");
                ExitConsole();
            }

        }

        private static void ExitConsole()
        {
            WriteToConsole(ConsoleType.MESSAGE, "Press any key to exit.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
