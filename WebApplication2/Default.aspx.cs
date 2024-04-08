using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if user is already authenticated, then redirect to list page
                if (User.Identity.IsAuthenticated)
                {
                    Response.Redirect("ListPage.aspx");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Check username and password (this is a basic example, replace it with your authentication logic)
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Example authentication logic (replace with your actual logic)
            if (username == "admin" && password == "admin")
            {
                // If authentication is successful, redirect to list page
                Session["Username"] = username;
                Response.Redirect("List.aspx");
            }
            else
            {
                // If authentication fails, display error message
                lblMessage.Visible = true;
                lblMessage.Text = "Invalid username or password.";
            }
        }
    }
}