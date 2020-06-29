using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCreditSuisse.Web.Data.Entities
{
    public class Series
    {
        public string idSerie { get; set; }
        public string titulo { get; set; }
        public Dato[] datos { get; set; }
        public string incrementos { get; set; }
    }
}
