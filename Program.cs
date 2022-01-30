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
            LocationRoot locationJObj = Functions.genericReturnObj<LocationRoot>(Inputs.locationsJsonString);
            MenuRoot menuJObj = Functions.genericReturnObj<MenuRoot>(Inputs.menusJsonString);



            List<string> _stateNames = new List<string>(),
                _cityNames = new List<string>(),
                _cityAreaNames = new List<string>();

            List<string> _parentCtg = new List<string>(),
                _childCtg = new List<string>(),
                _subChildCtg = new List<string>();

            foreach (Locations locationsData in locationJObj.LocationsData)
            {
                foreach (StatesCode states in locationsData.StatesCode)
                {
                    _stateNames.Add(Functions.fixTheString(states.StateName));

                    foreach (CityCode city in states.CityCode)
                    {
                        _cityNames.Add(Functions.fixTheString(city.CityName));

                        foreach (CityAreaCode cityArea in city.CityAreaCode)
                        {
                            if (cityArea.CityAreaName != null && cityArea.CityAreaName != "")
                            {
                                _cityAreaNames.Add(Functions.fixTheString(cityArea.CityAreaName));
                            }
                        }

                    }

                }
            }

            foreach (MenuData menu in menuJObj.MenuData)
            {
                if (menu.CategoryName != null && menu.CategoryName != "")
                {
                    _parentCtg.Add(Functions.fixTheString(menu.CategoryName));

                    foreach (LevelCTE2 childCtg in menu.Level_CTE2)
                    {
                        if (childCtg.CategoryName1 != null && childCtg.CategoryName1 != "")
                        {
                            _childCtg.Add(Functions.fixTheString(childCtg.CategoryName1));

                            foreach (LevelCTE3 subChildCtg in childCtg.Level_CTE3)
                            {
                                if (subChildCtg.CategoryName2 != null && subChildCtg.CategoryName2 != "")
                                {
                                    _subChildCtg.Add(Functions.fixTheString(subChildCtg.CategoryName2));
                                }
                            }
                        }
                    }
                }
            }

            List<string> finalURLs = new List<string>();

            foreach (string el in _stateNames)
            {
                var stringToAdd = "https://bazaarr.pk/Listings/" + el;
                finalURLs.Add(stringToAdd);
            }

            foreach (string el in _cityNames)
            {
                var stringToAdd = "https://bazaarr.pk/Listings/" + el;
                finalURLs.Add(stringToAdd);
            }

            foreach (string el in _cityAreaNames)
            {
                var stringToAdd = "https://bazaarr.pk/Listings/" + el;
                finalURLs.Add(stringToAdd);
            }

            foreach (string el in _parentCtg)
            {
                var stringToAdd = "https://bazaarr.pk/Listings/" + el;
                finalURLs.Add(stringToAdd);
            }

            foreach (string el in _childCtg)
            {
                var stringToAdd = "https://bazaarr.pk/Listings/" + el;
                finalURLs.Add(stringToAdd);
            }

            foreach (string el in _subChildCtg)
            {
                var stringToAdd = "https://bazaarr.pk/Listings/" + el;
                finalURLs.Add(stringToAdd);
            }

            List<string> menuList = new List<string>(),
                locList = new List<string>();

            for (int i = 0; i < _stateNames.Count; i++)
            {
                locList.Add(_stateNames[i]);

                for (int j = 0; j < _cityNames.Count; j++)
                {
                    locList.Add(_cityNames[j]);
                    string temp = _stateNames[i] + "/" + _cityNames[j];
                    locList.Add(temp);

                    temp = "https://bazaarr.pk/Listings/" + temp;
                    finalURLs.Add(temp);

                    for (int k = 0; k < _cityAreaNames.Count; k++)
                    {
                        locList.Add(_cityAreaNames[k]);
                        temp = _stateNames[i] + "/" + _cityAreaNames[k];
                        locList.Add(temp);

                        temp = "https://bazaarr.pk/Listings/" + temp;
                        finalURLs.Add(temp);

                        temp = _cityNames[i] + "/" + _cityAreaNames[k];
                        locList.Add(temp);

                        temp = "https://bazaarr.pk/Listings/" + temp;
                        finalURLs.Add(temp);

                        temp = _stateNames[i] + "/" + _cityNames[j] + "/" + _cityAreaNames[k];
                        locList.Add(temp);

                        temp = "https://bazaarr.pk/Listings/" + temp;
                        finalURLs.Add(temp);
                    }
                }
            }

            for (int i = 0; i < _parentCtg.Count; i++)
            {
                menuList.Add(_parentCtg[i]);

                for (int j = 0; j < _childCtg.Count; j++)
                {
                    menuList.Add(_childCtg[j]);
                    string temp = _parentCtg[i] + "/" + _childCtg[j];
                    menuList.Add(temp);

                    temp = "https://bazaarr.pk/Listings/" + temp;
                    finalURLs.Add(temp);

                    for (int k = 0; k < _subChildCtg.Count; k++)
                    {
                        menuList.Add(_subChildCtg[k]);
                        temp = _parentCtg[i] + "/" + _subChildCtg[k];
                        menuList.Add(temp);

                        temp = "https://bazaarr.pk/Listings/" + temp;
                        finalURLs.Add(temp);

                        temp = _childCtg[i] + "/" + _subChildCtg[k];
                        menuList.Add(temp);

                        temp = "https://bazaarr.pk/Listings/" + temp;
                        finalURLs.Add(temp);

                        temp = _parentCtg[i] + "/" + _childCtg[j] + "/" + _subChildCtg[k];
                        menuList.Add(temp);

                        temp = "https://bazaarr.pk/Listings/" + temp;
                        finalURLs.Add(temp);
                    }
                }
            }

            Functions.crossOfArrays(locList, menuList, finalURLs);

            Functions.print(finalURLs, 0, 50);

        }
    }
}
