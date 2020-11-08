using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;

namespace DCS_WebGCI_Helper {
    public partial class Form1 : Form {
        public int a = 1;
        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        [DllImport("User32.dll")]
        static extern int SetForegroundWindow(IntPtr point);
        const int MYACTION_HOTKEY_ID = 1;


        public Form1() {
            InitializeComponent();
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 0x4, (int)Keys.C);
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID && chkArmed.Checked == true) {
                
                a++;
                // First get the clipboard contents and parse:
                String clipText, rawLat, rawLon;
                String cbuff;
                int latPos, lonPos;
                
                clipText = Clipboard.GetText();
                
                latPos = clipText.IndexOf("Latitude:");
                lonPos = clipText.IndexOf("Longitude:");
                if (latPos == -1 || lonPos == -1) {
                    return;
                }

                rawLat = clipText.Substring(latPos + 10, 16);
                rawLon = clipText.Substring(lonPos + 11, 17);
                
                cbuff = stripstuff(rawLat + "~" + rawLon);
                string[] parts = cbuff.Split('~');
                rawLat = parts[0];
                rawLon = parts[1];
                
                parts = rawLat.Split(' ');
                
                sendIt(parts[3]); //Sends N

                
                for (int i = 0; i <= parts[0].Length - 1; i++) {
                    sendIt(parts[0].Substring(i, 1));
                }
                
                for (int i = 0; i <= parts[1].Length - 1; i++) {
                    sendIt(parts[1].Substring(i, 1));
                }
                
                float tail = (float.Parse(parts[2]) * 1000) / 600;
                string txtTail = tail.ToString().Replace(".", "").Substring(0, 3);
                for (int i = 0; i <= txtTail.Length - 1; i++) {
                    sendIt(txtTail.Substring(i, 1));
                }
                sendIt("SAVEN");
                // PRESS THE BUTTON TO SAVE!!!!


                parts = rawLon.Split(' ');

                sendIt(parts[3]);

                for (int i = 0; i <= parts[0].Length - 1; i++) {
                    sendIt(parts[0].Substring(i, 1));
                }
                
                for (int i = 0; i <= parts[1].Length - 1; i++) {
                    sendIt(parts[1].Substring(i, 1));
                }
                
                tail = (float.Parse(parts[2]) * 1000) / 600;
                txtTail = tail.ToString().Replace(".", "").Substring(0, 3);
                for (int i = 0; i <= txtTail.Length - 1; i++) {
                    sendIt(txtTail.Substring(i, 1));
                }
                //MessageBox.Show(txtTail);
                // Next we will send input to the CDU
                sendIt("SAVEE"); 
            }
            //Clipboard.Clear();
            base.WndProc(ref m);
        }

        private void button2_Click(object sender, EventArgs e) {
            
        }

        void sendIt(string txt) {
            Process p = Process.GetProcessesByName("DCS").FirstOrDefault();
            if (p != null) {
                IntPtr h = p.MainWindowHandle;
                SetForegroundWindow(h);
                IntPtr ch = GetForegroundWindow();
                while(h != ch) {
                    ch = GetForegroundWindow();
                }
                
                var simu = new InputSimulator();
                if (txt == "1") {
                    simu.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_1);
                } else if (txt == "2") {
                    simu.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_2);
                } else if (txt == "3") {
                    simu.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_3);
                } else if (txt == "4") {
                    simu.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_4);
                } else if (txt == "5") {
                    simu.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_5);
                } else if (txt == "6") {
                    simu.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_6);
                } else if (txt == "7") {
                    simu.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_7);
                } else if (txt == "8") {
                    simu.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_8);
                } else if (txt == "9") {
                    simu.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_9);
                } else if (txt == "0") {
                    simu.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_0);
                } else if (txt == "n" || txt == "N") {
                    simu.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_N);
                } else if (txt == "s" || txt == "S") {
                    simu.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_S);
                } else if (txt == "e" || txt == "E") {
                    simu.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_E);
                } else if (txt == "w" || txt == "W") {
                    simu.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_W);
                } else if (txt == ".") {
                    simu.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.OEM_PERIOD);
                } else if (txt == "SAVEN") {
                    simu.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_Q);
                } else if (txt == "SAVEE") {
                    simu.Keyboard.ModifiedKeyStroke(VirtualKeyCode.LCONTROL, VirtualKeyCode.VK_R);
                }
            }
        }

        string stripstuff(string txt) {
            txt = txt.Replace("°", "");
            txt = txt.Replace("'", "");
            txt = txt.Replace("\"", "");
            return txt;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            UnregisterHotKey(this.Handle, 0);
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
