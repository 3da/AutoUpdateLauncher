using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Main;
using Newtonsoft.Json;

namespace Core
{
    public class UpdaterConfig
    {

        public UpdaterConfig()
        {
            WorkingDir = new FileInfo(System.Reflection.Assembly.GetEntryAssembly().Location).DirectoryName;

            UpdateTempDirectory = WorkingDir + "\\UpdateProgress";
        }

        public static UpdaterConfig LoadFromFile(string fileName)
        {
            return JsonConvert.DeserializeObject<UpdaterConfig>(File.ReadAllText(fileName));
        }

        public string WebsiteUrl { get; set; }

        public IVersionProvider VersionProvider { get; set; }

        public string WorkingDir { get; set; }

        public string UpdateTempDirectory { get; set; }
    }
}
