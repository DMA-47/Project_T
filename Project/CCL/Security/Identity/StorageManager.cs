using System;
using System.Collections.Generic;
using System.Text;

namespace CCL.Security.Identity
{
    public class StorageManager
        : User
    {
        public StorageManager(int userId, string name, int osbbId)
            : base(userId, name, nameof(StorageManager))
        {
        }
    }
}