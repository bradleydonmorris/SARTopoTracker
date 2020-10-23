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
	public partial class Form_SARTopoSettings : Form
	{
		public Config.SARTopoSettings SARTopoSettings { get; set; }

		public Form_SARTopoSettings()
		{
			InitializeComponent();
		}

		private void Form_AGWPEPort_Load(object sender, EventArgs e)
		{
			if (this.SARTopoSettings != null)
			{
				this.ComboBox_Scheme.SelectedIndex = this.ComboBox_Scheme.FindStringExact(Program.Config.SARTopoSettings.Scheme);
				this.TextBox_Address.Text = this.SARTopoSettings.Address;
				this.TextBox_Port.Text = this.SARTopoSettings.Port.ToString();
				this.TextBox_MapID.Text = this.SARTopoSettings.MapID;
			}
		}

		private void Button_Save_Click(object sender, EventArgs e)
		{
			this.SARTopoSettings = new Config.SARTopoSettings()
			{
				Scheme = this.ComboBox_Scheme.SelectedItem as String,
				Address = this.TextBox_Address.Text,
				Port = Int32.Parse(this.TextBox_Port.Text),
				MapID = this.TextBox_MapID.Text
			};
		}

		private void TextBox_Port_KeyPress(object sender, KeyPressEventArgs e)
		{
			if
			(
				!Char.IsControl(e.KeyChar)
				&& !Char.IsDigit(e.KeyChar)
				&& !e.KeyChar.Equals('.')
			)
				e.Handled = true;
		}

		private void ComboBox_Scheme_SelectedIndexChanged(object sender, EventArgs e)
		{
			this._BuildURI();
		}

		private void _BuildURI()
		{
			Config.SARTopoSettings sarTopoSettings = new Config.SARTopoSettings();
			if (this.ComboBox_Scheme.SelectedItem is String scheme)
				sarTopoSettings.Scheme = scheme;
			if (!String.IsNullOrEmpty(this.TextBox_Address.Text))
				sarTopoSettings.Address = this.TextBox_Address.Text;
			if (!String.IsNullOrEmpty(this.TextBox_Port.Text))
				sarTopoSettings.Port = Int32.Parse(this.TextBox_Port.Text);
			if (!String.IsNullOrEmpty(this.TextBox_MapID.Text))
				sarTopoSettings.MapID = this.TextBox_MapID.Text;
			this.TextBox_URI.Text = sarTopoSettings.ToString();
		}

		private void TextBox_TextChanged(object sender, EventArgs e)
		{
			this._BuildURI();
		}
	}
}
