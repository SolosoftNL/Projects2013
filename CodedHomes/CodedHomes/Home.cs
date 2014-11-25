using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodedHomes
{
    public class Home : IAudit
    {
        public int Id { get; set; }
        public string StreetAdress { get; set; }
        public string StreetAdress2 { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public int? Bathrooms { get; set; }
        public int Bedrooms { get; set; }
        public int SquareFeet { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }

        public string ImageName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
