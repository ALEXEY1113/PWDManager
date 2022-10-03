using System;
using System.Collections.Generic;
using System.Text;

namespace PWDManager.Shared.Entities
{
    public class Credential
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string Name { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
