using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.Threading.Tasks;

namespace customSitemapGenerator
{
    class Writer
    {

        public static async Task WriteToFile(string str, string fileName, string action = null) //(List<string> list)
        {
            string directoryName = @"C:\sitemapXMLs";

            if (!Directory.Exists(directoryName)) Directory.CreateDirectory(directoryName);

            string filePath = null;

            if (fileName != null)
            {
                filePath = Path.Combine(directoryName, "sitemap-" + fileName + ".xml");
            }

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

                await WriteAsync(sw, str, action);
            }
        }

        private static async Task WriteAsync(StreamWriter sw, string str, string action)
        {
            string l1 = "<?xml version = \"1.0\" encoding=\"UTF-8\" ?>";
            string l2 = "<urlset";
            string l3 = "xmlns = \"http://www.sitemaps.org/schemas/sitemap/0.9\"";
            string l4 = "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"";
            string l5 = "xsi:schemaLocation=\"http://www.sitemaps.org/schemas/sitemap/0.9";
            string l6 = "http://www.sitemaps.org/schemas/sitemap/0.9/sitemap.xsd\">";
            string l7 = "</urlset>";

            if (action == "WRITE_WITH_HEADER")
            {
                sw.WriteLine(l1 + "\n" + l2 + "\n" + l3 + "\n" + l4 + "\n" + l5 + "\n" + l6 + "\n");
                sw.WriteLine("<url>");
                sw.WriteLine("<loc>" + str + "</loc>"); //Url String
                sw.WriteLine("<lastmod>2022-02-08</lastmod>");
                sw.WriteLine("<changefreq>monthly</changefreq>");
                sw.WriteLine("<priority>0.8</priority>");
                sw.WriteLine("</url>");
            }
            else if(action == "WRITE_WITH_FOOTER")
            {
                sw.WriteLine("<url>");
                sw.WriteLine("<loc>" + str + "</loc>"); //Url String
                sw.WriteLine("<lastmod>2022-02-08</lastmod>");
                sw.WriteLine("<changefreq>monthly</changefreq>");
                sw.WriteLine("<priority>0.8</priority>");
                sw.WriteLine("</url>");
                sw.WriteLine("\n" + l7);
            }
            else
            {
                sw.WriteLine("<url>");
                sw.WriteLine("<loc>" + str + "</loc>"); //Url String
                sw.WriteLine("<lastmod>2022-02-08</lastmod>");
                sw.WriteLine("<changefreq>monthly</changefreq>");
                sw.WriteLine("<priority>0.8</priority>");
                sw.WriteLine("</url>");
            }
        }
    }
}