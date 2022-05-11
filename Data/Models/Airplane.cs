using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Airplane
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column(Order = 1)]
	public int Id { get; set; }
	public int NumberOfBussinessClassSeats { get; set; }
	public int NumberOfEconomyClassSeats { get; set; }

	public IEnumerable<Flight> Flights { get; set; }
}

