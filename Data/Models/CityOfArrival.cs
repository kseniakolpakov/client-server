using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// город прибытия 
public class CityOfArrival
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column(Order = 1)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string CountryName { get; set; }

    public IEnumerable<Flight> Flights { get; set; }
}

