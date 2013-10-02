using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableCore.Util.Errors
{
	public class EntityPersistenceException : Exception
	{
		public EntityPersistenceException()
			: base() { }

		public EntityPersistenceException(string message)
			: base(message) { }

		public EntityPersistenceException(Exception innerException)
			: base("", innerException) { }

		public EntityPersistenceException(string message, Exception innerException)
			: base(message, innerException) { }
	}
}
