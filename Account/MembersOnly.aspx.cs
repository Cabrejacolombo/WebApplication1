using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Collections;
using System.Web.Security;

namespace WebApplication1.Account
{
    public partial class MembersOnly : System.Web.UI.Page
    {
        public Double max = 80;

        protected void Page_Load(object sender, EventArgs e)
        {
            Data d = new Data();
            int x;
            //Label1.Text = d.str1[9];
        }

        void sendMail(string subject, string body)
        {


            MembershipUserCollection x = Membership.FindUsersByName(User.Identity.Name);
            MembershipUser y;


            foreach (MembershipUser user in x)
            {

                y = user;

                MailMessage message = new MailMessage("karlos590@gmail.com", y.Email, subject, body);
                SmtpClient emailClient = new SmtpClient("smtp.gmail.com", 587);
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("karlos590@gmail.com", "nuncarevelesesto");
                emailClient.UseDefaultCredentials = false;
                emailClient.Credentials = SMTPUserInfo;
                emailClient.EnableSsl = true;
                emailClient.Send(message);
            }
        }

        protected void Chart1_Load(object sender, EventArgs e)
        {
            alarmas();
        }


        void alarmas()
        {
            Data x = new Data();
            Double valor = Double.Parse(x.str1[9]);
            Double prev = Double.Parse(x.str1[8]);
            Label1.Text = x.str1[9];

            if (valor > max && prev < max)
            {

                sendMail("Nivel alto", "");
            }
          
            if (valor < max && prev > max)
            {
                sendMail("Nivel alto regulado", "");
            }

        }

        protected void Timer1_Tick1(object sender, EventArgs e)
        {
            Chart1.Series["Series1"].Points.Dispose();

        }
    
    
    
    }



    
}