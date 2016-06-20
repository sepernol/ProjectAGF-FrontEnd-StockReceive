using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace sim_pos_desktop
{
    class Handlers
    {
        private string home_url = "http://sim-pos-mock.zerobit.id";
        //DB Product

        public string insertProduct(Product product)
        {
            string message = "";
            try
            {
                string json = "";
                json = JsonConvert.SerializeObject(product, Formatting.Indented);
                string endpoint = home_url + "/products";
                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                message = "Server Bermasalah. Silahkan Coba Lagi";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return message;
        }

        public List<Product> getProducts(int size, int page)
        {
            List<Product> listProduct = new List<Product>();
            try
            {
                string endpoint = home_url + "/products/" + size + "/page/" + page;
                WebRequest request = WebRequest.Create(endpoint) as HttpWebRequest; ;
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    listProduct = JsonConvert.DeserializeObject<List<Product>>(responseContent);
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return listProduct;
        }

        public Product getProductById(int id)
        {
            Product product = new Product();
            try
            {
                string endpoint = home_url + "/products/" + id;
                WebRequest request = WebRequest.Create(endpoint) as HttpWebRequest; ;
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    product = JsonConvert.DeserializeObject<Product>(responseContent);
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return product;
        }

        public string updateProduct(int id)
        {
            string message = "";
            try
            {
                string json = "";
                json = JsonConvert.SerializeObject(id, Formatting.Indented);
                string endpoint = home_url + "/products/" + id;
                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "PUT";
                request.ContentType = "application/json; charset=utf-8";
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                message = "Server Bermasalah. Silahkan Coba Lagi";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return message;
        }

        public string deleteProduct(int id)
        {
            string message = "";
            try
            {
                string json = "";
                json = JsonConvert.SerializeObject(id, Formatting.Indented);
                string endpoint = home_url + "/products";
                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "DELETE";
                request.ContentType = "application/json; charset=utf-8";
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                message = "Server Bermasalah. Silahkan Coba Lagi";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return message;
        }

        //DB Product UOM
        public List<Product_UOM> getListProductUOM(int id)
        {
            List<Product_UOM> listProductUOM = new List<Product_UOM>();
            try
            {
                string endpoint = home_url + "/products/" + id + "/uoms";
                WebRequest request = WebRequest.Create(endpoint) as HttpWebRequest; ;
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    listProductUOM = JsonConvert.DeserializeObject<List<Product_UOM>>(responseContent);
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return listProductUOM;
        }

        public string insertProductUOM(Product_UOM productUOM, int id)
        {
            string message = "";
            try
            {
                string json = "";
                json = JsonConvert.SerializeObject(productUOM, Formatting.Indented);
                string endpoint = home_url + "/products/" + id + "/uoms";
                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                message = "Server Bermasalah. Silahkan Coba Lagi";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return message;
        }

        public string deleteProductUOM(int id, int uom_id)
        {
            string message = "";
            try
            {
                string json = "";
                json = JsonConvert.SerializeObject(id, Formatting.Indented);
                string endpoint = home_url + "/products/" + id + "/uoms/" + uom_id;
                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "DELETE";
                request.ContentType = "application/json; charset=utf-8";
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                message = "Server Bermasalah. Silahkan Coba Lagi";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return message;
        }

        //DB Unit Price
        public string insertUnitPrice(Unit_Price unitPrice, int id)
        {
            string message = "";
            try
            {
                string json = "";
                json = JsonConvert.SerializeObject(unitPrice, Formatting.Indented);
                string endpoint = home_url + "/products/" + id + "/unit_prices";
                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                message = "Server Bermasalah. Silahkan Coba Lagi";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return message;
        }


        public Unit_Price getUnitPriceByID(int id)
        {
            Unit_Price unitPrice = new Unit_Price();
            try
            {
                string endpoint = home_url + "/products/" + id + "/unit_Prices";
                WebRequest request = WebRequest.Create(endpoint) as HttpWebRequest; ;
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    unitPrice = JsonConvert.DeserializeObject<Unit_Price>(responseContent);
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return unitPrice;
        }


        public string updateUnitPrice(int id, int uom_id)
        {
            string message = "";
            try
            {
                string json = "";
                json = JsonConvert.SerializeObject(id, Formatting.Indented);
                string endpoint = home_url + "/products/" + id + "/unit_prices/" + uom_id;
                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "PUT";
                request.ContentType = "application/json; charset=utf-8";
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                message = "Server Bermasalah. Silahkan Coba Lagi";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return message;
        }

        public string deleteUnitPrice(int id, int uom_id)
        {
            string message = "";
            try
            {
                string json = "";
                json = JsonConvert.SerializeObject(id, Formatting.Indented);
                string endpoint = home_url + "/products/" + id + "/unit_prices/" + uom_id;
                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "DELETE";
                request.ContentType = "application/json; charset=utf-8";
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                message = "Server Bermasalah. Silahkan Coba Lagi";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return message;
        }

        //DB UOM
        public string insertUOM(UOM uom)
        {
            string message = "";
            try
            {
                string json = "";
                json = JsonConvert.SerializeObject(uom, Formatting.Indented);
                string endpoint = home_url + "/uoms";
                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                message = "Server Bermasalah. Silahkan Coba Lagi";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return message;
        }

        public List<UOM> getUOMs(int size, int page)
        {
            List<UOM> listUOM = new List<UOM>();
            try
            {
                string endpoint = home_url + "/uoms/" + size + "/page/" + page;
                WebRequest request = WebRequest.Create(endpoint) as HttpWebRequest; ;
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    listUOM = JsonConvert.DeserializeObject<List<UOM>>(responseContent);
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return listUOM;
        }

        public UOM getUOMByID(int id)
        {
            UOM uom = new UOM();
            try
            {
                string endpoint = home_url + "/uoms/" + id;
                WebRequest request = WebRequest.Create(endpoint) as HttpWebRequest; ;
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    uom = JsonConvert.DeserializeObject<UOM>(responseContent);
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return uom;
        }

        public string updateUOM(int id)
        {
            string message = "";
            try
            {
                string json = "";
                json = JsonConvert.SerializeObject(id, Formatting.Indented);
                string endpoint = home_url + "/uoms/" + id;
                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "PUT";
                request.ContentType = "application/json; charset=utf-8";
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                message = "Server Bermasalah. Silahkan Coba Lagi";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return message;
        }

        public string deleteUOM(int id)
        {
            string message = "";
            try
            {
                string json = "";
                json = JsonConvert.SerializeObject(id, Formatting.Indented);
                string endpoint = home_url + "/uoms/" + id;
                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "DELETE";
                request.ContentType = "application/json; charset=utf-8";
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                message = "Server Bermasalah. Silahkan Coba Lagi";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return message;
        }


        //DB Product Category
        public string insertProductCategory(Product_Category productCategory)
        {
            string message = "";
            try
            {
                string json = "";
                json = JsonConvert.SerializeObject(productCategory, Formatting.Indented);
                string endpoint = home_url + "/product_categories";
                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                message = "Server Bermasalah. Silahkan Coba Lagi";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return message;
        }

        public List<Product_Category> getProductCategories(int size, int page)
        {
            List<Product_Category> listProductCategory = new List<Product_Category>();
            try
            {
                string endpoint = home_url + "/product_categories/" + size + "/page/" + page;
                WebRequest request = WebRequest.Create(endpoint) as HttpWebRequest; ;
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    listProductCategory = JsonConvert.DeserializeObject<List<Product_Category>>(responseContent);
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return listProductCategory;
        }

        public Product_Category getProductCategoryByID(int id)
        {
            Product_Category productCategory = new Product_Category();
            try
            {
                string endpoint = home_url + "/product_categories/" + id;
                WebRequest request = WebRequest.Create(endpoint) as HttpWebRequest; ;
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    productCategory = JsonConvert.DeserializeObject<Product_Category>(responseContent);
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return productCategory;
        }

        public string updateProductCategory(int id)
        {
            string message = "";
            try
            {
                string json = "";
                json = JsonConvert.SerializeObject(id, Formatting.Indented);
                string endpoint = home_url + "/product_categories/" + id;
                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "PUT";
                request.ContentType = "application/json; charset=utf-8";
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                message = "Server Bermasalah. Silahkan Coba Lagi";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return message;
        }

        public string deleteProductCategory(int id)
        {
            string message = "";
            try
            {
                string json = "";
                json = JsonConvert.SerializeObject(id, Formatting.Indented);
                string endpoint = home_url + "/product_categories/" + id;
                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "DELETE";
                request.ContentType = "application/json; charset=utf-8";
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                message = "Server Bermasalah. Silahkan Coba Lagi";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return message;
        }

        //DB Supplier
        public string insertSupplier(Supplier supplier)
        {
            string message = "";
            try
            {
                string json = "";
                json = JsonConvert.SerializeObject(supplier, Formatting.Indented);
                string endpoint = home_url + "/suppliers";
                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "POST";
                request.ContentType = "application/json; charset=utf-8";
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                message = "Server Bermasalah. Silahkan Coba Lagi";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return message;
        }

        public List<Supplier> getSuppliers(int size, int page)
        {
            List<Supplier> listSupplier = new List<Supplier>();
            try
            {
                string endpoint = home_url + "/suppliers/" + size + "/page/" + page;
                WebRequest request = WebRequest.Create(endpoint) as HttpWebRequest; ;
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    listSupplier = JsonConvert.DeserializeObject<List<Supplier>>(responseContent);
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return listSupplier;
        }

        public Supplier getSupplierByID(int id)
        {
            Supplier supplier = new Supplier();
            try
            {
                string endpoint = home_url + "/suppliers/" + id;
                WebRequest request = WebRequest.Create(endpoint) as HttpWebRequest; ;
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string responseContent = reader.ReadToEnd();
                    supplier = JsonConvert.DeserializeObject<Supplier>(responseContent);
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return supplier;
        }

        public string updateSupplier(int id)
        {
            string message = "";
            try
            {
                string json = "";
                json = JsonConvert.SerializeObject(id, Formatting.Indented);
                string endpoint = home_url + "/suppliers/" + id;
                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "PUT";
                request.ContentType = "application/json; charset=utf-8";
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                message = "Server Bermasalah. Silahkan Coba Lagi";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return message;
        }

        public string deleteSupplier(int id)
        {
            string message = "";
            try
            {
                string json = "";
                json = JsonConvert.SerializeObject(id, Formatting.Indented);
                string endpoint = home_url + "/suppliers/" + id;
                HttpWebRequest request = WebRequest.Create(endpoint) as HttpWebRequest;
                request.Method = "DELETE";
                request.ContentType = "application/json; charset=utf-8";
                byte[] byteData = UTF8Encoding.UTF8.GetBytes(json);

                using (Stream postStream = request.GetRequestStream())
                {
                    postStream.Write(byteData, 0, byteData.Length);
                }

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    message = JsonConvert.DeserializeObject<string>(reader.ReadToEnd());
                }
            }
            catch (Exception e)
            {
                message = "Server Bermasalah. Silahkan Coba Lagi";
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
            return message;
        }


    }
}
