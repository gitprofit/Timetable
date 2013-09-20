using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableCore.Model
{
	public interface IOwnable
	{
		 User Owner { get; set; } 
	}
}
