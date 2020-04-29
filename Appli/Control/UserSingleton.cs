using System;
using System.Collections.Generic;
using System.Text;

namespace WildCircus
{
    class UserSingleton
    {
        private static UserSingleton _instance = null;
        public bool IsAuthenticated { get; private set; } = false;

        public User user;

        public static UserSingleton GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserSingleton();
                }
                return _instance;
            }
        }

        public void Set(User newUser)
        {
            user = newUser;
            IsAuthenticated = true;
        }

        public static void Dispose()
        {
            _instance = null;
        }

    }
}
