namespace VmpcTest
{
	partial class VmpcTestForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.tbKey = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbIv = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbMessage = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.rtb1 = new System.Windows.Forms.RichTextBox();
			this.btnEncrypt = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(528, 28);
			this.label1.TabIndex = 0;
			this.label1.Text = "Enter KEY in hex format (00 34 f5 0d...)";
			this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// tbKey
			// 
			this.tbKey.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbKey.Location = new System.Drawing.Point(0, 28);
			this.tbKey.Name = "tbKey";
			this.tbKey.Size = new System.Drawing.Size(528, 20);
			this.tbKey.TabIndex = 1;
			this.tbKey.Text = "96 61 41 0A B7 97 D8 A9 EB 76 7C 21 17 2D F6 C7";
			// 
			// label2
			// 
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point(0, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(528, 28);
			this.label2.TabIndex = 2;
			this.label2.Text = "Enter IV (Initialization Vector) in hex format (00 34 f5 0d...)";
			this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// tbIv
			// 
			this.tbIv.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbIv.Location = new System.Drawing.Point(0, 76);
			this.tbIv.Name = "tbIv";
			this.tbIv.Size = new System.Drawing.Size(528, 20);
			this.tbIv.TabIndex = 3;
			this.tbIv.Text = "4B 5C 2F 00 3E 67 F3 95 57 A8 D2 6F 3D A2 B1 55";
			// 
			// label3
			// 
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.Location = new System.Drawing.Point(0, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(528, 28);
			this.label3.TabIndex = 4;
			this.label3.Text = "Enter a message (posible HEX format, like for KEY and IV)";
			this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// tbMessage
			// 
			this.tbMessage.Dock = System.Windows.Forms.DockStyle.Top;
			this.tbMessage.Location = new System.Drawing.Point(0, 124);
			this.tbMessage.Name = "tbMessage";
			this.tbMessage.Size = new System.Drawing.Size(528, 20);
			this.tbMessage.TabIndex = 5;
			this.tbMessage.Text = "Hello world !!!";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnEncrypt);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 144);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(528, 49);
			this.panel1.TabIndex = 6;
			// 
			// rtb1
			// 
			this.rtb1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtb1.Location = new System.Drawing.Point(0, 193);
			this.rtb1.Name = "rtb1";
			this.rtb1.Size = new System.Drawing.Size(528, 259);
			this.rtb1.TabIndex = 7;
			this.rtb1.Text = "";
			// 
			// btnEncrypt
			// 
			this.btnEncrypt.Location = new System.Drawing.Point(11, 9);
			this.btnEncrypt.Name = "btnEncrypt";
			this.btnEncrypt.Size = new System.Drawing.Size(115, 30);
			this.btnEncrypt.TabIndex = 0;
			this.btnEncrypt.Text = "Encrypt";
			this.btnEncrypt.UseVisualStyleBackColor = true;
			this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
			// 
			// VmpcTestForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(528, 452);
			this.Controls.Add(this.rtb1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.tbMessage);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbIv);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbKey);
			this.Controls.Add(this.label1);
			this.Name = "VmpcTestForm";
			this.Text = "VmpcTestForm";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbKey;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbIv;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbMessage;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnEncrypt;
		private System.Windows.Forms.RichTextBox rtb1;
	}
}