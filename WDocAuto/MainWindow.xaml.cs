using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using WinForms = System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;

namespace WDocAuto
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> SubDirectories = new List<string>();
        List<string> SubDirectoryNames = new List<string>();
        string DateDay = DateTime.Now.Day > 9 ? DateTime.Now.Day.ToString() : "0" + DateTime.Now.Day.ToString();
        string DateMonth = DateTime.Now.Month > 9 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString();
        string DateYear = DateTime.Now.Year.ToString().Substring(2);
        
        public string SavedPathFile = AppDomain.CurrentDomain.BaseDirectory + "SavePath.txt";

        OptionsManager optionsManager;

        public MainWindow()
        {
            InitializeComponent();
            optionsManager = new OptionsManager(SavedPathFile);
            if(optionsManager.CurrentPath == "NOPATH")
            {
                optionsManager.CurrentPath = ChangePathDialog();
            }
            GetSubDirectories();
        }

        public string ChangePathDialog()
        {
            WinForms.FolderBrowserDialog folderBrowser = new WinForms.FolderBrowserDialog();
            if(folderBrowser.ShowDialog() == WinForms.DialogResult.OK)
            {
                if (Directory.Exists(folderBrowser.SelectedPath))
                {
                    //Console.WriteLine("Set Path to: " + folderBrowser.SelectedPath);
                    optionsManager.CurrentPath = folderBrowser.SelectedPath;
                    optionsManager.WriteOptions();
                    GetSubDirectories();
                    return folderBrowser.SelectedPath;
                }
                else
                {
                    //Console.WriteLine("Choosen Directory doesnt exist");
                    return optionsManager.CurrentPath;
                }
            }
            return optionsManager.CurrentPath;
        }

        public void GetSubDirectories()
        {
            PathNameComboBox.Items.Clear();
            string[] SubDirs;
            try
            {
                SubDirs = Directory.GetDirectories(optionsManager.CurrentPath);
            }
            catch
            {
                optionsManager.WriteStandard();
                ChangePathDialog();
                SubDirs = Directory.GetDirectories(optionsManager.CurrentPath);
            }
            //Console.WriteLine("Current Sub Folders:");
            foreach(string s in SubDirs) 
            {
                SubDirectories.Add(s);
                //Console.WriteLine(s);
            }
            //Console.WriteLine("Current Sub Directory Names:");
            foreach(string s in SubDirs)
            {
                string PathName = System.IO.Path.GetFileName(s);
                SubDirectories.Add(PathName);
                PathNameComboBox.Items.Add(PathName);
                //Console.WriteLine(PathName);
            }
        }

        public void UpdateOptions()
        {
            optionsManager.ReadOptions();
        }

        public void SaveFileToCurrent(Word._Document FileToSave)
        {
           
        }

        public void ChangeButtonClick(object sender, EventArgs e)
        {
            optionsManager.CurrentPath = ChangePathDialog();
        }

        public void SaveButtonClick(object sender, EventArgs e)
        {
            CreateSaveDocument();
        }

        public void CreateSaveDocument()
        {
            string DatePath = PathNameComboBox.SelectedValue + " " + DateDay + "." + DateMonth + "." + DateYear;
            string DateOnly = DateDay + "." + DateMonth + "." + DateYear;

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc";

            string TitleText = TitleTextBox.Text;

            Word._Application oWord;
            Word.Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            0, ref oMissing);

            if (optionsManager.IncludeFolderAndDate)
            {
                Word.Paragraph Fach;
                Fach = oDoc.Content.Paragraphs.Add(ref oMissing);
                Fach.Range.Text = DatePath;
                Fach.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
                Fach.Range.InsertParagraphAfter();
            }

            Word.Paragraph US;
            US = oDoc.Content.Paragraphs.Add(ref oMissing);
            US.Range.Text = TitleText;
            US.Range.Font.Size = optionsManager.TitleSize;
            US.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            US.Range.Font.Bold = 1;
            US.Range.InsertParagraphAfter();

            Word.Paragraph Nothing;
            Nothing = oDoc.Content.Paragraphs.Add(ref oMissing);
            Nothing.Range.Text = "";
            Nothing.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            Nothing.Format.SpaceAfter = 0;
            Nothing.Range.Font.Bold = 0;

            if (!Directory.Exists(optionsManager.CurrentPath + "\\" + PathNameComboBox.SelectedValue))
            {
                optionsManager.CurrentPath = ChangePathDialog();
            }
            //Console.WriteLine(oDoc.SaveFormat);
            try
            {
                oDoc.SaveAs(optionsManager.CurrentPath + "\\" + PathNameComboBox.SelectedValue + "\\" + (optionsManager.FolderInFileName ? DatePath : DateOnly) + " " + TitleText + ".docx", Word.WdSaveFormat.wdFormatDocumentDefault);
            }
            catch
            {
                MessageBox.Show("The file wasnt saved beacause a file with the same name already exists.","Warning");
            }
            
        }

        public void PathNameSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void OptionsButtonClick(object sender, RoutedEventArgs e)
        {
            Window optionsWindow = new OptionsWindow(optionsManager);
            optionsWindow.Show();
        }
    }
}
