using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketBooking
{
	class Program
	{
		static void Main()
		{
			int step = 0;

			string path = "Tickets.txt";
			MainMenu menu = new MainMenu();
			MainMenuCredits menuCredits = new MainMenuCredits();
			FileController controller = new FileController();
			FileGenerator filegen = new FileGenerator();
			List<Ticket> repertoire = controller.ReadFromFile(path);
			List<Ticket> myTicketList = new List<Ticket>();

			bool alreadyBooked = false;
			bool alreadyRefunded = false;
			
			while (step != 7)
			{
				switch (step)
				{
					case 0:
					{
						alreadyBooked = true;
						alreadyRefunded = true;
						menu.ShowMenu();
						char x = menu.ReadUserInput();
						if (x == '1') step = 1;
						else if (x == '2') step = 2;
						else if (x == '3') step = 3;
						else if (x == '4') step = 4;
						else if (x == '5') step = 5;
						else if (x == '6') step = 6;
						else if (x == '7') step = 7;
						break;
					}

					case 1:
					{
						Console.Clear();
						if (alreadyBooked)
						{
							Console.Out.Write("Enter ticket ID: ");
							int yourTicketID = Int32.Parse(Console.ReadLine());
							bool isPresent = false;
							foreach (Ticket ticket in repertoire.ToList())
							{
								if (ticket.Id == yourTicketID)
								{
									myTicketList.Add(ticket);
									repertoire.Remove(ticket);
									isPresent = true;
								}
							}

							if (!isPresent)
							{
								Console.Out.WriteLine("There is no ticket with given ID in current repertoire");
							}
							alreadyBooked = false;
						}
						Console.Out.WriteLine("\n\n=================================\n\n[1] Return");
						char x = menu.ReadUserInput();
						if (x == '1') step = 0;
						break;
					}

					case 2:
					{
						showTickets(repertoire);
						Console.Out.WriteLine("\n\n=================================\n\n[1] Return");
						controller.WriteToFile(repertoire, path);
						char x = menu.ReadUserInput();
						if (x == '1') step = 0;
						break;
					}

					case 3:
					{
						Console.Clear();
						if (myTicketList.Count != 0)
						{
							showTickets(myTicketList);
						}
						else
						{
							Console.Out.WriteLine("Your ticket list is empty!");
						}
						Console.Out.WriteLine("\n\n=================================\n\n[1] Return");
						char x = menu.ReadUserInput();
						if (x == '1') step = 0;
						break;
					}

					case 4:
					{
						Console.Clear();
							
						if (alreadyRefunded)
						{
							if (myTicketList.Count != 0)
							{
								Console.Out.Write("Enter ticket ID: ");
								int yourTicketID = Int32.Parse(Console.ReadLine());
								bool isPresent = false;
								foreach (Ticket ticket in myTicketList.ToList())
								{
									if (ticket.Id == yourTicketID)
									{
										repertoire.Add(ticket);
										myTicketList.Remove(ticket);
										isPresent = true;
									}
								}

								if (!isPresent)
								{
									Console.Out.WriteLine("There is no ticket with given ID in current repertoire");
								}
							}
							else
							{
								Console.Out.WriteLine("Your ticket list is empty!");
							}
							alreadyBooked = false;
						}
						Console.Out.WriteLine("\n\n=================================\n\n[1] Return");
						char x = menu.ReadUserInput();
						if (x == '1') step = 0;
						break;
					}

					case 5:
					{
						menuCredits.ShowMenu();
						char x = menu.ReadUserInput();
						if (x == '5') step = 0;
						break;
					}

					case 6:
					{
						Console.Clear();
						repertoire.Clear();
						myTicketList.Clear();
						filegen.GenerateDataToFile(path);
						repertoire = filegen.ReadFromFile(path);
						Console.Out.WriteLine("New random repertoire generated!");
						Console.Out.WriteLine("\n\n=================================\n\n[1] Return");
						char x = menu.ReadUserInput();
						if (x == '1') step = 0;
						break;
					}

					case 7:
					{
						break;
					}
				}
			}

			void showTickets(List<Ticket> list)
			{
				Console.Clear();
				foreach (Ticket T in list)
				{
					T.PrintTicket();
				}
			}
		}
	}
}