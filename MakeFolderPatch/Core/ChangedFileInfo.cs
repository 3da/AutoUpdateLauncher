using System;

namespace MakeFolderPatch.Core
{
    public class ChangedFileInfo
    {
        private readonly MyFileInfo _oldFile;
        private readonly MyFileInfo _newFile;

        public ChangedFileInfo(MyFileInfo oldFile, MyFileInfo newFile)
        {
            if (oldFile.RelativePath != newFile.RelativePath)
                throw new Exception("Error");

            _oldFile = oldFile;
            _newFile = newFile;
        }

        public MyFileInfo NewFile => _newFile;
        public MyFileInfo OldFile => _oldFile;

        public string RelativePath => _oldFile.RelativePath;
    }
}
