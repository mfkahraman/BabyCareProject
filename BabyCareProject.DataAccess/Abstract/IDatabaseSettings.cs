﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.DataAccess.Abstract
{
    public interface IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string InstructorCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string BannerCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
        public string OurServiceCollectionName { get; set; }
        public string OurProgramCollectionName { get; set; }
        public string EventCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }
    }
}
