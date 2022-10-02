using System;
using System.Collections.Generic;
using System.Text;

namespace PWDManager.Shared.Entities
{
    public class CredentialDTO
    {
        public DateTime lastUpdated { get; set; }

        public Object data { get; set; }

        public CredentialDTO()
        {
            lastUpdated = DateTime.Now;
        }
    }
}
