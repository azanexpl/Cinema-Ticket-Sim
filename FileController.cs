using System;
using System.Collections.Generic;
using System.IO;

namespace CinemaTicketBooking
{
	class FileController : IFileControllerInterface
	{
		public void WriteToFile(List<Ticket> ticketList, string path)
		{
			File.WriteAllText(path, string.Empty);
			using (StreamWriter writer = File.AppendText(path))
			{
				foreach (Ticket ticket in ticketList)
				{
					string message = string.Empty;
					message += $"{ticket.Id};";
					message += $"{ticket.Title};";
					message += $"{ticket.startDate};";
					message += $"{ticket.endDate};";
					message += $"{ticket.row};";
					message += $"{ticket.seat};";
					message += $"{ticket.Prize};";
					message += $"{ticket.MovieLength};";
					writer.WriteLine(message);
				}
				writer.Close();
			}
		}

		public List<Ticket> ReadFromFile(string path)
		{
			string line;
			List<Ticket> tempTicketList = new List<Ticket>();
			try
			{
				StreamReader reader = new StreamReader(path);
				while ((line = reader.ReadLine()) != null)
				{
					string[] lineDivided = line.Split(';');
					tempTicketList.Add(new Ticket(
							DateTime.Parse(lineDivided[2]),
							Int32.Parse(lineDivided[4]),
							Int32.Parse(lineDivided[5]),
							Double.Parse(lineDivided[6]),
							Int32.Parse(lineDivided[7]))
						{ Id = Int32.Parse(lineDivided[0]), Title = lineDivided[1] });
				}
				reader.Close();
			}
			catch (FileNotFoundException)
			{
				Console.Error.WriteLine("File not found!");
			}

			return tempTicketList;
		}
	}
}
