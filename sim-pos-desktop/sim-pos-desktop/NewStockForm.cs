using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sim_pos_desktop
{
    public partial class NewStockForm : Form
    {
        private List<m_suppliers> allSupplier = new List<m_suppliers>();
        private AutoCompleteStringCollection nameSupplier = new AutoCompleteStringCollection();

        private List<m_product> allProduct = new List<m_product>();
        private AutoCompleteStringCollection nameProduct = new AutoCompleteStringCollection();

        private m_users user = new m_users();

        public NewStockForm(m_users user)
        {
            InitializeComponent();
            this.user = user;
            UserTextBox.Text = user.user_name;
            AutoCompleteProduct();
        }

        private void SupplierNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void SupplierNameTextBox_Leave(object sender, EventArgs e)
        {

        }

        private void ProductNameTextBox_Leave(object sender, EventArgs e)
        {

        }

        private void ProductNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void AddTableButton_Click(object sender, EventArgs e)
        {

        }



    }
}
