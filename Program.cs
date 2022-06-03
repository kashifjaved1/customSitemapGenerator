using System;
using System.Collections.Generic;
using System.Collections;
using System.Net.Http;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace customSitemapGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Deserializing JSON Objects.
            LocationRoot locationJObj = Functions.genericReturnObj<LocationRoot>(Inputs.locationsJsonString);
            MenuRoot menuJObj = Functions.genericReturnObj<MenuRoot>(Inputs.menusJsonString);

            // Initializing Lists.
            List<string> menuList = new List<string>(),
                locList = new List<string>();

            foreach (Locations locationsData in locationJObj.LocationsData)
            {
                foreach (StatesCode states in locationsData.StatesCode)
                {
                    string stateName = Functions.fixTheString(states.StateName);

                    if (locationsData.StatesCode.Count > 0)
                    {
                        locList.Add(stateName);

                        foreach (CityCode city in states.CityCode)
                        {
                            string cityName = Functions.fixTheString(city.CityName);
                            locList.Add(cityName);
                            locList.Add(stateName + "/" + cityName);

                            if (states.CityCode.Count > 0)
                            {
                                foreach (CityAreaCode cityArea in city.CityAreaCode)
                                {
                                    if (cityArea.CityAreaName != null && cityArea.CityAreaName != "")
                                    {
                                        string cityAreaName = Functions.fixTheString(cityArea.CityAreaName);
                                        locList.Add(cityAreaName);
                                        locList.Add(stateName + "/" + cityAreaName);
                                        locList.Add(cityName + "/" + cityAreaName);
                                        locList.Add(stateName + "/" + cityName + "/" + cityAreaName);
                                    }
                                }
                            }
                            else
                            {
                                locList.Add(cityName);
                                locList.Add(stateName + "/" + cityName);
                            }
                        }
                    }
                    else
                    {
                        locList.Add(stateName);
                    }
                }
            }

            foreach (MenuData menu in menuJObj.MenuData)
            {
                if (menu.CategoryName != null && menu.CategoryName != "")
                {
                    string ctgName0 = Functions.fixTheString(menu.CategoryName);

                    if (menu.Level_CTE2.Count > 0)
                    {
                        menuList.Add(ctgName0);

                        foreach (LevelCTE2 childCtg in menu.Level_CTE2)
                        {
                            if (childCtg.CategoryName1 != null && childCtg.CategoryName1 != "")
                            {
                                string ctgName1 = Functions.fixTheString(childCtg.CategoryName1);

                                if (childCtg.Level_CTE3.Count > 0)
                                {
                                    menuList.Add(ctgName0 + "/" + ctgName1);

                                    foreach (LevelCTE3 subChildCtg in childCtg.Level_CTE3)
                                    {
                                        if (subChildCtg.CategoryName2 != null && subChildCtg.CategoryName2 != "")
                                        {
                                            string ctgName2 = Functions.fixTheString(subChildCtg.CategoryName2);
                                            menuList.Add(ctgName0 + "/" + ctgName1 + "/" + ctgName2);
                                        }
                                    }
                                }
                                else
                                {
                                    menuList.Add(ctgName0 + "/" + ctgName1);
                                }
                            }
                        }
                    }
                    else
                    {
                        menuList.Add(ctgName0);
                    }
                }
            }

            bool breakLoop = false;
            int loopRepCounter = 0, fileIndex = 1;
            //string controlAreaName = "LOCATIONS", url = null;
            string controlAreaName = "MENUS", url = null;

            while (breakLoop != true)
            {
                //if (controlAreaName == "LOCATIONS")
                //{
                //    foreach (string l in locList)
                //    {
                //        Console.WriteLine("Outsider: " + loopRepCounter);

                //        if (loopRepCounter == 0)
                //        {
                //            Console.WriteLine("insider @0: " + loopRepCounter);
                //            url = "https://bazaarr.pk/Listings/" + l;
                //            Writer.WriteToFile(url, fileIndex.ToString(), "WRITE_WITH_HEADER");
                //            //loopRepCounter++;
                //            loopRepCounter = 1;
                //        }
                //        else if (loopRepCounter == 9999)
                //        {
                //            Console.WriteLine("insider @9999: " + loopRepCounter);
                //            url = "https://bazaarr.pk/Listings/" + l;
                //            Writer.WriteToFile(url, fileIndex.ToString(), "WRITE_WITH_FOOTER");
                //            loopRepCounter = 0;
                //            fileIndex++;
                //        }
                //        else
                //        {
                //            Console.WriteLine("insider else: " + loopRepCounter);
                //            url = "https://bazaarr.pk/Listings/" + l;
                //            Writer.WriteToFile(url, fileIndex.ToString());
                //            loopRepCounter++;
                //        }
                //    }
                //    controlAreaName = "MENUS";
                //}
                //else if
                if (controlAreaName == "MENUS")
                {
                    foreach (string m in menuList)
                    {
                        Console.WriteLine("Outsider: " + loopRepCounter);

                        if (loopRepCounter == 0)
                        {
                            Console.WriteLine("insider @0: " + loopRepCounter);
                            url = "https://bazaarr.pk/Listings/" + m;
                            Writer.WriteToFile(url, fileIndex.ToString(), "WRITE_WITH_HEADER");
                            //loopRepCounter++;
                            loopRepCounter = 1;
                        }
                        else if (loopRepCounter == 9999)
                        {
                            Console.WriteLine("insider @9999: " + loopRepCounter);
                            url = "https://bazaarr.pk/Listings/" + m;
                            Writer.WriteToFile(url, fileIndex.ToString(), "WRITE_WITH_FOOTER");
                            loopRepCounter = 0;
                            fileIndex++;
                        }
                        else
                        {
                            Console.WriteLine("insider else: " + loopRepCounter);
                            url = "https://bazaarr.pk/Listings/" + m;
                            Writer.WriteToFile(url, fileIndex.ToString());
                            loopRepCounter++;
                        }
                    }
                    controlAreaName = "MIXED";
                }
                else if (controlAreaName == "MIXED")
                {
                    foreach (string l in locList)
                    {
                        foreach (string m in menuList)
                        {
                            Console.WriteLine("Outsider: " + loopRepCounter);

                            if (loopRepCounter == 0)
                            {
                                Console.WriteLine("insider @0: " + loopRepCounter);
                                url = "https://bazaarr.pk/Listings/" + l + "/" + m;
                                Writer.WriteToFile(url, fileIndex.ToString(), "WRITE_WITH_HEADER");
                                //loopRepCounter++;
                                loopRepCounter = 1;
                            }
                            else if (loopRepCounter == 9999)
                            {
                                Console.WriteLine("insider @9999: " + loopRepCounter);
                                url = "https://bazaarr.pk/Listings/" + l + "/" + m;
                                Writer.WriteToFile(url, fileIndex.ToString(), "WRITE_WITH_FOOTER");
                                loopRepCounter = 0;
                                fileIndex++;
                            }
                            else
                            {
                                Console.WriteLine("insider else: " + loopRepCounter);
                                url = "https://bazaarr.pk/Listings/" + l + "/" + m;
                                Writer.WriteToFile(url, fileIndex.ToString());
                                loopRepCounter++;
                            }
                        }
                    }
                    breakLoop = true;
                }
            }

            // freeing up memory by clearing all lists.
            List<List<string>> listOfLists = new List<List<string>>();
            listOfLists.Add(locList);
            listOfLists.Add(menuList);

            Functions.freeUpSpace(listOfLists);
        }
    }
}
