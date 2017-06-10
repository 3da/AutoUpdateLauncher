using System.Collections.Generic;

namespace Core.Models
{
    public class PatchModel: VersionModel
    {
        public List<PatchFileInfo> UpdatedFiles { get; set; }

        public List<PatchFileInfo> NewFiles { get; set; }

        public List<string> DeletedFiles { get; set; }
    }
}
