using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketBooking
{

	class MovieTitle
	{
		public MovieTitle()
		{

		}
		public MovieTitle(string Title)
		{
			this.Title = Title;
		}

		public string Title { get; }
		public bool IsUsed { get; set; } = false;
	}
}
