using System.Windows.Forms;
using KeyLogger.Enums;
using static KeyLogger.WinApis.User32;

namespace KeyLogger.Forms
{
	public class HiddenForm : Form
    {
        private System.ComponentModel.IContainer components;

        public int KeyId { get; set; }

		protected override void WndProc(ref Message m)
		{
			if (m.Msg == (int)CombineKeys.WM_HOTKEY)
			{
				if ((int)m.WParam == KeyId)
				{
					UnregisterHotKey(Handle, KeyId);
					Application.Exit();
				}
			}
			base.WndProc(ref m);
		}

		protected override void SetVisibleCore(bool value)
		{
			base.SetVisibleCore(false);
		}

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HiddenForm
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "HiddenForm";
            this.Load += new System.EventHandler(this.HiddenForm_Load);
            this.ResumeLayout(false);

        }

 

        private void HiddenForm_Load(object sender, System.EventArgs e)
        {

        }
    }
}
