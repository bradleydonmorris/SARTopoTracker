namespace SARTopoTracker
{
	partial class Form_Main
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
			this.Label_SARTopoServer = new System.Windows.Forms.Label();
			this.Button_EditSARTopoServer = new System.Windows.Forms.Button();
			this.TextBox_SARTopoServer = new System.Windows.Forms.TextBox();
			this.DataGridView_Positions = new System.Windows.Forms.DataGridView();
			this.Column_Identifier = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_TimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_Latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_Longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_Altitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column_Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TextBox_AGWPEPort = new System.Windows.Forms.TextBox();
			this.Button_EditAGWPEPort = new System.Windows.Forms.Button();
			this.Label_AGWPEServer = new System.Windows.Forms.Label();
			this.Button_Start = new System.Windows.Forms.Button();
			this.Button_Stop = new System.Windows.Forms.Button();
			this.TextBox_GarminPrefix = new System.Windows.Forms.TextBox();
			this.Button_EditGarminPrefix = new System.Windows.Forms.Button();
			this.Label_GarminPrefix = new System.Windows.Forms.Label();
			this.TextBox_ThisStationIdentifier = new System.Windows.Forms.TextBox();
			this.Button_EditThisStationIdentifier = new System.Windows.Forms.Button();
			this.Label_ThisStationIdentifier = new System.Windows.Forms.Label();
			this.TextBox_SARTopoUpdateSeconds = new System.Windows.Forms.TextBox();
			this.Button_EidtSARTopoUpdateSeconds = new System.Windows.Forms.Button();
			this.Label_SARTopoUpdateSeconds = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView_Positions)).BeginInit();
			this.SuspendLayout();
			// 
			// Label_SARTopoServer
			// 
			this.Label_SARTopoServer.AutoSize = true;
			this.Label_SARTopoServer.Location = new System.Drawing.Point(12, 43);
			this.Label_SARTopoServer.Name = "Label_SARTopoServer";
			this.Label_SARTopoServer.Size = new System.Drawing.Size(101, 13);
			this.Label_SARTopoServer.TabIndex = 1;
			this.Label_SARTopoServer.Text = "SAR Topo Settings:";
			// 
			// Button_EditSARTopoServer
			// 
			this.Button_EditSARTopoServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Button_EditSARTopoServer.Location = new System.Drawing.Point(858, 38);
			this.Button_EditSARTopoServer.Name = "Button_EditSARTopoServer";
			this.Button_EditSARTopoServer.Size = new System.Drawing.Size(75, 23);
			this.Button_EditSARTopoServer.TabIndex = 4;
			this.Button_EditSARTopoServer.Text = "Edit";
			this.Button_EditSARTopoServer.UseVisualStyleBackColor = true;
			this.Button_EditSARTopoServer.Click += new System.EventHandler(this.Button_EditSARTopoServer_Click);
			// 
			// TextBox_SARTopoServer
			// 
			this.TextBox_SARTopoServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBox_SARTopoServer.Location = new System.Drawing.Point(161, 40);
			this.TextBox_SARTopoServer.Name = "TextBox_SARTopoServer";
			this.TextBox_SARTopoServer.ReadOnly = true;
			this.TextBox_SARTopoServer.Size = new System.Drawing.Size(691, 20);
			this.TextBox_SARTopoServer.TabIndex = 3;
			this.TextBox_SARTopoServer.Text = "http://localhost:8080";
			// 
			// DataGridView_Positions
			// 
			this.DataGridView_Positions.AllowUserToAddRows = false;
			this.DataGridView_Positions.AllowUserToDeleteRows = false;
			this.DataGridView_Positions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.DataGridView_Positions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridView_Positions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Identifier,
            this.Column_TimeStamp,
            this.Column_Latitude,
            this.Column_Longitude,
            this.Column_Altitude,
            this.Column_Comment});
			this.DataGridView_Positions.Location = new System.Drawing.Point(12, 188);
			this.DataGridView_Positions.Name = "DataGridView_Positions";
			this.DataGridView_Positions.Size = new System.Drawing.Size(925, 213);
			this.DataGridView_Positions.TabIndex = 5;
			this.DataGridView_Positions.TabStop = false;
			// 
			// Column_Identifier
			// 
			this.Column_Identifier.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Column_Identifier.HeaderText = "Identifier";
			this.Column_Identifier.Name = "Column_Identifier";
			this.Column_Identifier.ReadOnly = true;
			this.Column_Identifier.Width = 72;
			// 
			// Column_TimeStamp
			// 
			this.Column_TimeStamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle5.Format = "HH:mm:ss";
			this.Column_TimeStamp.DefaultCellStyle = dataGridViewCellStyle5;
			this.Column_TimeStamp.HeaderText = "Time Stamp";
			this.Column_TimeStamp.Name = "Column_TimeStamp";
			this.Column_TimeStamp.ReadOnly = true;
			this.Column_TimeStamp.Width = 88;
			// 
			// Column_Latitude
			// 
			this.Column_Latitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle6.Format = "0.000000";
			this.Column_Latitude.DefaultCellStyle = dataGridViewCellStyle6;
			this.Column_Latitude.HeaderText = "Latitude";
			this.Column_Latitude.Name = "Column_Latitude";
			this.Column_Latitude.ReadOnly = true;
			this.Column_Latitude.Width = 70;
			// 
			// Column_Longitude
			// 
			this.Column_Longitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle7.Format = "0.000000";
			this.Column_Longitude.DefaultCellStyle = dataGridViewCellStyle7;
			this.Column_Longitude.HeaderText = "Longitude";
			this.Column_Longitude.Name = "Column_Longitude";
			this.Column_Longitude.ReadOnly = true;
			this.Column_Longitude.Width = 79;
			// 
			// Column_Altitude
			// 
			this.Column_Altitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			dataGridViewCellStyle8.Format = "0.000";
			this.Column_Altitude.DefaultCellStyle = dataGridViewCellStyle8;
			this.Column_Altitude.HeaderText = "Altitude";
			this.Column_Altitude.Name = "Column_Altitude";
			this.Column_Altitude.ReadOnly = true;
			this.Column_Altitude.Width = 67;
			// 
			// Column_Comment
			// 
			this.Column_Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
			this.Column_Comment.HeaderText = "Comment";
			this.Column_Comment.Name = "Column_Comment";
			this.Column_Comment.ReadOnly = true;
			this.Column_Comment.Width = 76;
			// 
			// TextBox_AGWPEPort
			// 
			this.TextBox_AGWPEPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBox_AGWPEPort.Location = new System.Drawing.Point(161, 66);
			this.TextBox_AGWPEPort.Name = "TextBox_AGWPEPort";
			this.TextBox_AGWPEPort.ReadOnly = true;
			this.TextBox_AGWPEPort.Size = new System.Drawing.Size(691, 20);
			this.TextBox_AGWPEPort.TabIndex = 5;
			this.TextBox_AGWPEPort.Text = "agw://localhost:8000/Port_1";
			// 
			// Button_EditAGWPEPort
			// 
			this.Button_EditAGWPEPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Button_EditAGWPEPort.Location = new System.Drawing.Point(858, 64);
			this.Button_EditAGWPEPort.Name = "Button_EditAGWPEPort";
			this.Button_EditAGWPEPort.Size = new System.Drawing.Size(75, 23);
			this.Button_EditAGWPEPort.TabIndex = 6;
			this.Button_EditAGWPEPort.Text = "Edit";
			this.Button_EditAGWPEPort.UseVisualStyleBackColor = true;
			this.Button_EditAGWPEPort.Click += new System.EventHandler(this.Button_EditAGWPEServer_Click);
			// 
			// Label_AGWPEServer
			// 
			this.Label_AGWPEServer.AutoSize = true;
			this.Label_AGWPEServer.Location = new System.Drawing.Point(12, 69);
			this.Label_AGWPEServer.Name = "Label_AGWPEServer";
			this.Label_AGWPEServer.Size = new System.Drawing.Size(91, 13);
			this.Label_AGWPEServer.TabIndex = 6;
			this.Label_AGWPEServer.Text = "AGWPE Settings:";
			// 
			// Button_Start
			// 
			this.Button_Start.Location = new System.Drawing.Point(12, 159);
			this.Button_Start.Name = "Button_Start";
			this.Button_Start.Size = new System.Drawing.Size(75, 23);
			this.Button_Start.TabIndex = 9;
			this.Button_Start.Text = "Start";
			this.Button_Start.UseVisualStyleBackColor = true;
			this.Button_Start.Click += new System.EventHandler(this.Button_Start_Click);
			// 
			// Button_Stop
			// 
			this.Button_Stop.Enabled = false;
			this.Button_Stop.Location = new System.Drawing.Point(93, 159);
			this.Button_Stop.Name = "Button_Stop";
			this.Button_Stop.Size = new System.Drawing.Size(75, 23);
			this.Button_Stop.TabIndex = 10;
			this.Button_Stop.Text = "Stop";
			this.Button_Stop.UseVisualStyleBackColor = true;
			this.Button_Stop.Click += new System.EventHandler(this.Button_Stop_Click);
			// 
			// TextBox_GarminPrefix
			// 
			this.TextBox_GarminPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBox_GarminPrefix.Location = new System.Drawing.Point(161, 92);
			this.TextBox_GarminPrefix.Name = "TextBox_GarminPrefix";
			this.TextBox_GarminPrefix.ReadOnly = true;
			this.TextBox_GarminPrefix.Size = new System.Drawing.Size(691, 20);
			this.TextBox_GarminPrefix.TabIndex = 7;
			this.TextBox_GarminPrefix.Text = "GK9";
			// 
			// Button_EditGarminPrefix
			// 
			this.Button_EditGarminPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Button_EditGarminPrefix.Location = new System.Drawing.Point(858, 90);
			this.Button_EditGarminPrefix.Name = "Button_EditGarminPrefix";
			this.Button_EditGarminPrefix.Size = new System.Drawing.Size(75, 23);
			this.Button_EditGarminPrefix.TabIndex = 8;
			this.Button_EditGarminPrefix.Text = "Edit";
			this.Button_EditGarminPrefix.UseVisualStyleBackColor = true;
			this.Button_EditGarminPrefix.Click += new System.EventHandler(this.Button_EditGarminPrefix_Click);
			// 
			// Label_GarminPrefix
			// 
			this.Label_GarminPrefix.AutoSize = true;
			this.Label_GarminPrefix.Location = new System.Drawing.Point(12, 95);
			this.Label_GarminPrefix.Name = "Label_GarminPrefix";
			this.Label_GarminPrefix.Size = new System.Drawing.Size(72, 13);
			this.Label_GarminPrefix.TabIndex = 10;
			this.Label_GarminPrefix.Text = "Garmin Prefix:";
			// 
			// TextBox_ThisStationIdentifier
			// 
			this.TextBox_ThisStationIdentifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBox_ThisStationIdentifier.Location = new System.Drawing.Point(161, 14);
			this.TextBox_ThisStationIdentifier.Name = "TextBox_ThisStationIdentifier";
			this.TextBox_ThisStationIdentifier.ReadOnly = true;
			this.TextBox_ThisStationIdentifier.Size = new System.Drawing.Size(691, 20);
			this.TextBox_ThisStationIdentifier.TabIndex = 1;
			// 
			// Button_EditThisStationIdentifier
			// 
			this.Button_EditThisStationIdentifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Button_EditThisStationIdentifier.Location = new System.Drawing.Point(858, 12);
			this.Button_EditThisStationIdentifier.Name = "Button_EditThisStationIdentifier";
			this.Button_EditThisStationIdentifier.Size = new System.Drawing.Size(75, 23);
			this.Button_EditThisStationIdentifier.TabIndex = 2;
			this.Button_EditThisStationIdentifier.Text = "Edit";
			this.Button_EditThisStationIdentifier.UseVisualStyleBackColor = true;
			this.Button_EditThisStationIdentifier.Click += new System.EventHandler(this.Button_EditThisStationIdentifier_Click);
			// 
			// Label_ThisStationIdentifier
			// 
			this.Label_ThisStationIdentifier.AutoSize = true;
			this.Label_ThisStationIdentifier.Location = new System.Drawing.Point(12, 17);
			this.Label_ThisStationIdentifier.Name = "Label_ThisStationIdentifier";
			this.Label_ThisStationIdentifier.Size = new System.Drawing.Size(109, 13);
			this.Label_ThisStationIdentifier.TabIndex = 13;
			this.Label_ThisStationIdentifier.Text = "This Station Identifier:";
			// 
			// TextBox_SARTopoUpdateSeconds
			// 
			this.TextBox_SARTopoUpdateSeconds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBox_SARTopoUpdateSeconds.Location = new System.Drawing.Point(161, 121);
			this.TextBox_SARTopoUpdateSeconds.Name = "TextBox_SARTopoUpdateSeconds";
			this.TextBox_SARTopoUpdateSeconds.ReadOnly = true;
			this.TextBox_SARTopoUpdateSeconds.Size = new System.Drawing.Size(691, 20);
			this.TextBox_SARTopoUpdateSeconds.TabIndex = 14;
			this.TextBox_SARTopoUpdateSeconds.Text = "30";
			this.TextBox_SARTopoUpdateSeconds.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_SARTopoUpdateSeconds_KeyPress);
			// 
			// Button_EidtSARTopoUpdateSeconds
			// 
			this.Button_EidtSARTopoUpdateSeconds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Button_EidtSARTopoUpdateSeconds.Location = new System.Drawing.Point(858, 119);
			this.Button_EidtSARTopoUpdateSeconds.Name = "Button_EidtSARTopoUpdateSeconds";
			this.Button_EidtSARTopoUpdateSeconds.Size = new System.Drawing.Size(75, 23);
			this.Button_EidtSARTopoUpdateSeconds.TabIndex = 15;
			this.Button_EidtSARTopoUpdateSeconds.Text = "Edit";
			this.Button_EidtSARTopoUpdateSeconds.UseVisualStyleBackColor = true;
			this.Button_EidtSARTopoUpdateSeconds.Click += new System.EventHandler(this.Button_EidtSARTopoUpdateSeconds_Click);
			// 
			// Label_SARTopoUpdateSeconds
			// 
			this.Label_SARTopoUpdateSeconds.AutoSize = true;
			this.Label_SARTopoUpdateSeconds.Location = new System.Drawing.Point(12, 124);
			this.Label_SARTopoUpdateSeconds.Name = "Label_SARTopoUpdateSeconds";
			this.Label_SARTopoUpdateSeconds.Size = new System.Drawing.Size(143, 13);
			this.Label_SARTopoUpdateSeconds.TabIndex = 16;
			this.Label_SARTopoUpdateSeconds.Text = "SAR Topo Update Seconds:";
			// 
			// Form_Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(945, 403);
			this.Controls.Add(this.TextBox_SARTopoUpdateSeconds);
			this.Controls.Add(this.Button_EidtSARTopoUpdateSeconds);
			this.Controls.Add(this.Label_SARTopoUpdateSeconds);
			this.Controls.Add(this.TextBox_ThisStationIdentifier);
			this.Controls.Add(this.Button_EditThisStationIdentifier);
			this.Controls.Add(this.Label_ThisStationIdentifier);
			this.Controls.Add(this.TextBox_GarminPrefix);
			this.Controls.Add(this.Button_EditGarminPrefix);
			this.Controls.Add(this.Label_GarminPrefix);
			this.Controls.Add(this.Button_Stop);
			this.Controls.Add(this.Button_Start);
			this.Controls.Add(this.TextBox_AGWPEPort);
			this.Controls.Add(this.Button_EditAGWPEPort);
			this.Controls.Add(this.Label_AGWPEServer);
			this.Controls.Add(this.DataGridView_Positions);
			this.Controls.Add(this.TextBox_SARTopoServer);
			this.Controls.Add(this.Button_EditSARTopoServer);
			this.Controls.Add(this.Label_SARTopoServer);
			this.Name = "Form_Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SARTopo Tracker";
			this.Load += new System.EventHandler(this.Form_Main_Load);
			((System.ComponentModel.ISupportInitialize)(this.DataGridView_Positions)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label Label_SARTopoServer;
		private System.Windows.Forms.Button Button_EditSARTopoServer;
		private System.Windows.Forms.TextBox TextBox_SARTopoServer;
		private System.Windows.Forms.DataGridView DataGridView_Positions;
		private System.Windows.Forms.TextBox TextBox_AGWPEPort;
		private System.Windows.Forms.Button Button_EditAGWPEPort;
		private System.Windows.Forms.Label Label_AGWPEServer;
		private System.Windows.Forms.Button Button_Start;
		private System.Windows.Forms.Button Button_Stop;
		private System.Windows.Forms.TextBox TextBox_GarminPrefix;
		private System.Windows.Forms.Button Button_EditGarminPrefix;
		private System.Windows.Forms.Label Label_GarminPrefix;
		private System.Windows.Forms.TextBox TextBox_ThisStationIdentifier;
		private System.Windows.Forms.Button Button_EditThisStationIdentifier;
		private System.Windows.Forms.Label Label_ThisStationIdentifier;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Identifier;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_TimeStamp;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Latitude;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Longitude;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Altitude;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Comment;
		private System.Windows.Forms.TextBox TextBox_SARTopoUpdateSeconds;
		private System.Windows.Forms.Button Button_EidtSARTopoUpdateSeconds;
		private System.Windows.Forms.Label Label_SARTopoUpdateSeconds;
	}
}

