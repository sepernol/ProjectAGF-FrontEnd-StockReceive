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
        Handlers handlers = new Handlers();
        private List<Supplier> allSupplier = new List<Supplier>();
        private AutoCompleteStringCollection nameSupplier = new AutoCompleteStringCollection();

        private List<Product> allProduct = new List<Product>();
        private AutoCompleteStringCollection nameProduct = new AutoCompleteStringCollection();

        private Users user = new Users();


        public NewStockForm(Users user)
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
                Product product = allProduct[index];
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
                allSupplier = handlers.getSuppliers(1, 1);

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
                allProduct = handlers.getProducts(1, 1);
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
            UOM uom = new UOM();
            try
            {
                uom = handlers.getUOMByID(idUom);
                uomDes = uom.description;
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
            Product_UOM uomProduct = new Product_UOM();
            try
            {
                //uomProduct = handlers.getListProductUOM(idProduct);
                uomid = uomProduct.uom_id;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return uomid;
        }

    }
}
