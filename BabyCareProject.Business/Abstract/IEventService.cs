﻿using BabyCareProject.Entity.Dtos.EventDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Abstract
{
    public interface IEventService : IGenericService<CreateEventDto,UpdateEventDto,ResultEventDto,Event>
    {
    }
}
