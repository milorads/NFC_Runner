using System;
using System.Diagnostics;

namespace NfcEditor.ViewModels
{
    class CMDCaller
    {
        public void ExecuteRun()
        {
            //run programs
            Process proc = new Process();
            string path = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            path += "\\Batch\\1.bat";
            proc.StartInfo.FileName = path;
            proc.Start();

        }
        public void ExecuteLock()
        {
            //lock computer
            Process proc = new Process();
            string path = System.IO.Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);
            path += "\\Batch\\2.bat";
            proc.StartInfo.FileName = path;
            proc.Start();
        }

    }
}
