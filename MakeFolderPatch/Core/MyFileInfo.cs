using System.IO;

namespace MakeFolderPatch.Core
{
    public class MyFileInfo
    {
        private readonly DirectoryInfo _di;
        private readonly FileInfo _fi;

        public MyFileInfo(DirectoryInfo di, FileInfo fi)
        {
            _di = di;
            _fi = fi;
        }

        public string FullPath =>_fi.FullName;

        public string RelativePath => _fi.FullName.Replace(_di.FullName, "");

        public long Size => _fi.Length;

        public static implicit operator FileInfo(MyFileInfo pfi)
        {
            return pfi._fi;
        }

        public byte[] ReadBytes() => File.ReadAllBytes(_fi.FullName);
    }
}
