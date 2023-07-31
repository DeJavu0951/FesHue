using Fes.Data;
using Fes.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fes.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TicketController : ControllerBase
	{
		private readonly DataBContext _context;

		public TicketController(DataBContext context)
		{
			_context = context;
		}
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
		{
			var tickets = await _context.Tickets.ToListAsync();
			return Ok(tickets);
		}
		[HttpGet("{id}")]
		public IActionResult GetbyId(int id)
		{
			var tickets = _context.Tickets.SingleOrDefault(t => t.TicketId == id);
			if (tickets != null)
			{
				return Ok(tickets);
			}
			else
			{
				return BadRequest();
			}
		}
		[HttpPost]
		public IActionResult CreateNew(TicketModel model)
		{
			try
			{
				var @ticket = new Ticket
				{
					TicketName = model.TicketName,
					Price = model.Price,
				};
				_context.Tickets.Add(@ticket);
				_context.SaveChanges();
				return Ok();
			}
			catch
			{
				return BadRequest();
			}
		}
		[HttpPut("{id}")]
		public IActionResult UpdatebyId(int id, TicketModel model)
		{
			var ticket = _context.Tickets.SingleOrDefault(tk => tk.TicketId == id);
			if (ticket != null)
			{
				ticket.TicketName = model.TicketName;
				ticket.Price = model.Price;
				_context.SaveChanges();
				return Ok(ticket);
			}
			else
			{
				return BadRequest();
			}
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteTicket(int id)
		{
			var ticket = await _context.Tickets.FindAsync(id);
			if (ticket == null)
			{
				return NotFound();
			}
			_context.Tickets.Remove(ticket);
			await _context.SaveChangesAsync();
			return Ok();
		}
	}
}

