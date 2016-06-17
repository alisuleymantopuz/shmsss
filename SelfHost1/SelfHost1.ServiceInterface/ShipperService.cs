using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;
using SelfHost1.ServiceModel;
using SelfHost1.DataAccess.Repository;

namespace SelfHost1.ServiceInterface
{
    public class ShipperService : Service
    {
        public IShipperRepository ShipperRepository { get; set; }

        public object Any(ShipperGetRequest request)
        {
            var shipper = ShipperRepository.GetById(request.Id);

            return new ShipperGetResponse
            {
                Name = shipper != null ? shipper.Name : string.Empty
            };
        }
    }
}