using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VmpcTest
{
	public partial class VmpcTestForm : Form
	{
		public VmpcTestForm()
		{
			InitializeComponent();
		}

		public static byte[] StringToByteArray(string hex)
		{
			try
			{
				hex = hex.Replace(" ", "");	// Delete spaces
				return Enumerable.Range(0, hex.Length)
								 .Where(x => x % 2 == 0)
								 .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
								 .ToArray();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		private void btnEncrypt_Click(object sender, EventArgs e)
		{
			Vmpc vmpc = new Vmpc();
			byte[] message;

			try
			{
				message = StringToByteArray(tbMessage.Text);
			}
			catch (Exception ex)
			{
				message = System.Text.Encoding.UTF8.GetBytes(tbMessage.Text);
			}


			try
			{
				byte[] key = StringToByteArray(tbKey.Text);
				byte[] iv = StringToByteArray(tbIv.Text);

				vmpc.InitKeyBASIC(key, key.Length, iv, iv.Length);

				vmpc.Encrypt(message, message.Length);	// Encryption (and decryption)

				String ret = "Enctypred message:\r\n";

				for (int i = 0; i < message.Length; i++)
					ret += message[i].ToString("X2") + " ";

				ret += "\r\nFor decrypt message, copy encrypted message to \"Enter a message\" box and click \"Encrypt\"";


				rtb1.Text = ret;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
