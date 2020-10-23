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
		private Dictionary<String, DateTimeOffset> _AssetLastPostTime { get; set; }

		private String _CallSign { get; set; }
		private Int32 _DefaultSendSeconds { get; set; }
		private Listeners.IListener[] _Listeners { get; set; }
		private SARTopoTracker.SARTopoClient.Client _SARTopoClient { get; set; }

		public Form_Main()
		{
			InitializeComponent();
			this.TextBox_ThisStationIdentifier.Text = Program.Config.ThisStationIdentifier;
			this.TextBox_SARTopoServer.Text = Program.Config.SARTopoSettings.ToString();
			this.TextBox_AGWPEPort.Text = Program.Config.AGWPEPortSettings.ToString();
			this.TextBox_GarminPrefix.Text = Program.Config.GarminPrefix;
			this.TextBox_SARTopoUpdateSeconds.Text = Program.Config.SARTopoUpdateSeconds.ToString();
		}

		private void Form_Main_Load(object sender, EventArgs e)
		{
		}

		private void Button_EditThisStationIdentifier_Click(object sender, EventArgs e)
		{
			if (this.TextBox_ThisStationIdentifier.ReadOnly)
			{
				this.TextBox_ThisStationIdentifier.ReadOnly = false;
				this.Button_EditThisStationIdentifier.Text = "Save";
			}
			else
			{
				this.TextBox_ThisStationIdentifier.ReadOnly = true;
				Program.Config.ThisStationIdentifier = this.TextBox_ThisStationIdentifier.Text;
				Program.Config.Save();
				this.Button_EditThisStationIdentifier.Text = "Edit";
			}
		}

		private void Button_EditSARTopoServer_Click(object sender, EventArgs e)
		{
			Form_SARTopoSettings formSARTopoSettings = new Form_SARTopoSettings() { SARTopoSettings = Program.Config.SARTopoSettings };
			if (formSARTopoSettings.ShowDialog(this) == DialogResult.OK)
			{
				Program.Config.SARTopoSettings = formSARTopoSettings.SARTopoSettings;
				Program.Config.Save();
				this.TextBox_AGWPEPort.Text = formSARTopoSettings.SARTopoSettings.ToString();
			}
		}

		private void Button_EditAGWPEServer_Click(object sender, EventArgs e)
		{
			Form_AGWPEPortSettings formAGWPEPort = new Form_AGWPEPortSettings() { AGWPEPortSettings = Program.Config.AGWPEPortSettings };
			if (formAGWPEPort.ShowDialog(this) == DialogResult.OK)
			{
				Program.Config.AGWPEPortSettings = formAGWPEPort.AGWPEPortSettings;
				Program.Config.Save();
				this.TextBox_AGWPEPort.Text = formAGWPEPort.AGWPEPortSettings.ToString();
			}
		}

		private void Button_EditGarminPrefix_Click(object sender, EventArgs e)
		{
			if (this.TextBox_GarminPrefix.ReadOnly)
			{
				this.TextBox_GarminPrefix.ReadOnly = false;
				this.Button_EditGarminPrefix.Text = "Save";
			}
			else
			{
				this.TextBox_GarminPrefix.ReadOnly = true;
				Program.Config.GarminPrefix = this.TextBox_GarminPrefix.Text;
				Program.Config.Save();
				this.Button_EditGarminPrefix.Text = "Edit";
			}
		}

		private void Button_Start_Click(object sender, EventArgs e)
		{
			this.Button_Start.Enabled = false;

			this.Button_EditThisStationIdentifier.Enabled = false;
			this.Button_EditSARTopoServer.Enabled = false;
			this.Button_EditAGWPEPort.Enabled = false;
			this.Button_EditGarminPrefix.Enabled = false;
			this.Button_EidtSARTopoUpdateSeconds.Enabled = false;

			this.DataGridView_Positions.Rows.Clear();
			this._Listeners = new Listeners.IListener[3];
			this._AssetRowIndexes = new Dictionary<String, Int32>();
			this._AssetLastPostTime = new Dictionary<String, DateTimeOffset>();

			this._SARTopoClient = new SARTopoClient.Client(Program.Config.SARTopoSettings.URI, Program.Config.SARTopoSettings.MapURI);

			this._Listeners[0] = new Listeners.LocationServiceListener(Program.Config.ThisStationIdentifier);
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

			this.Button_EditThisStationIdentifier.Enabled = true;
			this.Button_EditSARTopoServer.Enabled = true;
			this.Button_EditAGWPEPort.Enabled = true;
			this.Button_EditGarminPrefix.Enabled = true;
			this.Button_EidtSARTopoUpdateSeconds.Enabled = true;
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

			this.DataGridView_Positions.Invoke(new Action(() => this.DataGridView_Positions.Rows[index].Cells["Column_Identifier"].Value = e.Asset.Identifier));
			this.DataGridView_Positions.Invoke(new Action(() => this.DataGridView_Positions.Rows[index].Cells["Column_TimeStamp"].Value = e.Asset.Time));
			this.DataGridView_Positions.Invoke(new Action(() => this.DataGridView_Positions.Rows[index].Cells["Column_Latitude"].Value = e.Asset.Latitude));
			this.DataGridView_Positions.Invoke(new Action(() => this.DataGridView_Positions.Rows[index].Cells["Column_Longitude"].Value = e.Asset.Longitude));
			this.DataGridView_Positions.Invoke(new Action(() => this.DataGridView_Positions.Rows[index].Cells["Column_Altitude"].Value = e.Asset.Altitude));
			this.DataGridView_Positions.Invoke(new Action(() => this.DataGridView_Positions.Rows[index].Cells["Column_Comment"].Value = e.Asset.Comment));

			DateTimeOffset lastSentTime = DateTimeOffset.MinValue;
			if (this._AssetLastPostTime.ContainsKey(e.Asset.Identifier))
				lastSentTime = this._AssetLastPostTime[e.Asset.Identifier];
			else
			{
				this._AssetLastPostTime.Add(e.Asset.Identifier, DateTimeOffset.UtcNow);
				lastSentTime = this._AssetLastPostTime[e.Asset.Identifier];
			}
			if
			(
				!e.Asset.Time.Equals(DateTimeOffset.MinValue)
				&& lastSentTime.AddSeconds(this._DefaultSendSeconds) < DateTimeOffset.UtcNow
			)
			{
				this._AssetLastPostTime[e.Asset.Identifier] = DateTimeOffset.UtcNow;
				if (Program.Config.ThisStationIdentifier.Equals(e.Asset.Identifier))
					this._SARTopoClient.AddMarker(e.Asset.Identifier, null, e.Asset.Latitude, e.Asset.Longitude, new SARTopoClient.Marker());
				else
					this._SARTopoClient.UpdateLocator(e.Asset.Identifier, e.Asset.Latitude, e.Asset.Longitude);
			}
		}

		private void Button_EidtSARTopoUpdateSeconds_Click(object sender, EventArgs e)
		{
			if (this.TextBox_SARTopoUpdateSeconds.ReadOnly)
			{
				this.TextBox_SARTopoUpdateSeconds.ReadOnly = false;
				this.Button_EidtSARTopoUpdateSeconds.Text = "Save";
			}
			else
			{
				this.TextBox_SARTopoUpdateSeconds.ReadOnly = true;
				Program.Config.SARTopoUpdateSeconds = Int32.Parse(this.TextBox_SARTopoUpdateSeconds.Text);
				Program.Config.Save();
				this.Button_EidtSARTopoUpdateSeconds.Text = "Edit";
			}
		}

		private void TextBox_SARTopoUpdateSeconds_KeyPress(object sender, KeyPressEventArgs e)
		{
			if
			(
				!Char.IsControl(e.KeyChar)
				&& !Char.IsDigit(e.KeyChar)
				&& !e.KeyChar.Equals('.')
			)
				e.Handled = true;
		}
	}
}
