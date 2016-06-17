using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite.SqlServer;
using ServiceStack.OrmLite;

namespace SelfHost1.DataAccess.Repository.Implementation
{
    using Domain;
    using ServiceStack.Data;
    public class ShipperRepository : IShipperRepository
    {
        public IDbConnectionFactory DbConnectionFactory { get; set; }


        public void Save(Shipper instance)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                db.Insert<Shipper>(instance);

            }
        }

        public void Update(Shipper instance)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                db.Update<Shipper>(instance);
            }
        }

        public void Delete(Shipper instance)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                db.Delete<Shipper>(instance);
            }
        }

        public Shipper GetById(int id)
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                return db.Select<Shipper>().FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Shipper> GetAll()
        {
            using (var db = DbConnectionFactory.OpenDbConnection())
            {
                return db.Select<Shipper>();
            }
        }
    }
}
