using Fes.Data;
using Fes.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Fes.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventController : ControllerBase
	{
		private readonly DataBContext _context;

		public EventController(DataBContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
		{
			var events = await _context.Events.Include("Schedule").ToListAsync();
			return Ok(events);
		}
		[HttpGet("{id}")]
		public IActionResult GetbyId(int id)
		{
			var events = _context.Events.SingleOrDefault(ev => ev.Eventid == id);
			if (events != null)
			{
				return Ok(events);
			}
			else
			{
				return BadRequest();
			}
		}
		[HttpPost]
		public IActionResult CreateNew(EventModel model)
		{
			try
			{
				var @event = new Event
				{
					Eventname = model.Eventname,
					StartAt = DateTime.Now,
					ScheduleId = model.ScheduleId,
			};
			_context.Events.Add(@event);
			_context.SaveChanges();
			return Ok();
		}
			catch
			{
				return BadRequest();
			}
		}
		[HttpPut("{id}")]
		public IActionResult UpdatebyId(int id, EventModel model)
		{
			var events = _context.Events.SingleOrDefault(ev => ev.Eventid == id);
			if (events != null)
			{
				events.Eventname = model.Eventname;
				events.StartAt = DateTime.Now;
				events.ScheduleId = model.ScheduleId;
				_context.SaveChanges();
				return Ok(events);
			}
			else
			{
				return BadRequest();
			}
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult>  DeleteEvent(int id)
		{
			var events = await _context.Events.FindAsync(id);
			if (events == null)
			{;
				return NotFound();
			}
			_context.Events.Remove(events);
			await _context.SaveChangesAsync();
			return Ok();
		}
	}
}
