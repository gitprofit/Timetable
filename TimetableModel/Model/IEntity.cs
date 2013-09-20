using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimetableCore.Model
{
	public interface IEntity
	{
		int ID { get; set; }
		string Name { get; set; }
	}
}
