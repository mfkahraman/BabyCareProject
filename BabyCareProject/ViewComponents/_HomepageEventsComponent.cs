using BabyCareProject.Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BabyCareProject.ViewComponents
{
    public class _HomepageEventsComponent : ViewComponent
    {
        private readonly IEventService _eventService;

        public _HomepageEventsComponent(IEventService eventService)
        {
            _eventService = eventService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Son etkinlik tarihi en yakın olan ilk 3 etkinliği çekiyoruz
            var events = await _eventService.GetAllAsync();
            var upcomingEvents = events
                .OrderBy(e => DateTime.Parse(e.Date))
                .Take(3)
                .ToList();

            return View(upcomingEvents);
        }
    }
}
