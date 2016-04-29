namespace ExcelToCaveConverter
{
	partial class Form1
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
			this.btnConvertExcelCaveToCave = new System.Windows.Forms.Button();
			this.btnInitLookups = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnConvertExcelCaveToCave
			// 
			this.btnConvertExcelCaveToCave.Location = new System.Drawing.Point(282, 75);
			this.btnConvertExcelCaveToCave.Name = "btnConvertExcelCaveToCave";
			this.btnConvertExcelCaveToCave.Size = new System.Drawing.Size(221, 44);
			this.btnConvertExcelCaveToCave.TabIndex = 0;
			this.btnConvertExcelCaveToCave.Text = "Convert ExcelCave to Cave";
			this.btnConvertExcelCaveToCave.UseVisualStyleBackColor = true;
			this.btnConvertExcelCaveToCave.Click += new System.EventHandler(this.btnConvertExcelCaveToCave_Click);
			// 
			// btnInitLookups
			// 
			this.btnInitLookups.Location = new System.Drawing.Point(282, 161);
			this.btnInitLookups.Name = "btnInitLookups";
			this.btnInitLookups.Size = new System.Drawing.Size(221, 43);
			this.btnInitLookups.TabIndex = 1;
			this.btnInitLookups.Text = "Init Lookups";
			this.btnInitLookups.UseVisualStyleBackColor = true;
			this.btnInitLookups.Click += new System.EventHandler(this.btnInitLookups_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(799, 261);
			this.Controls.Add(this.btnInitLookups);
			this.Controls.Add(this.btnConvertExcelCaveToCave);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnConvertExcelCaveToCave;
		private System.Windows.Forms.Button btnInitLookups;
	}
}

