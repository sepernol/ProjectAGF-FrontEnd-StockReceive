using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sim_pos_desktop
{
    public class Users
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

    public class User_roles
    {
        private int _id, _user_id, _role_id;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }
        public int role_id
        {
            get { return _role_id; }
            set { _role_id = value; }
        }
    }

    public class Roles
    {
        private int _id;
        private string _code, _description;

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
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
    }


    public class Supplier
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



    public class Product
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

    public class Product_Category
    {
        private int _id;
        private string _nama, _code, _description;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string nama
        {
            get { return _nama; }
            set { _nama = value; }
        }
        public string code
        {
            get { return _code; }
            set { _code = value; }
        }
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
    }

    public class Product_UOM
    {
        private int _product_id, _uom_id;

        public int product_id
        {
            get { return _product_id; }
            set { _product_id = value; }
        }
        public int uom_id
        {
            get { return _uom_id; }
            set { _uom_id = value; }
        }
    }

    public class UOM
    {
        private int _id;
        private string _code, _description;

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
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }
    }

    public class UOM_Conversions
    {
        private int _id, _product_id, _uom_source_id, _uom_des_id;
        private decimal _conversion_value;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int product_id
        {
            get { return _product_id; }
            set { _product_id = value; }
        }
        public int uom_source_id
        {
            get { return _uom_source_id; }
            set { _uom_source_id = value; }
        }
        public int uom_dest_id
        {
            get { return _uom_des_id; }
            set { _uom_des_id = value; }
        }

        public decimal conversion_value
        {
            get { return _conversion_value; }
            set { _conversion_value = value; }
        }
    }

    public class Unit_Price
    {
        private int _id, _product_id, _uom_id;
        private decimal _unit_price;

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int product_id
        {
            get { return _product_id; }
            set { _product_id = value; }
        }

        public int uom_id
        {
            get { return _uom_id; }
            set { _uom_id = value; }
        }
        public decimal unit_price
        {
            get { return _unit_price; }
            set { _unit_price = value; }
        }

    }
}
