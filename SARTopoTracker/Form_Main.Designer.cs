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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
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
			((System.ComponentModel.ISupportInitialize)(this.DataGridView_Positions)).BeginInit();
			this.SuspendLayout();
			// 
			// Label_SARTopoServer
			// 
			this.Label_SARTopoServer.AutoSize = true;
			this.Label_SARTopoServer.Location = new System.Drawing.Point(12, 9);
			this.Label_SARTopoServer.Name = "Label_SARTopoServer";
			this.Label_SARTopoServer.Size = new System.Drawing.Size(94, 13);
			this.Label_SARTopoServer.TabIndex = 1;
			this.Label_SARTopoServer.Text = "SAR Topo Server:";
			// 
			// Button_EditSARTopoServer
			// 
			this.Button_EditSARTopoServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Button_EditSARTopoServer.Location = new System.Drawing.Point(862, 4);
			this.Button_EditSARTopoServer.Name = "Button_EditSARTopoServer";
			this.Button_EditSARTopoServer.Size = new System.Drawing.Size(75, 23);
			this.Button_EditSARTopoServer.TabIndex = 3;
			this.Button_EditSARTopoServer.Text = "Edit";
			this.Button_EditSARTopoServer.UseVisualStyleBackColor = true;
			this.Button_EditSARTopoServer.Click += new System.EventHandler(this.Button_EditSARTopoServer_Click);
			// 
			// TextBox_SARTopoServer
			// 
			this.TextBox_SARTopoServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBox_SARTopoServer.Location = new System.Drawing.Point(124, 6);
			this.TextBox_SARTopoServer.Name = "TextBox_SARTopoServer";
			this.TextBox_SARTopoServer.ReadOnly = true;
			this.TextBox_SARTopoServer.Size = new System.Drawing.Size(732, 20);
			this.TextBox_SARTopoServer.TabIndex = 4;
			this.TextBox_SARTopoServer.Text = "http://localsartopo:8080";
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
			this.DataGridView_Positions.Location = new System.Drawing.Point(12, 91);
			this.DataGridView_Positions.Name = "DataGridView_Positions";
			this.DataGridView_Positions.Size = new System.Drawing.Size(925, 310);
			this.DataGridView_Positions.TabIndex = 5;
			// 
			// Column_Identifier
			// 
			this.Column_Identifier.HeaderText = "Identifier";
			this.Column_Identifier.Name = "Column_Identifier";
			this.Column_Identifier.ReadOnly = true;
			// 
			// Column_TimeStamp
			// 
			dataGridViewCellStyle9.Format = "HH:mm:ss";
			this.Column_TimeStamp.DefaultCellStyle = dataGridViewCellStyle9;
			this.Column_TimeStamp.HeaderText = "Time Stamp";
			this.Column_TimeStamp.Name = "Column_TimeStamp";
			this.Column_TimeStamp.ReadOnly = true;
			// 
			// Column_Latitude
			// 
			dataGridViewCellStyle10.Format = "0.000000";
			this.Column_Latitude.DefaultCellStyle = dataGridViewCellStyle10;
			this.Column_Latitude.HeaderText = "Latitude";
			this.Column_Latitude.Name = "Column_Latitude";
			this.Column_Latitude.ReadOnly = true;
			// 
			// Column_Longitude
			// 
			dataGridViewCellStyle11.Format = "0.000000";
			this.Column_Longitude.DefaultCellStyle = dataGridViewCellStyle11;
			this.Column_Longitude.HeaderText = "Longitude";
			this.Column_Longitude.Name = "Column_Longitude";
			this.Column_Longitude.ReadOnly = true;
			// 
			// Column_Altitude
			// 
			dataGridViewCellStyle12.Format = "0.000";
			this.Column_Altitude.DefaultCellStyle = dataGridViewCellStyle12;
			this.Column_Altitude.HeaderText = "Altitude";
			this.Column_Altitude.Name = "Column_Altitude";
			this.Column_Altitude.ReadOnly = true;
			// 
			// Column_Comment
			// 
			this.Column_Comment.HeaderText = "Comment";
			this.Column_Comment.Name = "Column_Comment";
			this.Column_Comment.ReadOnly = true;
			// 
			// TextBox_AGWPEPort
			// 
			this.TextBox_AGWPEPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TextBox_AGWPEPort.Location = new System.Drawing.Point(124, 32);
			this.TextBox_AGWPEPort.Name = "TextBox_AGWPEPort";
			this.TextBox_AGWPEPort.ReadOnly = true;
			this.TextBox_AGWPEPort.Size = new System.Drawing.Size(732, 20);
			this.TextBox_AGWPEPort.TabIndex = 8;
			this.TextBox_AGWPEPort.Text = "http://localsartopo:8080";
			// 
			// Button_EditAGWPEPort
			// 
			this.Button_EditAGWPEPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.Button_EditAGWPEPort.Location = new System.Drawing.Point(862, 30);
			this.Button_EditAGWPEPort.Name = "Button_EditAGWPEPort";
			this.Button_EditAGWPEPort.Size = new System.Drawing.Size(75, 23);
			this.Button_EditAGWPEPort.TabIndex = 7;
			this.Button_EditAGWPEPort.Text = "Edit";
			this.Button_EditAGWPEPort.UseVisualStyleBackColor = true;
			this.Button_EditAGWPEPort.Click += new System.EventHandler(this.Button_EditAGWPEServer_Click);
			// 
			// Label_AGWPEServer
			// 
			this.Label_AGWPEServer.AutoSize = true;
			this.Label_AGWPEServer.Location = new System.Drawing.Point(12, 35);
			this.Label_AGWPEServer.Name = "Label_AGWPEServer";
			this.Label_AGWPEServer.Size = new System.Drawing.Size(106, 13);
			this.Label_AGWPEServer.TabIndex = 6;
			this.Label_AGWPEServer.Text = "AGWPE Server Port:";
			// 
			// Button_Start
			// 
			this.Button_Start.Location = new System.Drawing.Point(12, 62);
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
			this.Button_Stop.Location = new System.Drawing.Point(93, 62);
			this.Button_Stop.Name = "Button_Stop";
			this.Button_Stop.Size = new System.Drawing.Size(75, 23);
			this.Button_Stop.TabIndex = 9;
			this.Button_Stop.Text = "Stop";
			this.Button_Stop.UseVisualStyleBackColor = true;
			this.Button_Stop.Click += new System.EventHandler(this.Button_Stop_Click);
			// 
			// Form_Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(945, 403);
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
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Identifier;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_TimeStamp;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Latitude;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Longitude;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Altitude;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column_Comment;
		private System.Windows.Forms.Button Button_Start;
		private System.Windows.Forms.Button Button_Stop;
	}
}

