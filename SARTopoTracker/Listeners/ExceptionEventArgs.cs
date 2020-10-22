using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARTopoTracker.Listeners
{
	public class ExceptionEventArgs : EventArgs
	{
		public List<Exception> Exceptions { get; set; }

		public ExceptionEventArgs(IEnumerable<Exception> exceptions)
		{
			this.Exceptions = new List<Exception>(exceptions);
		}
	}
}
