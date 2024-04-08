using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace WebApplication2
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Fetch data from database and bind to GridView
                BindGridView();
            }
        }

        protected void BindGridView()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string json = client.DownloadString("https://fakestoreapi.com/products");
                    var products = JsonConvert.DeserializeObject<Product[]>(json);
                    Repeater1.DataSource = products;
                    Repeater1.DataBind();
                }
            }
            catch (WebException ex)
            {
                // Handle web exception
                if (ex.Response != null)
                {
                    using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                    {
                        string errorResponse = reader.ReadToEnd();
                        Console.WriteLine("Error response from server: " + errorResponse);
                    }
                }
                else
                {
                    Console.WriteLine("Error making request: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
        public class Product
        {
            public int id { get; set; }
            public string title { get; set; }
            public string description { get; set; }
            public float price { get; set; }
            public string image { get; set; }
        }


        protected void GridView1_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            // You can handle row editing here if required
        }

        protected void GridView1_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            // You can handle row deleting here if required
        }
    }
}