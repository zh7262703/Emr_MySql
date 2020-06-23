using System;
using System.Collections.Generic;
using System.Text;
using System.IO.IsolatedStorage;

namespace Bifrost
{
    /// <summary>
    /// 清空临时文件夹
    /// </summary>
    public class DeletingStores
    {
        IsolatedStorageFile isoStore1 = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Domain | IsolatedStorageScope.Assembly, null, null);
        public void DeleteIsoStores()
        {
            isoStore1.Remove();
            IsolatedStorageFile.Remove(IsolatedStorageScope.User);
        }
    }
}
