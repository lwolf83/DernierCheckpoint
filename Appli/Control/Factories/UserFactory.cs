using System;
using System.Collections.Generic;
using System.Text;

namespace WildCircus
{
    public static class UserFactory
    {
        public static User Create(string login, string password, string email = "")
        {
            User currentUser = new User();
            currentUser.Login = login;
            currentUser.Password = Sha.CryptPassword(password);
            currentUser.Email = email;
            return currentUser;
        }
    }
}
