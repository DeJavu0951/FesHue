using System.ComponentModel.DataAnnotations;

namespace Fes.Model
{
	public class TicketModel
	{
		[Required]
		[MaxLength(100)]
		public string? TicketName { get; set; }
		[Required]
		public decimal Price { get; set; }
	}
}
