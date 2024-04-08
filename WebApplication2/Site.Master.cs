using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the current page URL is "~/"
                if (Request.Url.AbsolutePath.Equals("/default.aspx", StringComparison.OrdinalIgnoreCase))
                {
                    // Disable home, cart, and logout icons
                    DisableIcons();

                    // Delete session variable "Username"
                    Session.Remove("Username");
                }
                else
                {
                    // Check if username is stored in session
                    if (Session["Username"] != null)
                    {
                        // If username is stored in session, display it in the header
                        string username = Session["Username"].ToString();
                        loggedInUser.InnerText = "Welcome " + username;
                    }
                }
            }
        }

        private void DisableIcons()
        {
            // Disable home, cart, and logout icons
            homeItem.Visible = false;
            cartItem.Visible = false;
            logoutItem.Visible = false;
        }

        protected void Logout(object sender, EventArgs e)
        {
            // Disable home, cart, and logout icons
           

            // Delete session variable
            Session.Remove("Username");

            // Redirect to the home page or any other page after logout
            Response.Redirect("~/");
        }
    }
}