using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketBooking
{
	class Ticket : ITicketInterface
	{
		public DateTime startDate;
		public DateTime endDate;
		public int row;
		public int seat;

		public Ticket(DateTime startDate, int row, int seat, double prize, int movieLength)
		{
			this.startDate = startDate;
			this.row = row;
			this.seat = seat;
			this.Prize = Math.Round(prize, 2);
			this.MovieLength = movieLength;

			switch (movieLength)
			{
				case 60:
				{
					endDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startDate.Hour + 1, startDate.Minute, startDate.Second);
					break;
				}
				case 90:
				{
					if (startDate.Minute < 30)
					{
						endDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startDate.Hour + 1, startDate.Minute + 30, startDate.Second);
					}
					else if (startDate.Minute == 30)
					{
						endDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startDate.Hour + 2, 0, startDate.Second);
					}
					else if (startDate.Minute == 45)
					{
						endDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startDate.Hour + 2, 15, startDate.Second);
					}
					break;
				}
				case 120:
				{
					endDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startDate.Hour + 2, startDate.Minute, startDate.Second);
					break;
				}
				case 150:
				{
					if (startDate.Minute < 30)
					{
						endDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startDate.Hour + 2, startDate.Minute + 30, startDate.Second);
					}
					else if (startDate.Minute == 30)
					{
						endDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startDate.Hour + 3, 0, startDate.Second);
					}
					else if (startDate.Minute == 45)
					{
						endDate = new DateTime(startDate.Year, startDate.Month, startDate.Day, startDate.Hour + 3, 15, startDate.Second);
					}
					break;
				}
			}

		}


		public int Id { get; set; }

		public string Title { get; set; }

		public double Prize { get; set; }

		public int MovieLength { get; set; }

		public void PrintTicket()
		{
			Console.Out.WriteLine("\n=================================");
			Console.Out.WriteLine("=================================\n");
			Console.Out.WriteLine($"ID: {Id}");
			Console.Out.WriteLine($"TITLE: {Title}");
			Console.Out.WriteLine($"DATE: {startDate}");
			Console.Out.WriteLine($"ROW: {row}");
			Console.Out.WriteLine($"SEAT: {seat}");
			Console.Out.WriteLine($"MOVIE LENGTH: {MovieLength}min");
			Console.Out.WriteLine($"PRIZE: {Prize}zl");
		}

		
	}
}
