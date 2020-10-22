using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgwpePort;
using SARTopoTracker.Config;

namespace SARTopoTracker.Listeners
{
	public class AGWPEListener : IListener
	{
		private AgwpePort.AgwpePort _AgwePort;

		public AGWPEListener(AGWPEPortSettings agwpePortSettings)
		{
			
			this._AgwePort = new AgwpePort.AgwpePort(agwpePortSettings.RadioPort, agwpePortSettings.ServerAddress, agwpePortSettings.ServerPort);
			this._AgwePort.FrameReceived += new AgwpePort.AgwpePort.AgwpeFrameReceivedEventHandler(AgwePort_FrameReceived);
		}

		public event DataReceivedEventHandler DataReceivedEvent;
		public event ExceptionEventHandler ExceptionEvent;

		public void Start()
		{
			this._AgwePort.Open();
			this._AgwePort.StartMonitoring();
		}

		private void AgwePort_FrameReceived(object sender, AgwpeEventArgs e)
		{
			try
			{
				if (e.FrameData is AgwpeMoniUnproto agwpeMoniUnproto)
				{
					HamAprsParser.AprsPacket aprsPacket = HamAprsParser.AprsPacket.Create
					(
						String.Format
						(
							"{0}>{1}:{2}",
							e.FrameHeader.CallFrom,
							e.FrameHeader.CallTo,
							agwpeMoniUnproto.DataString
						)
					);
					Assets.APRSAsset aprsAsset = new Assets.APRSAsset(aprsPacket);
					DataReceivedEvent?.Invoke
					(
						this,
						new DataReceivedEventArgs(aprsAsset)
					);
				}
			}
			catch (Exception exception)
			{
				ExceptionEvent?.Invoke(this, new ExceptionEventArgs(new Exception[] { exception }));
			}
		}
	}
}
