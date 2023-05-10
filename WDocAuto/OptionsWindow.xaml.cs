using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Shapes;

namespace WDocAuto
{
    /// <summary>
    /// Interaktionslogik für OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        public MainWindow mainWindow;
        bool FolderInTitle = false;
        bool IncludeDateTop = true;
        int TitleSize = 11;
        public OptionsWindow(MainWindow mainWindow)
        {
            //Lines
            //1 = Path (string)
            //2 = Folder Name in File Name (bool)
            //3 = Size of Title Text (int)
            //4 = Include Date on Top (bool)
            InitializeComponent();
            this.mainWindow = mainWindow;
            if(File.ReadAllLines(mainWindow.SavedPathFile).Length != 4 )
            {
                string[] write = { File.ReadAllLines(mainWindow.SavedPathFile)[0], FolderInTitle.ToString(), TitleSize.ToString(), IncludeDateTop.ToString()};
                File.WriteAllLines(mainWindow.SavedPathFile, write);
            }
            GetOptions();
        }

        public void GetOptions()
        {
            string[] options = File.ReadAllLines(mainWindow.SavedPathFile);
            FolderInTitle = Convert.ToBoolean(options[1]);
            TitleSize = Convert.ToInt32(options[2]);
            IncludeDateTop = Convert.ToBoolean(options[3]);
            this.IncludeInNameBox.IsChecked = FolderInTitle;
            this.TitleSizeBox.Text = TitleSize.ToString();
            this.IncludeFDateBox.IsChecked = IncludeDateTop;
        }

        private void ApplyButtonClick(object sender, RoutedEventArgs e)
        {
            string[] content = File.ReadAllLines(mainWindow.SavedPathFile);
            string[] toWrite = { content[0], FolderInTitle.ToString(), TitleSize.ToString(), IncludeDateTop.ToString() };
            File.WriteAllLines(mainWindow.SavedPathFile, toWrite);
            mainWindow.UpdateOptions();
            this.Close();
        }

        private void InNameClick(object sender, RoutedEventArgs e)
        {
            FolderInTitle = Convert.ToBoolean(IncludeInNameBox.IsChecked.ToString());
        }

        private void TitleSizeBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TitleSizeTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TitleSize = Convert.ToInt32(TitleSizeBox.Text);
            }
            catch
            {
                if(TitleSizeBox.Text != string.Empty)
                {
                    TitleSizeBox.Clear();
                    MessageBox.Show("Please enter a number");
                }
            }
        }

        private void IncludeFDateClick(object sender, RoutedEventArgs e)
        {
            IncludeDateTop = Convert.ToBoolean(IncludeFDateBox.IsChecked.ToString());
        }
    }
}
