using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Auto_Clicker {
    public partial class Form1 : Form {

        [DllImport("user32.dll")]
        private static extern void mouse_event (
        int dwFlags,
        int dx,
        int dy,
        int dwData,
        int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey (IntPtr hWnd, int id, int fsModifiers, int vlc);

        public int index = 9999;
        public bool selectata = false;

        protected override void WndProc (ref Message m) {
            if(m.Msg == 786 ) {
                int da = m.WParam.ToInt32();
                if ( da == 0 && index != 9999 )
                    timer1.Start();
                if ( da == 1 )
                    timer1.Stop();
            }
            base.WndProc(ref m);
        }


        public void rightClick () {
            mouse_event(8, 0, 0, 0, 0);
            mouse_event(16, 0, 0, 0, 0);
        }

        public void leftClick () {
            mouse_event(2, 0, 0, 0, 0);
            mouse_event(4, 0, 0, 0, 0);
        }



        public Form1 () {
            InitializeComponent();
            int id = 0;
            RegisterHotKey(this.Handle, id, 0, 120);
            RegisterHotKey(this.Handle, id + 1, 0, 121);
        }

        private void Form1_Load (object sender, EventArgs e) {

        }

        private void checkedListBox1_SelectedIndexChanged (object sender, EventArgs e) {
            if ( CB_list.SelectedItems.Count == 1 ) {
                selectata = true;
                index = CB_list.SelectedIndex;
            }
            if ( CB_list.SelectedItems.Count != 0 )
                return;
            selectata = false;
            index = 9999;
        }

        private void btn_start_Click (object sender, EventArgs e) {
            if ( index == 9999 )
                return;
            timer1.Start();
        }

        private void btn_stop_Click (object sender, EventArgs e) {
            timer1.Stop();
        }

        private void timer1_Tick (object sender, EventArgs e) {
            if ( index == 0 )
                leftClick();
            else if ( index == 1 )
                rightClick();
            Thread.Sleep(1);
        }

    }
}
