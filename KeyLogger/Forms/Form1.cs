using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyLogger.Enums;
using static KeyLogger.WinApis.User32;

namespace KeyLogger.Forms
{
    public partial class Form1 : Form
    {

        //private System.ComponentModel.IContainer components;

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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
            notifyIcon1.Visible = true;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

    }
}
