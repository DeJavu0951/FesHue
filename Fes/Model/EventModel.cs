using System.ComponentModel.DataAnnotations;

namespace Fes.Model
{
	public class EventModel
	{
		[Required]
		[MaxLength(100)]
		public string? Eventname { get; set; }
		public DateTime  StartAt { get; set; }
		public int ScheduleId { get; set; }
	}
}
