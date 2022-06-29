using System;
using System.IO;

namespace DNFAudioFix
{
    internal static class Program
    {
        private static readonly string appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private static readonly string enginePath = $@"{appData}\DNFDUEL\Saved\Config\WindowsNoEditor\Engine.ini";

        private static void Main()
        {
            try
            {
                if (File.Exists(enginePath))
                {
                    Console.WriteLine($"Found Engine.ini at: {enginePath}");
                }

                var file = File.ReadAllLines(enginePath);
                for (var i = 0; i < file.Length; i++)
                {
                    var line = file[i];
                    if (line.Contains("UnfocusedVolumeMultiplier"))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n");
                        Console.WriteLine("Fix Already Applied.");

                        Exit();
                    }
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n");
                Console.WriteLine("Applying Fix..");
                Console.ResetColor();

                using (var sw = File.AppendText(enginePath))
                {
                    sw.WriteLine("\n");
                    sw.WriteLine("[Audio]");
                    sw.WriteLine("UnfocusedVolumeMultiplier = 1.0");
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n");
                Console.WriteLine("Fix Applied!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.InnerException);

                Exit();
            }

            Exit();
        }

        private static void Exit()
        {
            Console.ResetColor();
            Console.WriteLine("\n");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
