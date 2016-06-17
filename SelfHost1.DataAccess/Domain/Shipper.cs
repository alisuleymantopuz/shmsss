using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHost1.DataAccess.Domain
{
    [Alias("Shippers")]
    public class Shipper
    {
        [AutoIncrement]
        [Alias("ShipperID")]
        public int Id { get; set; }

        [Alias("CompanyName")]
        public string Name { get; set; }

        [Alias("Phone")]
        public string Phone { get; set; }
    }
}
