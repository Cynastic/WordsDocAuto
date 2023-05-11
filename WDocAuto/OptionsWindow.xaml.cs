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
        public OptionsManager optionsManager;

        public OptionsWindow(OptionsManager optionsManager)
        {
            InitializeComponent();
            this.optionsManager = optionsManager;
            GetOptions();
        }

        public void GetOptions()
        {
            this.IncludeInNameBox.IsChecked = optionsManager.FolderInFileName;
            this.TitleSizeBox.Text = optionsManager.TitleSize.ToString();
            this.IncludeFDateBox.IsChecked = optionsManager.IncludeFolderAndDate;
            this.CloseOnCreateBox.IsChecked = optionsManager.CloseOnCreate;
        }

        private void ApplyButtonClick(object sender, RoutedEventArgs e)
        {
            optionsManager.WriteOptions();
            this.Close();
        }

        private void InNameClick(object sender, RoutedEventArgs e)
        {
            optionsManager.FolderInFileName = Convert.ToBoolean(IncludeInNameBox.IsChecked.ToString());
        }

        private void TitleSizeBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TitleSizeTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                optionsManager.TitleSize = Convert.ToInt32(TitleSizeBox.Text);
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
            optionsManager.IncludeFolderAndDate = Convert.ToBoolean(IncludeFDateBox.IsChecked.ToString());
        }

        private void CloseOnCreateBoxClick(object sender, RoutedEventArgs e)
        {
            optionsManager.CloseOnCreate = Convert.ToBoolean(CloseOnCreateBox.IsChecked);
        }
    }
}
