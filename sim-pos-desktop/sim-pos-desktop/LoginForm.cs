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
        private Users user;
        private string home_url = "http://sim-pos-mock.zerobit.id";
        public LoginForm()
        {
            InitializeComponent();
            UsernameTextBox.Select();
        }

        private bool login(string username, string pass)
        {
            bool login_success = false;
            user = new Users();
            try
            {
                string endpoint = home_url + "/users/" + username + "/" + pass;
                WebRequest request = WebRequest.Create(endpoint) as HttpWebRequest; ;
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    user = JsonConvert.DeserializeObject<Users>(responseContent);
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
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Text;

            if (login(username, password))
            {
                NewStockForm newStockForm = new NewStockForm(user);
                newStockForm.Show();
            }
            else
            {
                MessageBox.Show("Username dan password tidak cocok", "Maaf");
                PasswordTextBox.Text = "";
                UsernameTextBox.Text = "";
                UsernameTextBox.Select();
            }
        }


    }
}
