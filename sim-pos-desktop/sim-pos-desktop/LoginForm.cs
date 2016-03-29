using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace sim_pos_desktop
{
    public partial class LoginForm : Form
    {
        m_users user;
        public LoginForm()
        {
            InitializeComponent();
            UsernameTextBox.Select();
        }

        private bool login(string username, string pass)
        {
            bool login_success = false;
            user = new m_users();
            try
            {
                WebRequest request = WebRequest.Create(string.Format("http://apotik/user/{0},{1}", user, pass)) as HttpWebRequest; ;
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    user = JsonConvert.DeserializeObject<m_users>(responseContent);
                    if (user.user_name != null && user.password != null)
                    {
                        login_success = true;
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return login_success;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string user = UsernameTextBox.Text;
            string pass = UsernameTextBox.Text;

            if (login(user, pass))
            {
                Show(new NewStockForm());
            }
            else
            {
                MessageBox.Show("Username dan password tidak cocok", "Maaf", MessageBoxButtons.OK, MessageBoxIcon.None);
                PasswordTextBox.Text = "";
                UsernameTextBox.Text = "";
                UsernameTextBox.Select();
            }
        }


    }
}
