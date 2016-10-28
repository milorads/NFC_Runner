using IWshRuntimeLibrary;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NfcEditor.Controller
{
    class StartupAdder
    {
        public void Do(bool exists)
        {
            if (exists)
            {
                string shortcutLocation = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "NFC Runner" + ".lnk");
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);
                shortcut.Description = "Shortcut to run application on startup";
                shortcut.TargetPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                shortcut.WorkingDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                shortcut.Save();
            }
            else
            {
                try
                {
                    string shortcutLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "NFC Runner" + ".lnk");
                    System.IO.File.Delete(shortcutLocation);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }

            }
        }
    }
}
