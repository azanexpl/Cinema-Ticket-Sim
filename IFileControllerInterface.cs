using System.Collections.Generic;

namespace CinemaTicketBooking
{
	interface IFileControllerInterface
	{
		void WriteToFile(List<Ticket> ticketList, string path);
		List<Ticket> ReadFromFile(string path);
	}
}
