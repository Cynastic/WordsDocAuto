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
        string currentPath = string.Empty;
        string SelectedPath = string.Empty;
        List<string> SubDirectories = new List<string>();
        List<string> SubDirectoryNames = new List<string>();
        string DateDay = DateTime.Now.Day > 9 ? DateTime.Now.Day.ToString() : "0" + DateTime.Now.Day.ToString();
        string DateMonth = DateTime.Now.Month > 9 ? DateTime.Now.Month.ToString() : "0" + DateTime.Now.Month.ToString();

        string SavedPathFile = AppDomain.CurrentDomain.BaseDirectory + "SavePath.txt";
        public MainWindow()
        {
            InitializeComponent();
            currentPath = PathFromFile();
            if(currentPath == string.Empty)
            {
                currentPath = ChangePathDialog();
            }
            GetSubDirectories();
        }

        public string ChangePathDialog()
        {
            WinForms.FolderBrowserDialog folderBrowser = new WinForms.FolderBrowserDialog();
            folderBrowser.SelectedPath = "G:\\Test";
            folderBrowser.ShowDialog();
            
            if(Directory.Exists(folderBrowser.SelectedPath))
            {
                Console.WriteLine("Set Path to: " + folderBrowser.SelectedPath);
                currentPath = folderBrowser.SelectedPath;
                SavePathToFile();
                GetSubDirectories();
                return folderBrowser.SelectedPath;
            }
            else
            {
                Console.WriteLine("Choosen Directory doesnt exist");
                return string.Empty;
            }
        }

        public string PathFromFile()
        {
            if(File.ReadAllText(SavedPathFile) != string.Empty)
            {
                return File.ReadAllText(SavedPathFile);
            }
            else
            {
                Console.WriteLine("Saved Path File was Empty");
                return string.Empty;
            }
        }

        public void SavePathToFile()
        {
            Console.WriteLine("Saving Path to Path File: " + SavedPathFile);
            File.WriteAllText(SavedPathFile, currentPath);
        }

        public void GetSubDirectories()
        {
            PathNameComboBox.Items.Clear();
            string[] SubDirs = Directory.GetDirectories(currentPath);
            Console.WriteLine("Current Sub Folders:");
            foreach(string s in SubDirs) 
            {
                SubDirectories.Add(s);
                Console.WriteLine(s);
            }
            Console.WriteLine("Current Sub Directory Names:");
            foreach(string s in SubDirs)
            {
                string PathName = System.IO.Path.GetFileName(s);
                SubDirectories.Add(PathName);
                PathNameComboBox.Items.Add(PathName);
                Console.WriteLine(PathName);
            }
        }

        public void SaveFileToCurrent(Word._Document FileToSave)
        {
           
        }

        public void OptionsButtonClick(object sender, EventArgs e)
        {
            currentPath = ChangePathDialog();
        }

        public void SaveButtonClick(object sender, EventArgs e)
        {
            CreateSaveDocument();
        }

        public void CreateSaveDocument()
        {
            string DatePath = PathNameComboBox.SelectedValue + " " + DateDay + "." + DateMonth + ".";

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc";

            string TitleText = TitleTextBox.Text;

            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);

            Word.Paragraph Fach;
            Fach = oDoc.Content.Paragraphs.Add(ref oMissing);
            Fach.Range.Text = DatePath + DateTime.Now.Year.ToString().Substring(2);
            Fach.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
            Fach.Range.InsertParagraphAfter();

            Word.Paragraph US;
            US = oDoc.Content.Paragraphs.Add(ref oMissing);
            US.Range.Text = TitleText;
            US.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            US.Range.Font.Bold = 1;
            US.Range.InsertParagraphAfter();

            Word.Paragraph Nothing;
            Nothing = oDoc.Content.Paragraphs.Add(ref oMissing);
            Nothing.Range.Text = "";
            Nothing.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            Nothing.Format.SpaceAfter = 0;
            Nothing.Range.Font.Bold = 0;

            if (!Directory.Exists(currentPath))
            {
                currentPath = ChangePathDialog();
            }
            oDoc.SaveAs(currentPath + "\\" + SelectedPath + "\\" + DatePath + DateTime.Now.Year.ToString().Substring(2) + " " + TitleText);
        }

        public void PathNameSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedPath = (string)PathNameComboBox.SelectedValue;
        }
    }
}
