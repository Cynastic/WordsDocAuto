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
        public bool CloseOnCreate;
        public int TitleSize;

        public int OptionsCount = 5;

        //---Lines---
        //1. Saved File Path
        //2. Include Folder Name in File Name
        //3. Include Folder Name an Date in Document
        //4. Size of Title Text
        //5. Close Program on Creation

        public OptionsManager(string optionsPath)
        {
            OptionsPath = optionsPath;

            if (!File.Exists(OptionsPath))
            {
                FileStream fileStream = File.Create(OptionsPath);
                fileStream.Close();
            }

            if(File.ReadAllLines(OptionsPath).Length != 5)
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
            string[] content = { "NOPATH", "False", "True", "11", "False" };
            File.WriteAllLines(OptionsPath, content);
            ReadOptions();
        }

        public void WriteOptions()
        {
            string[] content = { CurrentPath, FolderInFileName.ToString(), IncludeFolderAndDate.ToString(), TitleSize.ToString(), CloseOnCreate.ToString() };
            
            File.WriteAllLines(OptionsPath, content);
        }

        public void ReadOptions()
        {
            string[] options = File.ReadAllLines(OptionsPath);

            CurrentPath = options[0];
            FolderInFileName = Convert.ToBoolean(options[1]);
            IncludeFolderAndDate = Convert.ToBoolean(options[2]);
            TitleSize = Convert.ToInt32(options[3]);
            CloseOnCreate = Convert.ToBoolean(options[4]);
        }
    }
}
