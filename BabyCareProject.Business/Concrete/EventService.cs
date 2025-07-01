using AutoMapper;
using BabyCareProject.Business.Abstract;
using BabyCareProject.DataAccess.Abstract;
using BabyCareProject.Entity.Dtos.EventDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Concrete
{
    public class EventService : GenericService<Event, CreateEventDto, UpdateEventDto, ResultEventDto>, IEventService
    {
        public EventService(IGenericRepository<Event> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
