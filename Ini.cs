using System.IO;

namespace DNFAudioFix
{
    public class Ini
    {
        public static bool Exists(Ini ini, string path)
        {
            var file = File.ReadAllLines(path);

            for (var i = 0; i < file.Length; i++)
            {
                var line = file[i];
                if (line.Contains(ini.Key))
                {
                    return true;
                }
            }
            return false;
        }

        public static void AppendToFile(Ini ini, string path)
        {
            using (var sw = File.AppendText(path))
            {
                sw.WriteLine("\n");
                sw.WriteLine($"[{ini.Section}]");
                sw.WriteLine($"{ini.Key} = {ini.Value}");
            }
        }

        public string Section
        {
            get;
            set;
        }
        public string Key
        {
            get;
            set;
        }
        public string Value
        {
            get;
            set;
        }
    }
}
