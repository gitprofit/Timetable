using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableCore.Util.Errors
{
	public class EntityNotOwnableException : Exception
	{
		public EntityNotOwnableException()
			: base() { }

		public EntityNotOwnableException(string message)
			: base(message) { }

		public EntityNotOwnableException(Exception innerException)
			: base("", innerException) { }

		public EntityNotOwnableException(string message, Exception innerException)
			: base(message, innerException) { }
	}
}
