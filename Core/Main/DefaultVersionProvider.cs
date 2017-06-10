using System.IO;

namespace Core.Main
{
    public class DefaultVersionProvider : IVersionProvider
    {
        public string GetVersion()
        {
            return File.ReadAllText("Version.txt").Trim();
        }

        public void SaveVersion(string version)
        {
            File.WriteAllText("Version.txt", version);
        }
    }
}
