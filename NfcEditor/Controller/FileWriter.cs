using System.IO;

namespace NfcEditor.Controller
{
    class FileWriter
    {
        private static StartupAdder regEdit = new StartupAdder();
        public void write(bool tf)
        {
            using (BinaryWriter b = new BinaryWriter(
        File.Open("file.bin", FileMode.Create)))
            {
                b.Write(tf);
                regEdit.Do(tf);
            }
        }

        public bool read()
        {
            if (File.Exists("file.bin"))
            {
                using (BinaryReader b = new BinaryReader(File.Open("file.bin", FileMode.Open)))
                {
                    return b.ReadBoolean();
                }
            }
            else
            {
                FileWriter f = new FileWriter();
                f.write(false);
                return false;
            }
        }
    }
}
