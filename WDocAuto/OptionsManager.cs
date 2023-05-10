using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace WDocAuto
{
    public class OptionsManager
    {
        public string OptionsPath;

        public string CurrentPath;
        public bool FolderInFileName;
        public bool IncludeFolderAndDate;
        public int TitleSize;

        public OptionsManager(string optionsPath)
        {
            OptionsPath = optionsPath;

            if (!File.Exists(OptionsPath))
            {
                FileStream fileStream = File.Create(OptionsPath);
                fileStream.Close();
            }

            if(File.ReadAllLines(OptionsPath).Length != 4)
            {
                WriteStandard();
            }
            else
            {
                try
                {
                    ReadOptions();
                }
                catch
                {
                    WriteStandard();
                }
                
            }
        }

        public void WriteStandard()
        {
            string[] content = { "NOPATH", "False", "True", "11" };
            File.WriteAllLines(OptionsPath, content);
            ReadOptions();
        }

        public void WriteOptions()
        {
            string[] content = { CurrentPath, FolderInFileName.ToString(), IncludeFolderAndDate.ToString(), TitleSize.ToString() };
            
            File.WriteAllLines(OptionsPath, content);
        }

        public void ReadOptions()
        {
            string[] options = File.ReadAllLines(OptionsPath);

            CurrentPath = options[0];
            FolderInFileName = Convert.ToBoolean(options[1]);
            IncludeFolderAndDate = Convert.ToBoolean(options[2]);
            TitleSize = Convert.ToInt32(options[3]);
        }
    }
}
