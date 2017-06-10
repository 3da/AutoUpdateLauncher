using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Launcher
{
    public class Config
    {
        public string AppName { get; set; }

        public string WebsiteUrl { get; set; }
        public string UpdateTempDirectory { get; set; }
        public string WorkingDir { get; set; }
        public string RunFileName { get; set; }
    }
}
