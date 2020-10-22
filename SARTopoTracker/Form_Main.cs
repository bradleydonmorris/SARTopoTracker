using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Device.Location;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SARTopoTracker.Listeners;

namespace SARTopoTracker
{
	public partial class Form_Main : Form
	{

		private Dictionary<String, Int32> _AssetRowIndexes { get; set; }

		private String _CallSign { get; set; }
		private Int32 _DefaultSendSeconds { get; set; }
		private Listeners.IListener[] _Listeners { get; set; }

		//private AgwpePort.AgwpePort _AgwePort;
		//private System.Device.Location.GeoCoordinateWatcher _GeoCoordinateWatcher { get; set; }
		
		public Form_Main()
		{
			InitializeComponent();
			this.TextBox_SARTopoServer.Text = Program.Config.SARTopoSettings.ToString();
			this.TextBox_AGWPEPort.Text = Program.Config.AGWPEPortSettings.ToString();
		}


		private void Form_Main_Load(object sender, EventArgs e)
		{
			//this._GeoCoordinateWatcher = new System.Device.Location.GeoCoordinateWatcher(System.Device.Location.GeoPositionAccuracy.High);
			//this._GeoCoordinateWatcher.StatusChanged += GeoCoordinateWatcher_StatusChanged;
			//this._GeoCoordinateWatcher.Start();
		}

		//private void GeoCoordinateWatcher_StatusChanged(object sender, GeoPositionStatusChangedEventArgs e)
		//{

		//	Console.WriteLine("Label, TimeStamp, Latitude, Longitude, Altitude, Course, Speed, Horizontal Accuracy, Verticle Accuracy");
		//	Console.WriteLine
		//	(
		//		String.Format
		//		(
		//			"{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",
		//			this._GeoCoordinateWatcher.Position.Timestamp.ToUniversalTime().ToString("yyyy-MM-dd HH:mm:ss.fffffffZ"),
		//			this._GeoCoordinateWatcher.Position.Location.Latitude,
		//			this._GeoCoordinateWatcher.Position.Location.Longitude,
		//			this._GeoCoordinateWatcher.Position.Location.Altitude,
		//			this._GeoCoordinateWatcher.Position.Location.Course,
		//			this._GeoCoordinateWatcher.Position.Location.Speed,
		//			this._GeoCoordinateWatcher.Position.Location.HorizontalAccuracy,
		//			this._GeoCoordinateWatcher.Position.Location.VerticalAccuracy
		//		)
		//	);


		//}

		private void Button_EditSARTopoServer_Click(object sender, EventArgs e)
		{
			if (this.TextBox_SARTopoServer.ReadOnly)
			{
				this.TextBox_SARTopoServer.ReadOnly = false;
				this.Button_EditSARTopoServer.Text = "Save";
			}
			else
			{
				this.TextBox_SARTopoServer.ReadOnly = true;
				Program.Config.SARTopoSettings = new Config.SARTopoSettings(this.TextBox_SARTopoServer.Text);
				Program.Config.Save();
				this.Button_EditSARTopoServer.Text = "Edit";
			}
		}

		private void Button_EditAGWPEServer_Click(object sender, EventArgs e)
		{
			Form_AGWPEPort formAGWPEPort = new Form_AGWPEPort() { AGWPEPortSettings = Program.Config.AGWPEPortSettings };
			if (formAGWPEPort.ShowDialog(this) == DialogResult.OK)
			{
				Program.Config.AGWPEPortSettings = formAGWPEPort.AGWPEPortSettings;
				Program.Config.Save();
				this.TextBox_AGWPEPort.Text = formAGWPEPort.AGWPEPortSettings.ToString();
			}
		}

		private void Button_Start_Click(object sender, EventArgs e)
		{
			this.Button_Start.Enabled = false;
			this.DataGridView_Positions.Rows.Clear();
			this._Listeners = new Listeners.IListener[3];
			this._AssetRowIndexes = new Dictionary<String, Int32>();

			this._Listeners[0] = new Listeners.LocationServiceListener();
			this._Listeners[0].DataReceivedEvent += new Listeners.DataReceivedEventHandler(this._ListenerDataReceived);
			this._Listeners[0].Start();

			this._Listeners[1] = new Listeners.AGWPEListener(Program.Config.AGWPEPortSettings);
			this._Listeners[1].DataReceivedEvent += new Listeners.DataReceivedEventHandler(this._ListenerDataReceived);
			this._Listeners[1].Start();

			this._Listeners[2] = new Listeners.GarminListener();
			this._Listeners[2].DataReceivedEvent += new Listeners.DataReceivedEventHandler(this._ListenerDataReceived);
			this._Listeners[2].Start();
			this.Button_Stop.Enabled = true;
		}

		private void Button_Stop_Click(object sender, EventArgs e)
		{
			this.Button_Stop.Enabled = false;
			this._Listeners[0].Stop();
			this._Listeners[1].Stop();
			this._Listeners[2].Stop();

			this._Listeners[0].Dispose();
			this._Listeners[1].Dispose();
			this._Listeners[2].Dispose();
			this.Button_Start.Enabled = true;
		}

		private void _ListenerDataReceived(object sender, DataReceivedEventArgs e)
		{
			Int32 index = -1;
			if (!this._AssetRowIndexes.ContainsKey(e.Asset.Identifier))
			{
				this.DataGridView_Positions.Invoke(new Action(() => index = this.DataGridView_Positions.Rows.Add()));
				this._AssetRowIndexes.Add(e.Asset.Identifier, index);
			}
			else
				index = this._AssetRowIndexes[e.Asset.Identifier];
			this.DataGridView_Positions.Rows[index].Cells["Column_Identifier"].Value = e.Asset.Identifier;
			this.DataGridView_Positions.Rows[index].Cells["Column_TimeStamp"].Value = e.Asset.Time;
			this.DataGridView_Positions.Rows[index].Cells["Column_Latitude"].Value = e.Asset.Latitude;
			this.DataGridView_Positions.Rows[index].Cells["Column_Longitude"].Value = e.Asset.Longitude;
			this.DataGridView_Positions.Rows[index].Cells["Column_Altitude"].Value = e.Asset.Altitude;
			this.DataGridView_Positions.Rows[index].Cells["Column_Comment"].Value = e.Asset.Comment;
		}

	}
}
