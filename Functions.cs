using System;
using System.Collections.Generic;
using System.Text;

namespace customSitemapGenerator
{
    class Functions
    {
        public static void crossOfArrays(List<string> list1, List<string> list2, List<string> mainList)
        {
            foreach (string l1 in list1)
            {
                foreach (string l2 in list2)
                {
                    string temp = "https://bazaarr.pk/Listings/" + l1 + "/" + l2;
                    mainList.Add(temp);
                }
            }
        }

        public static void print(List<string> obj, int from, int to)
        {
            for (int i = from; i < to; i++)
            {
                Console.WriteLine(obj[i]);
            }
        }

        public static T genericReturnObj<T>(string str)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(str);
        }

        public static string fixTheString(string str)
        {
            string input = null;
            input = str.Replace(" ", "-");
            input = input.Replace("-&-", "-");
            input = input.Replace(",-", "-");
            input = input.Replace("'", "-");

            return input;
        }
    }
}
