using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SARTopoTracker
{
	public partial class Form_AGWPEPort : Form
	{
		public Config.AGWPEPortSettings AGWPEPortSettings { get; set; }

		public Form_AGWPEPort()
		{
			InitializeComponent();
		}

		private void Form_AGWPEPort_Load(object sender, EventArgs e)
		{
			if (this.AGWPEPortSettings != null)
			{
				this.TextBox_Config_AGWPEServerAddress.Text = this.AGWPEPortSettings.ServerAddress;
				this.TextBox_Config_AGWPEServerPort.Text = this.AGWPEPortSettings.ServerPort.ToString();
				this.TextBox_Config_AGWPERadioPort.Text = this.AGWPEPortSettings.RadioPort.ToString();
			}
		}

		private void Button_Save_Click(object sender, EventArgs e)
		{
			this.AGWPEPortSettings = new Config.AGWPEPortSettings()
			{
				ServerAddress = this.TextBox_Config_AGWPEServerAddress.Text,
				ServerPort = Int32.Parse(this.TextBox_Config_AGWPEServerPort.Text),
				RadioPort = Byte.Parse(this.TextBox_Config_AGWPERadioPort.Text)
			};
		}
	}
}
