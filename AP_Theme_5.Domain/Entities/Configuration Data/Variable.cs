using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_Theme_5.Domain.Entities.Configuration_Data
{
    public class Variable
    {
		public Variable(string code)
		{
			this.code = code;
		}

		protected string name;
		protected string code;
		protected Measurement_Unit measurement_Unit;

		public string Name { get { return name; } }
		public string Code { get { return code; } }
        public Measurement_Unit Measurement_Units => measurement_Unit;

    }
}
