using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationClient
{
    public class Region
    {
        public string name { get; set; }
        public List<City> citieslist { get; set; }
    }
}
