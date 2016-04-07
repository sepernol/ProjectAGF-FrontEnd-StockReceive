using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sim_pos_desktop
{
    public class m_users
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

    public class m_suppliers
    {
        private int _id;
        private string _code, _name;
        private bool _is_taxed;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string code
        {
            get { return _code; }
            set { _code = value; }
        }
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public bool is_taxed
        {
            get { return _is_taxed; }
            set { _is_taxed = value; }
        }
    }



    public class m_product
    {
        private int _id, _category_id;
        private string _sku, _name, _short_name;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string sku
        {
            get { return _sku; }
            set { _sku = value; }
        }
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string shortname
        {
            get { return _short_name; }
            set { _short_name = value; }
        }
        public int category_id
        {
            get { return _category_id; }
            set { _category_id = value; }
        }

    }
}
