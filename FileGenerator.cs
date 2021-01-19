using System;
using System.Collections.Generic;
using System.IO;

namespace CinemaTicketBooking
{
	class FileGenerator : FileController
	{
		public static Random rnd = new Random();
		readonly List<int> movieTimes = new List<int>() { 60, 90, 120, 150 };
		readonly List<int> prizeRange = new List<int>() { 20, 30, 35, 50 };
		readonly List<MovieTitle> movieTitleList = new List<MovieTitle>();
		readonly List<Ticket> repertoir = new List<Ticket>();
		public void GenerateDataToFile(string path)
		{
			ReadTitlesFromFile("Titles.txt");
			int year = 2021;
			int month = rnd.Next(1, 4);
			int hour = 8;
			int minute = 0;
			int second = 0;
			double prize;
			for (int i = 1; i < 8; i++)
			{
				int row = rnd.Next(1, 11);
				int seat = rnd.Next(1, 51);
				int movieTime = movieTimes[rnd.Next(0, 4)];
				prize = prizeRange[rnd.Next(0, 4)];
				MovieTitle movieTitle;
				do
				{
					movieTitle = movieTitleList[rnd.Next(0, movieTitleList.Count)];
					foreach (MovieTitle title in movieTitleList)
					{
						if (title.Title == movieTitle.Title)
						{
							title.IsUsed = true;
							continue;
						}
						break;
					}
				} while (movieTitle.IsUsed);
				Ticket firstTicket = new Ticket(new DateTime(year, month, i, hour, minute, second), row, seat, prize, 
					movieTime) {Id = ReturnNextId(repertoir), Title = movieTitle.Title};
				repertoir.Add(firstTicket);
				for(int j=0; j<5; j++)
				{
					row = rnd.Next(1, 11);
					seat = rnd.Next(1, 51);
					movieTime = movieTimes[rnd.Next(0, 4)];
					prize = prizeRange[rnd.Next(0, 4)];
					do
					{
						movieTitle = movieTitleList[rnd.Next(0, movieTitleList.Count)];
						foreach (MovieTitle title in movieTitleList)
						{
							if (title.Title == movieTitle.Title)
							{
								title.IsUsed = true;
								continue;
							}
							break;
						}
					} while (movieTitle.IsUsed);
					Ticket tempTicket = new Ticket(
						firstTicket.endDate,
						row,
						seat,
						prize,
						movieTime) {Id = ReturnNextId(repertoir), Title = movieTitle.Title};
			
					repertoir.Add(tempTicket);
					firstTicket = tempTicket;
				}
			}
			WriteToFile(repertoir, path);
		}

		internal int ReturnNextId(List<Ticket> listOfTickets)
		{
			int id = 0;
			foreach (Ticket ticket in listOfTickets)
			{
				if (ticket.Id > id) id = ticket.Id;
			}
			return id + 1;
		}

		private void ReadTitlesFromFile(string path)
		{
			string line;
			StreamReader reader = new StreamReader(path);
			while ((line = reader.ReadLine()) != null)
			{
				movieTitleList.Add(new MovieTitle(line));
			}
		}
	}
}
