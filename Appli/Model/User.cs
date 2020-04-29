using System;
using System.Collections.Generic;
using System.Text;

namespace WildCircus
{
    public partial class User
    {
        public Guid UserId { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }
        public string Email { get; set; }

    }
}
