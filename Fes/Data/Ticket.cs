using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fes.Data
{
	[Table("Ticket")]
	public class Ticket
	{
		[Key]
		public int TicketId { get; set; }
		[Required]
		[MaxLength(100)]
		public string? TicketName { get; set;}
		[Required]
		public decimal Price { get; set;}
		
	}
}
