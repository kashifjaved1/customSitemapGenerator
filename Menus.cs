using System;
using System.Collections.Generic;
using System.Text;

namespace customSitemapGenerator
{
    //public class LevelCTE5
    //{
    //}

    //public class LevelCTE4
    //{
    //    public List<LevelCTE5> Level_CTE5 { get; set; }
    //}

    public class LevelCTE3
    {
        // public List<LevelCTE4> Level_CTE4 { get; set; }
        public int? CategoryId2 { get; set; }
        public string CategoryName2 { get; set; }
    }

    public class LevelCTE2
    {
        public int CategoryId1 { get; set; }
        public string CategoryName1 { get; set; }
        public List<LevelCTE3> Level_CTE3 { get; set; }
    }

    public class MenuData
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<LevelCTE2> Level_CTE2 { get; set; }
    }

    public class MenuRoot
    {
        public List<MenuData> MenuData { get; set; }
    }
}
