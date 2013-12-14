using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Globalization;

namespace WebApplication1
{
    public class Data
    {
        String line;
        public string[] str1, str2, str3, str4, str5;
 
        public Data()
        {
            read();
        }

        IList<Element> temp1 = new List<Element>();
        IList<Element> temp2 = new List<Element>();
        IList<Element> temp3 = new List<Element>();
        IList<Element> temp4 = new List<Element>();


        public IList<Element> getTemp1()
        {
            return temp1;
        }
        public IList<Element> getTemp2()
        {
            return temp2;
        }
        public IList<Element> getTemp3()
        {
            return temp3;
        }
        public IList<Element> getTemp4()
        {
            return temp4;
        }


        public void read()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\\Users\\Carlos Cabreja\\Documents\\Visual Studio 2010\\Projects\\WebApplication1\\WebApplication1\\temp1.txt"))
                {
                    line = sr.ReadToEnd();
                    sr.Close();
                }
                str1 = line.Split(' ');
            }
            catch (Exception e)
            {
                Console.WriteLine("ANALOG1:The file could not be read:");
                Console.WriteLine(e.Message);
            }
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\\Users\\Carlos Cabreja\\Documents\\Visual Studio 2010\\Projects\\WebApplication1\\WebApplication1\\temp2.txt"))
                {
                    line = sr.ReadToEnd();
                    sr.Close();
                }
                str2 = line.Split(' ');
            }
            catch (Exception e)
            {
                Console.WriteLine("ANALOG1:The file could not be read:");
                Console.WriteLine(e.Message);
            }
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\\Users\\Carlos Cabreja\\Documents\\Visual Studio 2010\\Projects\\WebApplication1\\WebApplication1\\temp3.txt"))
                {
                    line = sr.ReadToEnd();
                    sr.Close();
                }
                str3 = line.Split(' ');
            }
            catch (Exception e)
            {
                Console.WriteLine("ANALOG1:The file could not be read:");
                Console.WriteLine(e.Message);
            }
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\\Users\\Carlos Cabreja\\Documents\\Visual Studio 2010\\Projects\\WebApplication1\\WebApplication1\\temp4.txt"))
                {
                    line = sr.ReadToEnd();
                    sr.Close();
                }
                str4 = line.Split(' ');
            }
            catch (Exception e)
            {
                Console.WriteLine("ANALOG1:The file could not be read:");
                Console.WriteLine(e.Message);
            }
            try
            {
                using (StreamReader sr = new StreamReader(@"C:\\Users\\Carlos Cabreja\\Documents\\Visual Studio 2010\\Projects\\WebApplication1\\WebApplication1\\hour.txt"))
                {
                    line = sr.ReadToEnd();
                    sr.Close();
                }
                str5 = line.Split(',');


            }
            catch (Exception e)
            {
                Console.WriteLine("ANALOG1:The file could not be read:");
                Console.WriteLine(e.Message);
            }

            for (int i = 0; i < str1.Length; i++)
            {
                try
                {
                    DateTime prueba = DateTime.Parse(str5[i]);
                    temp1.Add(new Element { ID = i, time = prueba, temp = System.Convert.ToDouble(str1[i]) });
                    temp2.Add(new Element { ID = i, time = prueba, temp = System.Convert.ToDouble(str2[i]) });
                    temp3.Add(new Element { ID = i, time = prueba, temp = System.Convert.ToDouble(str3[i]) });
                    temp4.Add(new Element { ID = i, time = prueba, temp = System.Convert.ToDouble(str4[i]) });

                }
                catch (Exception e)
                {
                    Console.WriteLine("No se convierte correctamente a DateTime");
                    Console.WriteLine(e.Message);
                }
            }
        
        }
    }
}