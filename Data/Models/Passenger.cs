using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Passenger
{
	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	[Column(Order = 1)]
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string DateOfBirth { get; set; }
	public string Email { get; set; }
	public string PhoneNumber { get; set; }
	public string PassportNumber { get; set; }

	public IEnumerable<Ticket> Tickets { get; set; }

}


