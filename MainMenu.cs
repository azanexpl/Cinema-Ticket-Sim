using System;
using System.Collections.Generic;

namespace CinemaTicketBooking
{
	class MainMenu
	{
		protected readonly List<string> menu = new List<string>();
		public MainMenu()
		{
			menu.AddRange(new string[] { "[1] Book ticket", "[2] Show repertoire", "[3] Show my tickets", "[4] Refund ticket", "[5] Show credits", "[6] Generate new repertoire", "[7] Exit" });
		}
		

		public void ShowMenu()
		{
			Console.Clear();
			foreach (string line in menu)
			{
				Console.Out.WriteLine($"{line}\n");
			}
		}

		public char ReadUserInput()
		{
			return Console.ReadKey().KeyChar;
		}
	}
}
