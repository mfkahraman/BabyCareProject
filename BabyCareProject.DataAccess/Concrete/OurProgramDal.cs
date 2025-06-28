using BabyCareProject.DataAccess.Abstract;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.DataAccess.Concrete
{
    public class OurProgramDal : GenericRepository<OurProgram>, IOurProgramDal
    {
        public OurProgramDal(IMongoDatabase database, IDatabaseSettings settings) : base(database, settings.OurProgramCollectionName)
        {
        }
    }
}
