using System;

namespace Core.Models
{
    public class VersionModel
    {
        public string Version { get; set; }

        public DateTime? ReleaseDateTime { get; set; }
        public long Size { get; set; }
    }
}
