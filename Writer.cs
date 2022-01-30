using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace customSitemapGenerator
{
    class Writer
    {
        
        public static void WriteToFile(string str)   //(List<string> list)             
        {
            // path of file to create / read / write / append.[NOTE]: place sitemap file to desired path and enter that path in path_variable.
            string filePath = @"C:\Users\M. Kashif Javed\Desktop\customSitemapGenerator\sitemap.txt";
            
            // check, if file exist or not.
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("");
                }
            }

            // writing data to file.
            using (StreamWriter sw = File.AppendText(filePath))
            {
                //foreach (string element in list)
                //{
                //    sw.WriteLine("<url>");
                //    sw.WriteLine("<loc>" + element + "</loc>");
                //    sw.WriteLine("<lastmod>" + DateTime.Now + "</lastmod>");
                //    sw.WriteLine("</url>");
                //}

                sw.WriteLine("<url>");
                sw.WriteLine("<loc>" + str + "</loc>"); //Url String
                sw.WriteLine("<lastmod>" + DateTime.Now + "</lastmod>");
                sw.WriteLine("</url>");

                // unComment following when writing to file completely finished.
                //sw.WriteLine("</urlset>");
            }
        }
    }
}