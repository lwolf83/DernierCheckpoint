using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WildCircus
{
    public partial class User
    {
        public bool Exists()
        {
            var context = new WildCircusContext();
            int countUser = context.Users.Where(x => x.Login == Login).Count();
            return countUser == 0 ? false : true;
        }

        public void Add()
        {
            var context = new WildCircusContext();
            context.Users.Add(this);
            context.SaveChanges();
        }

        public void Load()
        {
            var context = new WildCircusContext();
            List<User> users = context.Users.Where(x => x.Login == Login).ToList();
            if(users.Count == 1)
            {
                this.Login = users[0].Login;
                this.Password = users[0].Password;
                this.UserId = users[0].UserId;
                this.Email = users[0].Email;
            }
        }

        public bool IsPasswordValid()
        {
            var context = new WildCircusContext();
            int countUser = context.Users.Where(x => (x.Login == Login) && (x.Password == Password)).Count();
            return countUser == 0 ? false : true;
        }

    }
}
