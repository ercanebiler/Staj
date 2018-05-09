using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductWebSite.Models
{
    public class ProductClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime lastUpdatedTime { get; set; }
    }
}