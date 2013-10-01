using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableDataAccessTests
{
	public class BaseTest
	{
		public void Write(string line)
		{
			System.Diagnostics.Debug.Write(line);
		}

		public void WriteLine(string line)
		{
			System.Diagnostics.Debug.WriteLine(line);
		}
	}
}
