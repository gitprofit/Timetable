using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableManualTests
{
	class Program
	{
		static void Main(string[] args)
		{
			var efr1 = new EntityFrameworkRepositoryTests();
			efr1.TestUpdate();

			Console.ReadLine();
		}
	}
}
