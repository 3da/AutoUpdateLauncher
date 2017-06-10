using Newtonsoft.Json;

namespace Core.Models
{
    public class PatchFileInfo
    {
        public string RelativePath { get; set; }

        [JsonIgnore]
        public string RelativeUrl => RelativePath.Trim('/', '\\').Replace('\\', '/');

        public long Size { get; set; }

        public bool IsPatch { get; set; }

        public string Hash { get; set; }
    }
}
