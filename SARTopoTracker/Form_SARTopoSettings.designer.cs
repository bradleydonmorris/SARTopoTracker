namespace SARTopoTracker
{
	partial class Form_SARTopoSettings
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Button_Save = new System.Windows.Forms.Button();
			this.Button_Cancel = new System.Windows.Forms.Button();
			this.Label_MapID = new System.Windows.Forms.Label();
			this.Label_Port = new System.Windows.Forms.Label();
			this.TextBox_Address = new System.Windows.Forms.TextBox();
			this.Label_Address = new System.Windows.Forms.Label();
			this.TextBox_MapID = new System.Windows.Forms.TextBox();
			this.TextBox_Port = new System.Windows.Forms.TextBox();
			this.ComboBox_Scheme = new System.Windows.Forms.ComboBox();
			this.Label_Scheme = new System.Windows.Forms.Label();
			this.TextBox_URI = new System.Windows.Forms.TextBox();
			this.Label_URI = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Button_Save
			// 
			this.Button_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Button_Save.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.Button_Save.Location = new System.Drawing.Point(153, 156);
			this.Button_Save.Name = "Button_Save";
			this.Button_Save.Size = new System.Drawing.Size(75, 23);
			this.Button_Save.TabIndex = 5;
			this.Button_Save.Text = "Save";
			this.Button_Save.UseVisualStyleBackColor = true;
			this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
			// 
			// Button_Cancel
			// 
			this.Button_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Button_Cancel.Location = new System.Drawing.Point(234, 156);
			this.Button_Cancel.Name = "Button_Cancel";
			this.Button_Cancel.Size = new System.Drawing.Size(75, 23);
			this.Button_Cancel.TabIndex = 6;
			this.Button_Cancel.Text = "Cancel";
			this.Button_Cancel.UseVisualStyleBackColor = true;
			// 
			// Label_MapID
			// 
			this.Label_MapID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Label_MapID.AutoSize = true;
			this.Label_MapID.Location = new System.Drawing.Point(6, 94);
			this.Label_MapID.Name = "Label_MapID";
			this.Label_MapID.Size = new System.Drawing.Size(45, 13);
			this.Label_MapID.TabIndex = 25;
			this.Label_MapID.Text = "Map ID:";
			// 
			// Label_Port
			// 
			this.Label_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Label_Port.AutoSize = true;
			this.Label_Port.Location = new System.Drawing.Point(6, 68);
			this.Label_Port.Name = "Label_Port";
			this.Label_Port.Size = new System.Drawing.Size(29, 13);
			this.Label_Port.TabIndex = 26;
			this.Label_Port.Text = "Port:";
			// 
			// TextBox_Address
			// 
			this.TextBox_Address.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBox_Address.Location = new System.Drawing.Point(94, 39);
			this.TextBox_Address.Name = "TextBox_Address";
			this.TextBox_Address.Size = new System.Drawing.Size(215, 20);
			this.TextBox_Address.TabIndex = 2;
			this.TextBox_Address.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			// 
			// Label_Address
			// 
			this.Label_Address.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Label_Address.AutoSize = true;
			this.Label_Address.Location = new System.Drawing.Point(6, 42);
			this.Label_Address.Name = "Label_Address";
			this.Label_Address.Size = new System.Drawing.Size(48, 13);
			this.Label_Address.TabIndex = 27;
			this.Label_Address.Text = "Address:";
			// 
			// TextBox_MapID
			// 
			this.TextBox_MapID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBox_MapID.Location = new System.Drawing.Point(94, 91);
			this.TextBox_MapID.Name = "TextBox_MapID";
			this.TextBox_MapID.Size = new System.Drawing.Size(215, 20);
			this.TextBox_MapID.TabIndex = 4;
			this.TextBox_MapID.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			// 
			// TextBox_Port
			// 
			this.TextBox_Port.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBox_Port.Location = new System.Drawing.Point(94, 65);
			this.TextBox_Port.Name = "TextBox_Port";
			this.TextBox_Port.Size = new System.Drawing.Size(215, 20);
			this.TextBox_Port.TabIndex = 3;
			this.TextBox_Port.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
			this.TextBox_Port.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_Port_KeyPress);
			// 
			// ComboBox_Scheme
			// 
			this.ComboBox_Scheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.ComboBox_Scheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ComboBox_Scheme.FormattingEnabled = true;
			this.ComboBox_Scheme.Items.AddRange(new object[] {
            "http",
            "https"});
			this.ComboBox_Scheme.Location = new System.Drawing.Point(94, 12);
			this.ComboBox_Scheme.Name = "ComboBox_Scheme";
			this.ComboBox_Scheme.Size = new System.Drawing.Size(215, 21);
			this.ComboBox_Scheme.TabIndex = 1;
			this.ComboBox_Scheme.SelectedIndexChanged += new System.EventHandler(this.ComboBox_Scheme_SelectedIndexChanged);
			// 
			// Label_Scheme
			// 
			this.Label_Scheme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Label_Scheme.AutoSize = true;
			this.Label_Scheme.Location = new System.Drawing.Point(6, 15);
			this.Label_Scheme.Name = "Label_Scheme";
			this.Label_Scheme.Size = new System.Drawing.Size(49, 13);
			this.Label_Scheme.TabIndex = 28;
			this.Label_Scheme.Text = "Scheme:";
			// 
			// TextBox_URI
			// 
			this.TextBox_URI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBox_URI.Location = new System.Drawing.Point(94, 117);
			this.TextBox_URI.Name = "TextBox_URI";
			this.TextBox_URI.ReadOnly = true;
			this.TextBox_URI.Size = new System.Drawing.Size(215, 20);
			this.TextBox_URI.TabIndex = 4;
			// 
			// Label_URI
			// 
			this.Label_URI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Label_URI.AutoSize = true;
			this.Label_URI.Location = new System.Drawing.Point(6, 120);
			this.Label_URI.Name = "Label_URI";
			this.Label_URI.Size = new System.Drawing.Size(29, 13);
			this.Label_URI.TabIndex = 25;
			this.Label_URI.Text = "URI:";
			// 
			// Form_SARTopoSettings
			// 
			this.AcceptButton = this.Button_Save;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.Button_Cancel;
			this.ClientSize = new System.Drawing.Size(321, 191);
			this.Controls.Add(this.Label_Scheme);
			this.Controls.Add(this.ComboBox_Scheme);
			this.Controls.Add(this.Label_URI);
			this.Controls.Add(this.Label_MapID);
			this.Controls.Add(this.Label_Port);
			this.Controls.Add(this.TextBox_Address);
			this.Controls.Add(this.Label_Address);
			this.Controls.Add(this.TextBox_URI);
			this.Controls.Add(this.TextBox_MapID);
			this.Controls.Add(this.TextBox_Port);
			this.Controls.Add(this.Button_Save);
			this.Controls.Add(this.Button_Cancel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form_SARTopoSettings";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "SAR Topo Settings";
			this.Load += new System.EventHandler(this.Form_AGWPEPort_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button Button_Save;
		private System.Windows.Forms.Button Button_Cancel;
		private System.Windows.Forms.Label Label_MapID;
		private System.Windows.Forms.Label Label_Port;
		private System.Windows.Forms.TextBox TextBox_Address;
		private System.Windows.Forms.Label Label_Address;
		private System.Windows.Forms.TextBox TextBox_MapID;
		private System.Windows.Forms.TextBox TextBox_Port;
		private System.Windows.Forms.ComboBox ComboBox_Scheme;
		private System.Windows.Forms.Label Label_Scheme;
		private System.Windows.Forms.TextBox TextBox_URI;
		private System.Windows.Forms.Label Label_URI;
	}
}