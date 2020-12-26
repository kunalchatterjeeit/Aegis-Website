using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aegis.Admin
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Loggedin"] = null;
        }

        private void UserLogin()
        {
            string password = new Aegis.DataAccess.Login().AuthenticateUser(txtUserName.Text);
            if (!string.IsNullOrEmpty(password))
            {
                if (password.Equals(txtPassword.Text.Trim().EncodePasswordToBase64()))
                {
                    Session["Loggedin"] = txtUserName.Text;
                    Response.Redirect("Product.aspx");
                }
            }
            else
            {
                lblMessage.Text = "Invalid username/password";
                Session["Loggedin"] = null;
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            UserLogin();
        }
    }
}