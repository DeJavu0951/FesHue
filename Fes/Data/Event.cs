using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fes.Data
{
	[Table("Event")]
	public class Event
	{
		[Key]
		public int Eventid { get; set; }
		[Required]
		[StringLength(100)]
		public string? Eventname { get; set; }
		public DateTime StartAt { get; set; }

		
        public int ScheduleId { get; set; }

        [ForeignKey("ScheduleId")]
		public Schedule? Schedule { get; set; }
	}
}
