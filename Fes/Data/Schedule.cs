using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fes.Data
{
	[Table("Schedule")]
	public class Schedule
	{
		[Key]
		public int ScheduleId { get; set; }
		[Required]
		[MaxLength(100)]
		public string? Takeinplace { get; set; }
		[Required]
		[MaxLength(100)]
		public string? Type { get; set; }
		public int TicketId { get; set; }
		[ForeignKey("TicketId")]
		public Ticket? Ticket { get; set; }
	}
}
