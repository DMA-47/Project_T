using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class StorageManager
        : User
    {
        public StorageManager() : base(0, "", nameof(StorageManager))
        {

        }
        public StorageManager(int userId, string name, int osbbId)
            : base(userId, name, nameof(StorageManager))
        {
        }
    }
}