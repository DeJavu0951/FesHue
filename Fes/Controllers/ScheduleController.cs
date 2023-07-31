using Fes.Data;
using Fes.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Fes.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ScheduleController : ControllerBase
	{
		private readonly DataBContext _context;

		public ScheduleController(DataBContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Schedule>>> GetSchedules()
		{
			var schedules = await _context.Schedules.Include("Ticket").ToListAsync();
			return Ok(schedules);
		}
		[HttpGet("{id}")]
		public IActionResult GetbyId(int id)
		{
			var schedules = _context.Schedules.SingleOrDefault(sch => sch.ScheduleId == id);
			if (schedules != null)
			{
				return Ok(schedules);
			}
			else
			{
				return BadRequest();
			}
		}
		[HttpPost]
		public IActionResult CreateNew(ScheduleModel model)
		{
			try
			{
				var @schedules = new Schedule 
				{
					Takeinplace = model.Takeinplace,
					Type = model.Type,
					TicketId = model.TicketId,
				};
				_context.Schedules.Add(@schedules);
				_context.SaveChanges();
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}
		[HttpPut("{id}")]
		public IActionResult UpdatebyId(int id, ScheduleModel model)
		{
			var schedules = _context.Schedules.SingleOrDefault(sch => sch.ScheduleId == id);
			if (schedules != null)
			{
				schedules.Takeinplace = model.Takeinplace;
				schedules.Type = model.Type;
				schedules.TicketId = model.TicketId;
				_context.SaveChanges();
				return Ok(schedules);
			}
			else
			{
				return BadRequest();
			}
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEvent(int id)
		{
			var schedule = await _context.Schedules.FindAsync(id);
			if (schedule == null)
			{
				return NotFound();
			}
			_context.Schedules.Remove(schedule);
			await _context.SaveChangesAsync();
			return Ok();
		}
	}
}
