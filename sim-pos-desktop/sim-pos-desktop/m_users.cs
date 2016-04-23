using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sim_pos_desktop
{
    class m_users
    {
        private int _id;
        private string _user_name;
        private string _full_name;
        private string _password_has;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string user_name
        {
            get { return _user_name; }
            set { _user_name = value; }
        }
        public string full_name
        {
            get { return _full_name; }
            set { _full_name = value; }
        }
        public string password
        {
            get { return _password_has; }
            set { _password_has = value; }
        }
    }
}
