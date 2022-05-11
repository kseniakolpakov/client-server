
public class FlightDTO
{

	public string Number { get; set; }
	public string Duration { get; set; }
	public string TimeOfDeparture { get; set; }
	public string TimeOfArrival { get; set; }

	public int[] Tickets { get; set; }
	public int Airplane { get; set; }
    public int CityOfArrival { get; set; }
    public int CityOfDeparture { get; set; }
}

