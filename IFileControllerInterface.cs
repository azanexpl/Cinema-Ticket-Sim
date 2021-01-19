using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketBooking
{
	interface IFileControllerInterface
	{
		void WriteToFile(List<Ticket> ticketList, string path);
		List<Ticket> ReadFromFile(string path);
	}
}
