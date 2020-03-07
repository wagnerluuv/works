using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdobeCrackHelper
{
    public static class CrackHelper
    {
        public static void GetFilePath(this TextBox textbox)
        {
            using(OpenFileDialog dialog = new OpenFileDialog { Filter = "library files (*.dll)|*.dll" })
            {
                if(dialog.ShowDialog() == DialogResult.OK)
                {
                    textbox.Text = dialog.FileName;
                }
            }
        }

        internal static void Replace(string file32, string file64)
        {
            replaceAmtlib(Environment.ExpandEnvironmentVariables("%ProgramFiles(x86)%"), file32);
            replaceAmtlib(Environment.ExpandEnvironmentVariables("%ProgramW6432%"), file64);
        }

        private static void replaceAmtlib(string folder, string file)
        {
            string[] files = getFiles(folder);

            foreach(string amtlib in files)
            {
                if(MessageBox.Show($"replace {amtlib} ?", "confirm please", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    File.Delete(amtlib);
                    File.Copy(file, amtlib);
                }
            }
        }

        private static string[] getFiles(string folder)
        {
            List<string> files = new List<string>();
            try
            {
                files.AddRange(Directory.GetFiles(folder, "*amtlib.dll", SearchOption.TopDirectoryOnly)
                .Where(amtlib => amtlib.Contains("adobe") || amtlib.Contains("Adobe")));

                files.AddRange(Directory.GetDirectories(folder).SelectMany(subFolder => getFiles(subFolder)));
            }
            catch
            {

            }
            return files.ToArray();
        }
    }
}
