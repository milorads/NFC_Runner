using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using NfcEditor.Properties;
using NfcEditor.ViewModels;
using System.Windows.Controls;

namespace NfcEditor.Controller
{
    class Tray
    {
        private static TaskbarIcon tb = new TaskbarIcon();
        private static string title = "NFC Runner";
        private static FileWriter f = new FileWriter();
        private ContextMenu menu = new ContextMenu();
        private MenuItem i = new MenuItem();
        private MenuItem i2 = new MenuItem();

        private void menuItem1_Click(object sender, System.EventArgs e)
        {
            if (i.IsChecked)
            {
                f.write(true);
            }
            else if(!i.IsChecked)
            {
                f.write(false);
            }
        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void InitApplication()
        {
            tb.ToolTipText = "NFC Runner v0.2 beta";
            Icon ico = new Icon("Assets/nfc.ico");
            tb.Icon = ico;
            tb.PopupActivation = PopupActivationMode.DoubleClick;
            tb.MenuActivation = PopupActivationMode.LeftOrRightClick;
            i.IsCheckable = true;
            i.Header = "Run at startup?";
            if (f.read())
            {
                i.IsChecked = true;
            }
            else
            {
                i.IsChecked = false;
            }
            i2.Header = "Exit";
            menu.Items.Add(i);
            menu.Items.Add(i2);
            menu.Visibility = Visibility.Visible;
            i.Click += new RoutedEventHandler(this.menuItem1_Click);
            i2.Click += new RoutedEventHandler(this.menuItem2_Click);

            tb.ContextMenu = menu;

            //show balloon with built-in icon
            //tb.ShowBalloonTip(title, text, BalloonIcon.Error);

            //show balloon with custom icon
            //tb.ShowBalloonTip(title, text, BalloonIcon.Info);

            //callCMD();
            ////hide balloon
            //tb.HideBalloonTip();


        }
        public void NFCDetected() {
            tb.HideBalloonTip();
            string text = "NFC Tag Detected, starting programs";
            callCMD("");
            tb.ShowBalloonTip(title, text, BalloonIcon.Info);

        }
        public void NFCRedDetected()
        {
            tb.HideBalloonTip();
            string text = "NFC Tag Detected, locking";
            callCMD("lock");
            tb.ShowBalloonTip(title, text, BalloonIcon.Info);

        }
        public void NFCBlackDetected()
        {
            tb.HideBalloonTip();
            string text = "NFC Tag Detected, starting programs";
            callCMD("run");
            tb.ShowBalloonTip(title, text, BalloonIcon.Info);

        }
        public void NFCRemoved() {
            tb.HideBalloonTip();
            string text = "Removed NFC";
            tb.ShowBalloonTip(title, text, BalloonIcon.Info);
        }

        private static void callCMD(string a) {
            CMDCaller c = new CMDCaller();
            if (a == "lock")
            {
                c.ExecuteLock();

            }
            else if (a == "run")
            {
                c.ExecuteRun();

            }
            else
            {
                tb.HideBalloonTip();
                string text = "Unknown NFC Tag";
                tb.ShowBalloonTip(title, text, BalloonIcon.Info);
            }

        }
    }
}
