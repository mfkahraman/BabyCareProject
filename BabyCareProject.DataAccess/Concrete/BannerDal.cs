using BabyCareProject.DataAccess.Abstract;
using BabyCareProject.Entity.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.DataAccess.Concrete
{
    public class BannerDal : GenericRepository<Banner>, IBannerDal
    {
        public BannerDal(IMongoDatabase database, IDatabaseSettings settings) : base(database, settings.BannerCollectionName)
        {
        }
    }
}
