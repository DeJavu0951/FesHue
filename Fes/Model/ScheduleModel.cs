using System.ComponentModel.DataAnnotations;

namespace Fes.Model
{
	public class ScheduleModel
	{
		public string? Takeinplace { get; set; }
		[Required]
		[MaxLength(100)]
		public string? Type { get; set; }
		public int TicketId { get; set; }
	}
}
