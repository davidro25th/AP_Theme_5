using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Domain.Entities.Configuration_Data
{
    public class Worker
    {
		public Worker(string id)
		{
			this.id = id;
		}

		protected string firstname;
		protected string lastname;
		protected string id;
		protected string phone_number;

		public string Firstname { get { return firstname; } }
		public string Lastname { get { return lastname; } }
		protected string Id { get { return Id; } }
		public string PhoneNumber { get { return phone_number; } }

	}
}
