using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace WebApplication1.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            MembershipUserCollection x = Membership.FindUsersByName(LoginUser.UserName);
            MembershipUser y;


            foreach (MembershipUser user in x)
            {

                y = user;
                if (!y.IsApproved)
                    Response.Redirect("/Account/Login.aspx");
            }


        }
    }
}
