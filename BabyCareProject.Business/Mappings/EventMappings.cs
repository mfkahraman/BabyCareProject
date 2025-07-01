using AutoMapper;
using BabyCareProject.Entity.Dtos.EventDtos;
using BabyCareProject.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyCareProject.Business.Mappings
{
    public class EventMappings : Profile
    {
        public EventMappings()
        {
            CreateMap<Event, CreateEventDto>().ReverseMap();
            CreateMap<Event, UpdateEventDto>().ReverseMap();
            CreateMap<Event, ResultEventDto>().ReverseMap();
            CreateMap<UpdateEventDto, ResultEventDto>().ReverseMap();
        }
    }
}
