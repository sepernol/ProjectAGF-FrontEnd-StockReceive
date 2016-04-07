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
    public partial class NewStockForm : Form
    {
        private List<m_suppliers> allSupplier = new List<m_suppliers>();
        private AutoCompleteStringCollection nameSupplier = new AutoCompleteStringCollection();

        private List<m_product> allProduct = new List<m_product>();
        private AutoCompleteStringCollection nameProduct = new AutoCompleteStringCollection();

        private m_users user = new m_users();

        private string home_url = "http://sim-pos-mock.zerobit.id";

        public NewStockForm(m_users user)
        {
            InitializeComponent();
            this.user = user;
            UserTextBox.Text = user.user_name;
            
        }

        private void SupplierNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ProductNameTextBox.Select();
            }
        }

        private void SupplierNameTextBox_Leave(object sender, EventArgs e)
        {
            if (!nameSupplier.Contains(SupplierNameTextBox.Text))
            {
                MessageBox.Show("Supplier tidak ada dalam database", "Maaf");
                BatchNumberTextBox.Select();
                BatchNumberTextBox.Text = "";
            }
        }

        private void ProductNameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BatchNumberTextBox.Select();
            }
        }

        private void ProductNameTextBox_Leave(object sender, EventArgs e)
        {
            if (nameProduct.Contains(ProductNameTextBox.Text))
            {
                int index = nameProduct.IndexOf(ProductNameTextBox.Text);
                m_product product = allProduct[index];
                UnitOfMeasurementTextBox.Text = getUomDes(getUomID(product.id));
            }
            else
            {
                MessageBox.Show("Produk tidak ada dalam database", "Maaf");
                ProductNameTextBox.Select();
                ProductNameTextBox.Text = "";
            }
        }



        private void AddTableButton_Click(object sender, EventArgs e)
        {

        }

        private void AutoCompleteSupplier()
        {
            try
            {
                string endpoint = home_url + "/suppliers";
                WebRequest request = WebRequest.Create(endpoint) as HttpWebRequest; ;
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    allSupplier = JsonConvert.DeserializeObject<List<m_suppliers>>(responseContent);
                }

                for (int x = 0; x < allSupplier.Count; x++)
                {
                    nameSupplier.Add(allSupplier[x].name);
                }

                SupplierNameTextBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                SupplierNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                SupplierNameTextBox.AutoCompleteCustomSource = nameSupplier;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        private void AutoCompleteProduct()
        {
            try
            {
                string endpoint = home_url + "/products";
                WebRequest request = WebRequest.Create(endpoint) as HttpWebRequest; ;
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    allProduct = JsonConvert.DeserializeObject<List<m_product>>(responseContent);
                }

                for (int x = 0; x < allProduct.Count; x++)
                {
                    nameProduct.Add(allProduct[x].name);
                }

                ProductNameTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                ProductNameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                ProductNameTextBox.AutoCompleteCustomSource = nameProduct;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        private string getUomDes(int idUom)
        {
            string uomDes = "";
            m_uoms uom = new m_uoms();
            try
            {
                string endpoint = home_url + "/uoms/" + idUom;
                WebRequest request = WebRequest.Create(endpoint) as HttpWebRequest; ;
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    uom = JsonConvert.DeserializeObject<m_uoms>(responseContent);
                    uomDes = uom.description;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return uomDes;
        }

        private int getUomID(int idProduct)
        {
            int uomid = 0;
            m_product_uom uomProduct = new m_product_uom();
            try
            {
                string endpoint = home_url + "/products/" + idProduct + "/uoms";
                WebRequest request = WebRequest.Create(endpoint) as HttpWebRequest; ;
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    uomProduct = JsonConvert.DeserializeObject<m_product_uom>(responseContent);
                    uomid = uomProduct.uom_id;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return uomid;
        }

    }
}
