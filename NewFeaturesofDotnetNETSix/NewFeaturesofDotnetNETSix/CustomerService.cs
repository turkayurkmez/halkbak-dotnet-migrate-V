using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewFeaturesofDotnetNETSix
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public decimal Budget { get; set; }

        public DateOnly RegisteredDate { get; set; }
    }
    public class CustomerService
    {
        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new(){ Id = 1, Name="Ülker", Country="Türkiye", Budget=1000000},
                new(){ Id = 2, Name="VW", Country="Almanya", Budget=25000000},
                new(){ Id = 3, Name="Eti", Country="Türkiye", Budget=1000000},
                new(){ Id = 4, Name="XYZ", Country="Türkiye", Budget=3000000},

            };
        }
    }
}
