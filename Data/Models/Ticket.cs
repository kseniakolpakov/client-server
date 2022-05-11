using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Ticket
{

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column(Order = 1)]
	public int Id { get; set; }
	public string Seat { get; set; }
	public string DateOfFlight { get; set; }
	public float Price { get; set; }

	public Flight Flight { get; set; }
	public Passenger Passenger { get; set; }

}
