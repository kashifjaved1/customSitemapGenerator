using System;
using System.Collections.Generic;
using System.Text;

namespace customSitemapGenerator
{
    public class CityAreaCode
    {
        public int? CityAreaId { get; set; }
        public string CityAreaName { get; set; }
    }

    public class CityCode
    {
        public int CityId { get; set; }
        public string CityName { get; set; }
        public List<CityAreaCode> CityAreaCode { get; set; }
    }

    public class StatesCode
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
        public List<CityCode> CityCode { get; set; }
    }

    public class Locations
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public string CountryCurrencyCode { get; set; }
        public List<StatesCode> StatesCode { get; set; }
    }

    public class LocationRoot
    {
        public List<Locations> LocationsData { get; set; }
    }
}
