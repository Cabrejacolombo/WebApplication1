using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class arduino : System.Web.UI.Page
    {
        string write;
        int counter;

        protected void Page_Load(object sender, EventArgs e)
        {
            string str1 = Request.QueryString["x1"];
            string str2 = Request.QueryString["x2"];
            string str3 = Request.QueryString["x3"];
            string str4 = Request.QueryString["x4"];
            string time = DateTime.Now.TimeOfDay.ToString();
            string[] hour;
            string[] temp1, temp2, temp3, temp4, aux;

            time = time.Substring(0, 8);

            Data d = new Data();

            hour = d.str5;
            temp1 = d.str1;
            temp2 = d.str2;
            temp3 = d.str3;
            temp4 = d.str4;

            counter = hour.Length;

            while (counter > 9)
            {
                for (int i = 0; i < 9; i++)
                {
                    hour[i] = hour[i + 1];
                    temp1[i] = temp1[i + 1];
                    temp2[i] = temp2[i + 1];
                    temp3[i] = temp3[i + 1];
                    temp4[i] = temp4[i + 1];
                }
                counter--;
            }

            aux = new string[hour.Length + 1];
            for (int i = 0; i < counter; i++)
                aux[i] = hour[i];
            hour = aux;
            hour[counter] = time;

            aux = new string[temp1.Length + 1];
            for (int i = 0; i < counter; i++)
                aux[i] = temp1[i];
            temp1 = aux;
            temp1[counter] = str1;
            
            aux = new string[temp2.Length + 1];
            for (int i = 0; i < counter; i++)
                aux[i] = temp2[i];
            temp2 = aux;
            temp2[counter] = str2;

            aux = new string[temp3.Length + 1];
            for (int i = 0; i < counter; i++)
                aux[i] = temp3[i];
            temp3 = aux;
            temp3[counter] = str3;

            aux = new string[temp4.Length + 1];
            for (int i = 0; i < counter; i++)
                aux[i] = temp4[i];
            temp4 = aux;
            temp4[counter] = str4;

            counter++;

            write = "";

            for (int i = 0; i < counter; i++)
            {
                if (i < counter - 1)
                    write += hour[i] + ",";
                else
                    write += hour[i];
            }

            System.IO.File.WriteAllText(@"C:\\Users\\Carlos Cabreja\\Documents\\Visual Studio 2010\\Projects\\WebApplication1\\WebApplication1\\time.txt", write);


            write = "";

            for (int i = 0; i < counter; i++)
            {
                if (i < counter - 1)
                    write += temp1[i] + " ";
                else
                    write += temp1[i];
            }

            System.IO.File.WriteAllText(@"C:\\Users\\Carlos Cabreja\\Documents\\Visual Studio 2010\\Projects\\WebApplication1\\WebApplication1\\temp1.txt", write);


            write = "";

            for (int i = 0; i < counter; i++)
            {
                if (i < counter - 1)
                    write += temp2[i] + " ";
                else
                    write += temp2[i];
            }

            System.IO.File.WriteAllText(@"C:\\Users\\Carlos Cabreja\\Documents\\Visual Studio 2010\\Projects\\WebApplication1\\WebApplication1\\temp2.txt", write);


            write = "";

            for (int i = 0; i < counter; i++)
            {
                if (i < counter - 1)
                    write += temp3[i] + " ";
                else
                    write += temp3[i];
            }

            System.IO.File.WriteAllText(@"C:\\Users\\Carlos Cabreja\\Documents\\Visual Studio 2010\\Projects\\WebApplication1\\WebApplication1\\temp3.txt", write);


            write = "";

            for (int i = 0; i < counter; i++)
            {
                if (i < counter - 1)
                    write += temp4[i] + " ";
                else
                    write += temp4[i];
            }

            System.IO.File.WriteAllText(@"C:\\Users\\Carlos Cabreja\\Documents\\Visual Studio 2010\\Projects\\WebApplication1\\WebApplication1\\temp4.txt", write);

        }
    }
}