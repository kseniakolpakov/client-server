using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Flight
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column(Order = 1)]
	public int Id { get; set; }
	public string Number { get; set; }
	public string Duration { get; set; }
	public string TimeOfDeparture { get; set; }
	public string TimeOfArrival { get; set; }

	public IEnumerable<Ticket> Tickets { get; set; }
	public Airplane Airplane { get; set; }
    public CityOfArrival CityOfArrival { get; set; }
    public CityOfDeparture CityOfDeparture { get; set; }
}

