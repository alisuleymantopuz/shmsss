using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;

namespace SelfHost1.ServiceModel
{
    [Route("/shipper/get/{Id}")]
    public class ShipperGetRequest : IReturn<ShipperGetResponse>
    {
        public int Id { get; set; }
    }

}