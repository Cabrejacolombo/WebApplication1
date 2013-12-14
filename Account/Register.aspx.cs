using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;

namespace WebApplication1.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            string username = RegisterUser.UserName;
            string ToEmailAdd = RegisterUser.Email;   //.Email;

            MembershipUser newuser = Membership.GetUser(RegisterUser.UserName);
            newuser.IsApproved = false;


            Guid newuserid = (Guid)newuser.ProviderUserKey;
            string urlBase = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;
            string VerifyUrl = "Verify.aspx?ID=" + newuserid.ToString();
            string fullPath = urlBase + VerifyUrl;

            string AppPath = Request.PhysicalApplicationPath;
            StreamReader sr = new StreamReader(AppPath + "EmailTemplates/VerifyNewUser.txt");

            MailMessage message = new MailMessage();
            message.From = new MailAddress("karlos590@gmail.com");
            message.To.Add(ToEmailAdd);
            message.Subject = "Verify User Registration!";

            message.Body = sr.ReadToEnd();
            message.IsBodyHtml = true;
            sr.Close();

            message.Body = message.Body.Replace("%USERNAME%", RegisterUser.UserName);
            message.Body = message.Body.Replace("%VerificationUrl%", fullPath);

            SmtpClient emailClient = new SmtpClient("smtp.gmail.com", 587);
            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("karlos590@gmail.com", "nuncarevelesesto");
            emailClient.UseDefaultCredentials = false;
            emailClient.Credentials = SMTPUserInfo;
            emailClient.EnableSsl = true;

            emailClient.EnableSsl = true;

            emailClient.Send(message);

            //    FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }

    }
}
