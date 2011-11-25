using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AAA.BlogPublisher
{
    public class UserInfo
    {
        private string _strUserId;
        private string _strUsername;
        private string _strPassword;
        private string _strBlogname;

        public string UserId
        {
            get { return _strUserId; }
            set { _strUserId = value; }
        }

        public string Username
        {
            get { return _strUsername; }
            set { _strUsername = value; }
        }

        public string Password
        {
            get { return _strPassword; }
            set { _strPassword = value; }
        }

        public string Blogname
        {
            get { return _strBlogname; }
            set { _strBlogname = value; }
        }
    }
}
