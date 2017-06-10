using System;
using System.Collections.Generic;

namespace MakeFolderPatch.Core
{
    public class MyFileComparer:IEqualityComparer<MyFileInfo>
    {
        public bool Equals(MyFileInfo x, MyFileInfo y)
        {
            return x.RelativePath == y.RelativePath && x.Size == y.Size;
        }

        public int GetHashCode(MyFileInfo obj)
        {
            throw new NotImplementedException();
        }
    }
}
