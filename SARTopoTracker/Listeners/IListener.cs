using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SARTopoTracker.Listeners
{
	public delegate void DataReceivedEventHandler(object sender, DataReceivedEventArgs e);
	public delegate void ExceptionEventHandler(object sender, ExceptionEventArgs e);

	public interface IListener : IDisposable
	{
		void Start();
		void Stop();
		event DataReceivedEventHandler DataReceivedEvent;
		event ExceptionEventHandler ExceptionEvent;
	}
}
