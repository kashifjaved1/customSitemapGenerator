﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace customSitemapGenerator
{
    class Writer
    {
        
        public static async Task WriteToFile(string str, string fileName) //(List<string> list)
        {
            // path of file to create / read / write / append.[NOTE]: place sitemap file to desired path and put that path in path_variable.
            string filePath = null;

            if (fileName == "menus")
            {
                filePath = @"C:\Users\M. Kashif Javed\Desktop\customSitemapGenerator\menusList.txt";
            }
            else if (fileName == "locations")
            {
                filePath = @"C:\Users\M. Kashif Javed\Desktop\customSitemapGenerator\locationsList.txt";
            }
            else
            {
                filePath = @"C:\Users\M. Kashif Javed\Desktop\customSitemapGenerator\sitemap-" + fileName + ".xml";
            }

            // check, if file exist or not.
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine("\n");
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

                await Write(sw, str);

                //sw.WriteLine("<url>");
                //sw.WriteLine("<loc>" + str + "</loc>"); //Url String
                //sw.WriteLine("<lastmod>" + DateTime.Now + "</lastmod>");
                //sw.WriteLine("</url>");

                // unComment following when writing to file completely finished.
                //sw.WriteLine("</urlset>");
            }
        }

        private static async Task Write(StreamWriter sw, string str)
        {
            sw.WriteLine("<url>");
            sw.WriteLine("<loc>" + str + "</loc>"); //Url String
            sw.WriteLine("<lastmod>" + DateTime.Now + "</lastmod>");
            sw.WriteLine("</url>");
        }
    }
}